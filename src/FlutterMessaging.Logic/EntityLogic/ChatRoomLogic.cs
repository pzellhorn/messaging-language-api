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
            if (profileId == request.OtherProfileId)
                throw new InvalidOperationException("Cannot open a chat with yourself.");

            // Ensure both profiles exist
            Profile? profile1 = await profileRepository.Get(profileId, cancellationToken);
            Profile? profile2 = await profileRepository.Get(request.OtherProfileId, cancellationToken);

            if (profile1 == null || profile2 == null)
                throw new KeyNotFoundException("One or both profiles do not exist.");
 

            List<ChatRoomMember> profile1Memberships =
                await chatRoomMemberRepository.GetFor(profileId, x => x.ProfileId, cancellationToken);

            List<ChatRoomMember> profile2Memberships =
                await chatRoomMemberRepository.GetFor(request.OtherProfileId, x => x.ProfileId, cancellationToken);


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
                        member2 = members.First(m => m.ProfileId == request.OtherProfileId);
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

        
        public Task<ListChatRoomsResponse> ListChatRooms(
            Guid profileId,
            ListChatRoomsRequest request,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ChatRoomMessagesInRoomResponse> GetMessagesInRoom(
            Guid profileId,
            Guid chatRoomId,
            ChatRoomMessagesInRoomRequest request,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<SendMessageResponse> SendMessage(
            Guid profileId,
            Guid chatRoomId,
            SendMessageRequest request,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ReadMessageResponse> ReadMessage(
            Guid profileId,
            Guid chatRoomId,
            ReadMessageRequest request,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
