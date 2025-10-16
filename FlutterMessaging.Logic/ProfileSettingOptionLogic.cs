using FlutterMessaging.Logic.Base;
using FlutterMessaging.State.Base.Interfaces;
using FlutterMessaging.State.Data.Entities;

namespace FlutterMessaging.Logic
{
    public class ProfileSettingOptionLogic(IBaseRepository<ProfileSettingOption> profileSettingOptionRepository) : BaseLogic<ProfileSettingOption>(profileSettingOptionRepository)
    {

    }
}
