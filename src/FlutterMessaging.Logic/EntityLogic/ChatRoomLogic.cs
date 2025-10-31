using pzellhorn.Core.Logic.Base;
using pzellhorn.Core.State.Base.Interfaces;
using FlutterMessaging.State.Data.Entities;
using FlutterMessaging.DTO.RequestDTOs.MessagingRequests;
using FlutterMessaging.DTO.ResponseDTOs.MessagingResponses;
using FlutterMessaging.DTO.ResponseDTOs.EntityResponses;
using FlutterMessaging.DTO.Types;

namespace FlutterMessaging.Logic.EntityLogic
{
    public class ChatRoomLogic(
        IBaseRepository<ChatRoom> chatRoomRepository, 
        IBaseRepository<Profile> profileRepository,
        IBaseRepository<ChatRoomMember> chatRoomMemberRepository,
        IBaseRepository<ChatRoomMessage> chatRoomMessageRepository
        
        ) : BaseLogic<ChatRoom>(chatRoomRepository)
    {
        public async Task<PostChatRoomsDmStartResponse> OpenChatRoom(
            Guid profileId,
            OpenChatRoomRequest request,
            CancellationToken cancellationToken = default)
        {

            List<Profile> convoPartnerProfiles = await profileRepository.GetFor(request.EmailAddress, x => x.EmailAddress, cancellationToken);
            Profile? convoPartnerProfile = convoPartnerProfiles.FirstOrDefault();
            if (convoPartnerProfile == null)
                throw new InvalidOperationException("Email Address invalid");

            if (profileId == convoPartnerProfile.ProfileId)
                throw new InvalidOperationException("Cannot open a chat with yourself.");

            // Ensure both profiles exist
            Profile? profile1 = await profileRepository.Get(profileId, cancellationToken);
            Profile? profile2 = await profileRepository.Get(convoPartnerProfile.ProfileId, cancellationToken);

            if (profile1 == null || profile2 == null)
                throw new KeyNotFoundException("One or both profiles do not exist.");
 

            List<ChatRoomMember> profile1Memberships =
                await chatRoomMemberRepository.GetFor(profileId, x => x.ProfileId, cancellationToken);

            List<ChatRoomMember> profile2Memberships =
                await chatRoomMemberRepository.GetFor(convoPartnerProfile.ProfileId, x => x.ProfileId, cancellationToken);


            HashSet<Guid> profile1RoomIds = profile1Memberships.Select(x => x.ChatRoomId).ToHashSet();
            HashSet<Guid> profile2RoomIds = profile2Memberships.Select(x => x.ChatRoomId).ToHashSet();
            List<Guid> candidateRoomIds = profile1RoomIds.Intersect(profile2RoomIds).ToList();

            ChatRoom? room = null;

            // Check if existing room exists for these two profiles 
            ChatRoomMember member1 = new();
            ChatRoomMember member2 = new();

            foreach (Guid roomId in candidateRoomIds)
            {
                List<ChatRoomMember> members = await chatRoomMemberRepository.GetFor(roomId, x => x.ChatRoomId, cancellationToken);
                if (members.Count == 2)
                {
                    room = await chatRoomRepository.Get(roomId, cancellationToken);
              
                    if (room != null)
                    {
                        member1 = members.First(m => m.ProfileId == profileId);
                        member2 = members.First(m => m.ProfileId == convoPartnerProfile.ProfileId);
                        break;
                    }
                }
            } 

            if (room == null)
            {
                room = new ChatRoom();  

                room = await chatRoomRepository.Upsert(room, cancellationToken);

                member1 = new();
                member1.ChatRoomId = room.ChatRoomId;
                member1.ProfileId = profile1.ProfileId;

                member2 = new();
                member2.ChatRoomId = room.ChatRoomId;
                member2.ProfileId = profile2.ProfileId; 

                member1 = await chatRoomMemberRepository.Upsert(member1, cancellationToken);
                member2 = await chatRoomMemberRepository.Upsert(member2, cancellationToken);
            }

            MessageParticipantResponse participant2 = new();
            participant2.ProfileId = profile2.ProfileId;
            participant2.DisplayName = profile2.ProfileName;
            participant2.AvatarUrl = null;                    //we're going to be getting this from profile settings later
            participant2.Email = profile2.EmailAddress;  


            // Pull messages for this room if this room already existed
            List<ChatRoomMessage> messages = await chatRoomMessageRepository.GetFor(room.ChatRoomId, x => x.ChatRoomId, cancellationToken);

            if (messages.Count > 0)
            {
                ChatRoomMessage? lastMessage = messages.OrderByDescending(x => x.CreatedAt).FirstOrDefault();

                ChatRoomMessageResponse lastMessageResponse = new()
                {
                    ChatRoomMessageId = lastMessage.ChatRoomMessageId,
                    MessageText = lastMessage.MessageText,
                    CreatedAt = lastMessage.CreatedAt,
                    ProfileId = lastMessage.ProfileId,
                };

                int unreadCount = 0;
                if (member1?.LastReadAt != null)
                    unreadCount = messages.Where(x => x.ProfileId != profileId && x.CreatedAt > member1.LastReadAt).Count();

                return new PostChatRoomsDmStartResponse
                {
                    ChatRoomId = room.ChatRoomId,
                    OtherParticipant = participant2,
                    LastMessage = lastMessageResponse,
                    UnreadCount = unreadCount
                };
            }
             
            return new PostChatRoomsDmStartResponse
            {
                ChatRoomId = room.ChatRoomId,
                OtherParticipant = participant2,
                LastMessage = null,
                UnreadCount = 0
            }; 
        }


        public async Task<ListChatRoomsResponse> ListChatRooms(
            Guid profileId,
            ListChatRoomsRequest request,
            CancellationToken cancellationToken = default)
        { 
            List<ChatRoomMember> memberships = await chatRoomMemberRepository.GetFor(profileId, x => x.ProfileId, cancellationToken);

            List<Guid> roomIds = memberships.Select(x => x.ChatRoomId).Distinct().ToList();

            List<ChatRoom> rooms = new List<ChatRoom>();
            foreach (Guid roomId in roomIds)
            {
                ChatRoom? room = await chatRoomRepository.Get(roomId, cancellationToken);

                if (room != null) 
                    rooms.Add(room);
            }
             
            if (request.MessagesAfter != null)
                rooms = rooms.Where(x => x.CreatedAt < request.MessagesAfter).ToList();
             
            rooms = rooms.OrderByDescending(x => x.CreatedAt).ToList();

            int take = request.Limit > 0 ? Math.Min(request.Limit, 100) : 20;
            bool hasNextPage = rooms.Count > take;
            List<ChatRoom> pageRooms = rooms.Take(take).ToList();

            DateTime? nextCursorFromPage = pageRooms.Count > 0 ? pageRooms.Last().CreatedAt : null;

            List<ChatRoomItemResponse> responseItems = new();
            Dictionary<Guid, Profile> profileCache = new();

            foreach (ChatRoom room in pageRooms)
            { 
                List<ChatRoomMember> members = await chatRoomMemberRepository.GetFor(room.ChatRoomId, x => x.ChatRoomId, cancellationToken);
                 
                //Exclude rooms with more than 2 members for now. Only 2 people groups
                if (members.Count != 2 || !members.Any(x => x.ProfileId == profileId))
                    continue;

                ChatRoomMember myMember = members.First(m => m.ProfileId == profileId);
                ChatRoomMember otherMember = members.First(m => m.ProfileId != profileId);

                if (!profileCache.TryGetValue(otherMember.ProfileId, out Profile? otherProfile))
                {
                    otherProfile = await profileRepository.Get(otherMember.ProfileId, cancellationToken);
                    if (otherProfile != null)
                        profileCache[otherMember.ProfileId] = otherProfile;
                    else
                        continue;
                }


                MessageParticipantResponse otherDto = new MessageParticipantResponse
                {
                    ProfileId = otherProfile.ProfileId,
                    DisplayName = otherProfile.ProfileName,   
                    AvatarUrl = null,                     
                    Email = otherProfile.EmailAddress
                };
                 


                //Get last message to load into the Message card
                List<ChatRoomMessage> messages = await chatRoomMessageRepository.GetFor(room.ChatRoomId, x => x.ChatRoomId, cancellationToken);

                ChatRoomMessageTypeResponse? lastMessageDto = null;
                if (messages.Count > 0)
                {
                    ChatRoomMessage lastMessage = messages.OrderByDescending(x => x.CreatedAt).ThenByDescending(x => x.ChatRoomMessageId).First();

                    lastMessageDto = new ChatRoomMessageTypeResponse
                    {
                        ChatRoomMessageId = lastMessage.ChatRoomMessageId,
                        MessageText = lastMessage.MessageText,
                        CreatedAt = lastMessage.CreatedAt,
                        SenderProfileId = lastMessage.ProfileId
                    };
                }
                 
                int unread = messages.Count(x => x.ProfileId == otherMember.ProfileId && (myMember.LastReadAt == null || x.CreatedAt > myMember.LastReadAt.Value));

                // build list item
                ChatRoomItemResponse item = new()
                {
                    ChatRoomId = room.ChatRoomId,
                    CreatedAt = room.CreatedAt,
                    OtherParticipant = otherDto,
                    LastMessage = lastMessageDto,
                    UnreadCount = unread
                };

                responseItems.Add(item);
            }

            DateTime? readUpTo = nextCursorFromPage;

            return new ListChatRoomsResponse
            {
                Items = responseItems,
                ReadUpTo = readUpTo,
                HasNextPage = hasNextPage,
            };
        }


        public async Task<ChatRoomMessagesInRoomResponse> GetMessagesInRoom(
         Guid profileId,
         Guid chatRoomId,
         ChatRoomMessagesInRoomRequest request,
         CancellationToken cancellationToken = default)
        { 
            List<ChatRoomMember> members = await chatRoomMemberRepository.GetFor(chatRoomId, x => x.ChatRoomId, cancellationToken);

            if (members.Count != 2 || !members.Any(m => m.ProfileId == profileId))
                throw new Exception("Not a member of this room or room is not a 1:1 chat.");
             
            List<ChatRoomMessage> allMessages = await chatRoomMessageRepository.GetFor(chatRoomId, x => x.ChatRoomId, cancellationToken);
             
            DateTime? getMessagesAfter = request.MessagesAfter;

            if (request.AfterMessageId.HasValue)
            {
                List<ChatRoomMessage> afterList = await chatRoomMessageRepository.GetFor(request.AfterMessageId.Value, x => x.ChatRoomMessageId, cancellationToken);

                ChatRoomMessage? afterMsg = afterList.FirstOrDefault(m => m.ChatRoomId == chatRoomId);
                if (afterMsg != null)
                    getMessagesAfter = afterMsg.CreatedAt;
            }
             
            IEnumerable<ChatRoomMessage> filtered = allMessages;
            if (getMessagesAfter.HasValue)
                filtered = filtered.Where(m => m.CreatedAt > getMessagesAfter.Value);

            List<ChatRoomMessage> ordered = filtered.OrderBy(m => m.CreatedAt).ThenBy(m => m.ChatRoomMessageId).ToList();

            int take = request.Limit > 0 ? Math.Min(request.Limit, 200) : 50;

            //We do this +1 check to calculate if we still have messages to page through before getting caught up
            List<ChatRoomMessage> pagePlusOne = ordered.Take(take + 1).ToList();
            List<ChatRoomMessage> page = ordered.Take(take).ToList();

            bool hasMore = pagePlusOne.Count > take;

            List<ChatRoomMessageTypeResponse> items = page.Select(x => new ChatRoomMessageTypeResponse
            {
                ChatRoomMessageId = x.ChatRoomMessageId,
                MessageText = x.MessageText,
                CreatedAt = x.CreatedAt,
                SenderProfileId = x.ProfileId
            }).ToList();

            Guid? nextAfter = hasMore ? page.Last().ChatRoomMessageId : (Guid?)null;

            return new ChatRoomMessagesInRoomResponse
            {
                Items = items,
                NextAfterMessageId = nextAfter,
                HasMore = hasMore
            };
        }


        public async Task<SendMessageResponse> SendMessage(
             Guid profileId,
             Guid chatRoomId,
             SendMessageRequest request,
             CancellationToken cancellationToken = default)
        {
            string text = (request.MessageText ?? string.Empty).Trim();
            if (text.Length == 0)
                throw new ArgumentException("Message cannot be empty."); 
             
            List<ChatRoomMember> members =
                await chatRoomMemberRepository.GetFor(chatRoomId, x => x.ChatRoomId, cancellationToken);

            if (members.Count != 2 || !members.Any(m => m.ProfileId == profileId))
                throw new UnauthorizedAccessException("Not a member of this room or room is not a 1:1 chat.");

            ChatRoomMessage chatMessage = new()
            { 
                ChatRoomId = chatRoomId,
                ProfileId = profileId,
                MessageText = text,
                CreatedAt = DateTime.UtcNow
            };

            chatMessage = await chatRoomMessageRepository.Upsert(chatMessage, cancellationToken);

            ChatRoomMessageTypeResponse dto = new ()
            {
                ChatRoomMessageId = chatMessage.ChatRoomMessageId,
                MessageText = chatMessage.MessageText,
                CreatedAt = chatMessage.CreatedAt,
                SenderProfileId = chatMessage.ProfileId
            };

            return new SendMessageResponse
            {
                Message = dto
            };
        }


        public async Task<ReadMessageResponse> ReadMessage(
            Guid profileId,
            Guid chatRoomId,
            ReadMessageRequest request,
            CancellationToken cancellationToken = default)
        { 
            List<ChatRoomMember> members = await chatRoomMemberRepository.GetFor(chatRoomId, x => x.ChatRoomId, cancellationToken);

            if (members.Count != 2 || !members.Any(m => m.ProfileId == profileId))
                throw new UnauthorizedAccessException("Not a member of this room or room is not a 1:1 chat.");

            ChatRoomMember myMember = members.First(m => m.ProfileId == profileId);
            ChatRoomMember otherMember = members.First(m => m.ProfileId != profileId);
             
            DateTime markTime = DateTime.UtcNow;

            if (request.UpToMessageId.HasValue)
            { 
                List<ChatRoomMessage> target = 
                    await chatRoomMessageRepository.GetFor(request.UpToMessageId.Value, x => x.ChatRoomMessageId, cancellationToken);

                ChatRoomMessage? upTo = target.FirstOrDefault(m => m.ChatRoomId == chatRoomId);
                if (upTo != null)
                    markTime = upTo.CreatedAt;
            }
             
            // Update the chatRoomMember with the last readTime
            if (myMember.LastReadAt == null || markTime > myMember.LastReadAt.Value)
            {
                myMember.LastReadAt = markTime;
                myMember = await chatRoomMemberRepository.Upsert(myMember, cancellationToken);
            }

            // Get remaining unread messages in this chat room
            List<ChatRoomMessage> messages =
                await chatRoomMessageRepository.GetFor(chatRoomId, x => x.ChatRoomId, cancellationToken);

            int unread = messages.Count(x => x.ProfileId == otherMember.ProfileId 
                    && (myMember.LastReadAt == null || x.CreatedAt > myMember.LastReadAt.Value));

            return new ReadMessageResponse
            {
                UnreadCount = unread
            };
        }

    }
}
