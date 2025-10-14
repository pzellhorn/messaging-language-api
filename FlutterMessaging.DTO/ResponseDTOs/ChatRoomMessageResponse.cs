using System;

namespace FlutterMessaging.DTO.ResponseDTOs;

public class ChatRoomMessageResponse(Guid? chatRoomMessageId, Guid profileId, Guid chatRoomId, string messageText)
{
    public Guid? ChatRoomMessageId { get; } = chatRoomMessageId;
    public Guid ProfileId { get; } = profileId;
    public Guid ChatRoomId { get; } = chatRoomId;
    public string MessageText { get; } = messageText;
}
