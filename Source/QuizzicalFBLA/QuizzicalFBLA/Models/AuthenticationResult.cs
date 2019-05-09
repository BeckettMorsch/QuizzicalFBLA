using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using QuizzicalFBLA.Helpers;

namespace QuizzicalFBLA.Models
{
    public class AuthenticationResult
    {
        public string IdToken { get; set; }
        public string AccessToken { get; set; }
        public IEnumerable<Claim> UserClaims { get; set; }
        
        // Remaps the user claim obtained from Auth0 to a dictionary 
        public Dictionary<string,string> toProfile ()
        {
            Dictionary<string, string> profile = new Dictionary<string, string>();

            foreach (var claim in UserClaims)
            {
                if (!profile.ContainsKey(claim.Type))
                    profile.Add(claim.Type, claim.Value);
            }

            if (profile.ContainsKey("sub"))
            {
                string AutoUser = profile["sub"].Replace("-", "").Replace("|", "");
                profile.Add("auto_username", AutoUser);
                profile.Add("auto_password", AutoUser.Sha256Hash());
            }

            return profile;
        }

        public bool IsError { get; }
        public string Error { get; }

        public AuthenticationResult() { }

        public AuthenticationResult(bool isError, string error)
        {
            IsError = isError;
            Error = error;
        }
    }
}
