using System;

namespace FlutterMessaging.DTO.ResponseDTOs;

public class ChatRoomResponse(Guid? chatRoomId, string name)
{
    public Guid? ChatRoomId { get; } = chatRoomId;
    public string Name { get; } = name;
}
