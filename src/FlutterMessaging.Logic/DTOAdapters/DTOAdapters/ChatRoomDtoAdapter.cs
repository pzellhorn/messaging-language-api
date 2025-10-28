using FlutterMessaging.DTO.DTOAdapters.Interfaces;
using FlutterMessaging.DTO.RequestDTOs.EntityDTOs;
using FlutterMessaging.DTO.RequestDTOs.MessagingRequests;
using FlutterMessaging.DTO.ResponseDTOs.EntityResponses;
using FlutterMessaging.DTO.ResponseDTOs.MessagingResponses;
using FlutterMessaging.Logic.EntityLogic;
using FlutterMessaging.Logic.ServiceLogic;
using FlutterMessaging.State.Data.Entities;
using pzellhorn.Core.Logic.Base;
using pzellhorn.Core.Logic.Base.DTOAdapter;

namespace FlutterMessaging.Logic.DTOAdapters.DTOAdapters
{
    public class ChatRoomDtoAdapter(
        ChatRoomLogic chatRoomLogic,
        IUserContext currentUser,
        IDTOMapper<ChatRoom, ChatRoomRequest, ChatRoomResponse> mapper)
        : DtoLogicAdapter<ChatRoom, ChatRoomRequest, ChatRoomResponse>(chatRoomLogic, mapper), IChatRoomDtoAdapter
    {
        public Task<PostChatRoomsDmStartResponse> OpenChatRoom(OpenChatRoomRequest request, CancellationToken cancellationToken = default)
            => chatRoomLogic.OpenChatRoom(currentUser.GetProfileIdOrThrow(), request, cancellationToken);

        public Task<ListChatRoomsResponse> ListChatRooms(ListChatRoomsRequest request, CancellationToken cancellationToken = default)
            => chatRoomLogic.ListChatRooms(currentUser.GetProfileIdOrThrow(), request, cancellationToken);

        public Task<ChatRoomMessagesInRoomResponse> GetMessagesInRoom(Guid chatRoomId, ChatRoomMessagesInRoomRequest request, CancellationToken cancellationToken = default)
            => chatRoomLogic.GetMessagesInRoom(currentUser.GetProfileIdOrThrow(), chatRoomId, request, cancellationToken);

        public Task<SendMessageResponse> SendMessage(Guid chatRoomId, SendMessageRequest request, CancellationToken cancellationToken = default)
            => chatRoomLogic.SendMessage(currentUser.GetProfileIdOrThrow(), chatRoomId, request, cancellationToken);

        public Task<ReadMessageResponse> ReadMessage(Guid chatRoomId, ReadMessageRequest request, CancellationToken cancellationToken = default)
            => chatRoomLogic.ReadMessage(currentUser.GetProfileIdOrThrow(), chatRoomId, request, cancellationToken);
    }
}
