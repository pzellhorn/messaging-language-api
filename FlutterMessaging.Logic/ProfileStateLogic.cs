using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using FlutterMessaging.State.Base.Interfaces;
using FlutterMessaging.State.Data;
using FlutterMessaging.State.Data.Entities;

namespace FlutterMessaging.State.StateLogic
{
    public class ProfileLogic (IBaseRepository<Profile> profileRepository)
    {   
        public async Task<Profile> UpsertProfile(string profile_name)
        {
            Profile profile = new();
            profile.ProfileName = profile_name;

            profile = await profileRepository.Upsert(profile);  
            return profile;
        }
    }
}
