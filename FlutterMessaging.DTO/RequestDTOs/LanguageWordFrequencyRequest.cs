using System;

namespace FlutterMessaging.DTO.RequestDTOs;

public class LanguageWordFrequencyRequest(Guid? languageWordFrequencyId, Guid languageId, Guid languageTranslationId, int frequencyRank)
{
    public Guid? LanguageWordFrequencyId { get; } = languageWordFrequencyId;
    public Guid LanguageId { get; } = languageId;
    public Guid LanguageTranslationId { get; } = languageTranslationId;
    public int FrequencyRank { get; } = frequencyRank;
}
