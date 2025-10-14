using System;

namespace FlutterMessaging.DTO.RequestDTOs;

public class ChatRoomRequest(Guid? chatRoomId, string name)
{
    public Guid? ChatRoomId { get; } = chatRoomId;
    public string Name { get; } = name;
}
