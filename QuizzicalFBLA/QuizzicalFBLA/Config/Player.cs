using GameSparks.NET.Infrastructure.Settings;
using GameSparks.NET.Services;
using GameSparks.NET.Services.Authentication.Requests;
using GameSparks.NET.Services.Authentication.Responses;
using GameSparks.NET.Services.Leaderboards.Requests;
using GameSparks.NET.Services.Player.Requests;
using Leaderboard.Events;
using QuizzicalFBLA.Services;
using QuizzicalFBLA.ViewModels;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using Microsoft.AppCenter;

namespace QuizzicalFBLA.Config
{
    public enum Currencies
    {
        TotalPoints = 1
    }

    public class Player : BaseViewModel
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

        // Achievements currencies

        // GameSparks Currency1
        private int totalPoints = 0;
        public int TotalPoints
        {
            get { return totalPoints; }
            private set {
                totalPoints = value;
                OnPropertyChanged("TotalPoints");
                OnPropertyChanged("TotalPointsMessage");
            }
        }

        public string TotalPointsMessage
        {
            get
            {
                if (totalPoints == 1)
                    return "1 Point";

                return totalPoints.ToString("N0") + " Points";
            }
        }

        public static Player Current
        {
            get {

                if (player == null)
                {
                    player = new Player();
                    player.LoadPreferences();
                }

                return player;
            }
        }

        private void SavePreferences ()
        {
            Preferences.Set("LoggedIn", LoggedIn);
            Preferences.Set("Nickname", Nickname);
            Preferences.Set("Name", Name);
            Preferences.Set("Sub", Sub);
            Preferences.Set("AutoUsername", AutoUsername);
            Preferences.Set("AutoPassword", AutoPassword);
        }

        private void LoadPreferences()
        {
            LoggedIn = Preferences.Get("LoggedIn", false);
            Nickname = Preferences.Get("Nickname", "Player");
            Name = Preferences.Get("Name", "Player");
            Sub = Preferences.Get("Sub", "na|1234567890");
            AutoUsername = Preferences.Get("AutoUsername", "na1234567890");
            AutoPassword = Preferences.Get("AutoPassword", "NDFknf2lakdsjf823jLDSo4indsfDKJie3749fmDklkdskqwIPOjlkdsVCNL4870jhmnsaz");

            OnPropertyChanged("Nickname");
            OnPropertyChanged("Name");
            OnPropertyChanged("Sub");
            OnPropertyChanged("AutoUsername");
            OnPropertyChanged("AutoPassword");
            OnPropertyChanged("LoggedIn");
        }

        public async Task<bool> Login()
        {
            if (!LoggedIn)
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

                    LoggedIn = true;

                    SavePreferences();

                    OnPropertyChanged("Nickname");
                    OnPropertyChanged("Name");
                    OnPropertyChanged("Sub");
                    OnPropertyChanged("AutoUsername");
                    OnPropertyChanged("AutoPassword");
                    OnPropertyChanged("LoggedIn");
                }
            }

            if (LoggedIn)
            {
                GameSparksLoggedIn = false;
                await AuthenticateGameSparks();

                return true;  // Fully logged in
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
                GameSparksLoggedIn = false;
                OnPropertyChanged("LoggedIn");

                SavePreferences();

                OnLogout?.Invoke(this, new EventArgs());
            }
        }

        public async Task RegisterScore (int score)
        {
            var eventService = new GameSparksEventsService();
            var rs = await eventService.LogEventRequestAsync(new ScoreEvent(GameSparksUserID, score));
        }

        private bool HasProperty(dynamic obj, string name)
        {
            Type objType = obj.GetType();

            if (objType == typeof(ExpandoObject))
            {
                return ((IDictionary<string, object>)obj).ContainsKey(name);
            }

            return objType.GetProperty(name) != null;
        }

        public async Task AddCurrency (Currencies currency, int amount)
        {
            int currencyRef = (int)currency;

            if (currencyRef < 1 || currencyRef > 6)
                throw new Exception("Invalid currencyRef - Must be in the range 1-6");

            // Maps to GameSparks Event
            var eventService = new GameSparksEventsService();
            var rs = await eventService.LogEventRequestAsync(new AddPointsEvent(GameSparksUserID, currencyRef, amount));

            if (rs.Error != null)
            {
                //if (rs.Error == "UNKNOWN")
                //        throw new Exception("Invalid EventKey - EventKey must be defined in GameSparks");
            }

            if (currencyRef == (int)Currencies.TotalPoints)
                TotalPoints += amount;

        }

        // Loads player account details from GameSparks
        public async Task RefreshAccountDetails()
        {
            if (!GameSparksLoggedIn) return;

            var playerService = new GameSparksPlayerService();
            var accountDetailsRequest = new AccountDetailsRequest(GameSparksUserID);

            var accountDetails = await playerService.AccountDetailsRequestAsync(accountDetailsRequest);

            TotalPoints = 0;

            if (accountDetails != null)
            {
                // Fill in remaining details
                TotalPoints = accountDetails.Currency1;                
            }
        }

        public async Task AuthenticateGameSparks ()
        {
            // If already logged in no need to re-authenticate
            if (GameSparksLoggedIn) return;

            GameSparksSettings.Set(Secrets.GameSparksApiKey, Secrets.GameSparksCredentials, Secrets.GameSparksSecret, isLive: false);

            GameSparksLoggedIn = false;

            try
            {

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

                    await RefreshAccountDetails();
                }

            }
            catch (Exception e)
            {
                Microsoft.AppCenter.Crashes.Crashes.TrackError(e);
            }
        }

        public EventHandler OnLogout { get; set; }
    }
}
