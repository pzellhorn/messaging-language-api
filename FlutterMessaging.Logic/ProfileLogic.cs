using FlutterMessaging.Logic.Base;
using FlutterMessaging.State.Base.Interfaces;
using FlutterMessaging.State.Data.Entities;

namespace FlutterMessaging.State.StateLogic
{
    public class ProfileLogic (IBaseRepository<Profile> profileRepository) : BaseLogic<Profile>(profileRepository)
    {   
        public async Task<Profile> UpsertProfile(string profile_name)
        {
            Profile profile = new();
            profile.ProfileName = profile_name;

            profile = await base.Upsert(profile);  
            return profile;
        }
    }
}
