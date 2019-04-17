using GameSparks.NET.Infrastructure.Settings;
using GameSparks.NET.Services;
using GameSparks.NET.Services.Authentication.Requests;
using GameSparks.NET.Services.Authentication.Responses;
using GameSparks.NET.Services.Leaderboards.Requests;
using Leaderboard.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizzicalFBLA.Config
{
    public class Player
    {
        private static Player player;

        private Player ()
        {
        }

        public string Nickname { get; set; } = "Player";
        public string Name { get; set; } = "Player";
        public string Sub { get; set; } = "na|1234567890";
        public string AutoUsername { get; set; } = "na1234567890";
        public string AutoPassword { get; set; } = "NDFknf2lakdsjf823jLDSo4indsfDKJie3749fmDklkdskqwIPOjlkdsVCNL4870jhmnsaz";

        public string GameSparksAuthToken { get; set; }
        public string GameSparksUserID { get; set; }

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

        public async void AuthenticateGameSparks ()
        {
            var authService = new GameSparksAuthenticationService();

            var registrationRequest = new RegistrationRequest(Name, AutoPassword, AutoUsername, null);
            var response = authService.RegistrationRequestAsync(registrationRequest);

            if (response.IsCompletedSuccessfully)
            {
                Console.Write("Success!");
            }
            else
            {
                Console.WriteLine(response.Result);
            }

            // Create the AuthenticationRequest(string userName, string password) object
            var authRequest = new AuthenticationRequest(AutoUsername, AutoPassword);

            // Fire the request
            var response2 = authService.AuthenticationRequestAsync(authRequest);

            Console.WriteLine("Auth token: " + response2.AuthToken);
            Console.WriteLine("User ID: " + response2.UserId);
        }
    }
}
