using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using FlutterMessaging.Logic.Base;
using FlutterMessaging.State.Base.Interfaces;
using FlutterMessaging.State.Data.Entities;
using Google.Apis.Auth; 


namespace FlutterMessaging.Logic
{ 
    public class ExternalIdentityLogic(IBaseRepository<ExternalIdentity> externalIdentityRepository, IBaseRepository<Profile> profileRepository) : BaseLogic<ExternalIdentity>(externalIdentityRepository)
    {
        public async Task<ExternalIdentity> AuthenticateWithGoogle(string token, string nonce, CancellationToken cancellationToken)
        {
            GoogleJsonWebSignature.ValidationSettings settings = new GoogleJsonWebSignature.ValidationSettings
            {
                Audience = new[] { "535701860749-k1dkt8jpjtek3t9td9kkvpcqohaomeun.apps.googleusercontent.com" }
            };

            GoogleJsonWebSignature.Payload payload = await GoogleJsonWebSignature.ValidateAsync(token, settings);

            bool validIssuer = payload.Issuer == "https://accounts.google.com" || payload.Issuer == "accounts.google.com";
            
            if (!validIssuer) throw new UnauthorizedAccessException("Bad issuer");
            if (!(payload.EmailVerified)) throw new UnauthorizedAccessException("Unverified email");

            //nonce
            if (!string.IsNullOrEmpty(nonce) && !string.Equals(payload.Nonce, nonce, StringComparison.Ordinal))
                throw new UnauthorizedAccessException("Nonce mismatch");

            string subject = payload.Subject;
            string issuer = payload.Issuer;
            string email = payload.Email;

            List<ExternalIdentity> subjects = await externalIdentityRepository.GetFor(subject, x => x.Subject, cancellationToken);
            Profile? profile = subjects.FirstOrDefault(x => x.Issuer == issuer)?.Profile;

            //If profile does not exist at all, create a new profile
            if (profile == null)
            {
                Profile newProfile = new();
                newProfile.EmailAddress = email;


                profile = await profileRepository.Upsert(newProfile, cancellationToken);  
            }

            // If this authentication method is not yet mapped to the user acccount, map a new ExternalIdentity to it. 
            if (!profile.ExternalIdentities.Where(x => x.Issuer == issuer).Any())
            {
                ExternalIdentity newIdentity = new();
                newIdentity.ProfileId = profile.ProfileId;
                newIdentity.Issuer = issuer;
                newIdentity.Provider = "Google";
                newIdentity.Subject = subject;

                await externalIdentityRepository.Upsert(newIdentity, cancellationToken);
            }


            //Mint token for user authentication



            //return token
            return default;
        }
    }
}
