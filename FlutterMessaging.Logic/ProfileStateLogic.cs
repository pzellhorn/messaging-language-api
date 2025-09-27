using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using FlutterMessaging.State.Data;
using FlutterMessaging.State.Data.Entities;

namespace FlutterMessaging.State.StateLogic
{
    public class ProfileLogic (ProfileRepository profileRepository)
    {   
        public async Task<profile> UpsertProfile(string profile_name)
        {
            profile profile = new();
            profile.profile_name = profile_name;

            profile = await profileRepository.Upsert(profile);  
            return profile;
        }
    }
}
