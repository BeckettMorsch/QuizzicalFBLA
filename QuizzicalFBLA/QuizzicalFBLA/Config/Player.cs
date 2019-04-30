using GameSparks.NET.Infrastructure.Settings;
using GameSparks.NET.Services;
using GameSparks.NET.Services.Authentication.Requests;
using GameSparks.NET.Services.Authentication.Responses;
using GameSparks.NET.Services.Leaderboards.Requests;
using Leaderboard.Events;
using QuizzicalFBLA.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QuizzicalFBLA.Config
{
    public class Player
    {
        private static Player player;

        private Player ()
        {
        }

        public bool LoggedIn { get; set; } = false;
        public string Nickname { get; set; } = "Player";
        public string Name { get; set; } = "Player";
        public string Sub { get; set; } = "na|1234567890";
        public string AutoUsername { get; set; } = "na1234567890";
        public string AutoPassword { get; set; } = "NDFknf2lakdsjf823jLDSo4indsfDKJie3749fmDklkdskqwIPOjlkdsVCNL4870jhmnsaz";

        public string GameSparksAuthToken { get; set; }
        public string GameSparksUserID { get; set; }
        public bool GameSparksLoggedIn { get; set; } = false;

        public static Player Current
        {
            get {

                if (player == null)
                {
                    player = new Player();
                }

                return player;
            }
        }

        public async Task<bool> Login()
        {
            var authenticationService = DependencyService.Get<IAuthenticationService>();
            var authenticationResult = await authenticationService.Authenticate();

            if (!authenticationResult.IsError)
            {
                Dictionary<string, string> profile = authenticationResult.toProfile();

                // Store player profile in the Player singleton
                Nickname = profile["nickname"];
                Name = profile["name"];
                Sub = profile["sub"];
                AutoUsername = profile["auto_username"];
                AutoPassword = profile["auto_password"];

                await AuthenticateGameSparks();

                LoggedIn = true;

                return true;
            }

            LoggedIn = false;

            return false;
        }

        public void Logout()
        {
            if (LoggedIn)
            {
                var authenticationService = DependencyService.Get<IAuthenticationService>();
                authenticationService.Logout();
                LoggedIn = false;
            }
        }

        public async Task RegisterScore (int score)
        {
            var eventService = new GameSparksEventsService();
            var rs = await eventService.LogEventRequestAsync(new ScoreEvent(GameSparksUserID, score));
        }

        public async Task AuthenticateGameSparks ()
        {
            // If already logged in no need to re-authenticate
            if (GameSparksLoggedIn) return;

            GameSparksSettings.Set(Secrets.GameSparksApiKey, Secrets.GameSparksCredentials, Secrets.GameSparksSecret, isLive: false);

            GameSparksLoggedIn = false;

            var authService = new GameSparksAuthenticationService();

            // Create the AuthenticationRequest(string userName, string password) object
            var authRequest = new AuthenticationRequest(AutoUsername, AutoPassword);

            // Fire the request
            var response = await authService.AuthenticationRequestAsync(authRequest);

            if (response.Error != null)
            {
                // There was an error
                var registrationRequest = new RegistrationRequest(Name, AutoPassword, AutoUsername, null);
                response = await authService.RegistrationRequestAsync(registrationRequest);
            }

            if (response.Error == null)
            {
                //Console.WriteLine("Auth token: " + response2.AuthToken);
                //Console.WriteLine("User ID: " + response2.UserId);
                GameSparksAuthToken = response.AuthToken;
                GameSparksUserID = response.UserId;
                GameSparksLoggedIn = true;
            }
        }
    }
}
