using FlutterMessaging.Logic.Base;
using FlutterMessaging.State.Base.Interfaces;
using FlutterMessaging.State.Data.Entities;

namespace FlutterMessaging.Logic.EntityLogic
{
    public class ProfileSettingLogic(IBaseRepository<ProfileSetting> profileSettingRepository) : BaseLogic<ProfileSetting>(profileSettingRepository)
    {

    }

}
