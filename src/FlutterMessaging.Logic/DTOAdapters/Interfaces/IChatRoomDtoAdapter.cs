using FlutterMessaging.DTO.RequestDTOs.EntityDTOs;
using FlutterMessaging.DTO.RequestDTOs.MessagingRequests;
using FlutterMessaging.DTO.ResponseDTOs.EntityResponses;
using FlutterMessaging.DTO.ResponseDTOs.MessagingResponses;
using pzellhorn.Core.Logic.Base.DTOAdapter;

namespace FlutterMessaging.DTO.DTOAdapters.Interfaces
{
    public interface IChatRoomDtoAdapter
        : IDtoLogicAdapter<ChatRoomRequest, ChatRoomResponse>
    {
        Task<PostChatRoomsDmStartResponse> OpenChatRoom(OpenChatRoomRequest request, CancellationToken cancellationToken = default);
        Task<ListChatRoomsResponse> ListChatRooms(ListChatRoomsRequest request, CancellationToken cancellationToken = default);
        Task<ChatRoomMessagesInRoomResponse> GetMessagesInRoom(Guid chatRoomId, ChatRoomMessagesInRoomRequest request, CancellationToken cancellationToken = default);
        Task<SendMessageResponse> SendMessage(Guid chatRoomId, SendMessageRequest request, CancellationToken cancellationToken = default);
        Task<ReadMessageResponse> ReadMessage(Guid chatRoomId, ReadMessageRequest request, CancellationToken cancellationToken = default);
    }
}
