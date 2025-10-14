using System;

namespace FlutterMessaging.DTO.ResponseDTOs;

public class LanguageResponse(Guid? languageId, string name)
{
    public Guid? LanguageId { get; } = languageId;
    public string Name { get; } = name;
}
