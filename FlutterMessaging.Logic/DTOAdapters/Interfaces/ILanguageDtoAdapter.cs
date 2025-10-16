using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;
using FlutterMessaging.Logic.Base.DTOAdapter;

namespace FlutterMessaging.DTO.DTOAdapters.Interfaces
{
    public interface ILanguageDtoAdapter
        : IDtoLogicAdapter<LanguageRequest, LanguageResponse>
    {
    }
}
