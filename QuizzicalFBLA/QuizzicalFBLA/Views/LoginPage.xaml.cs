using QuizzicalFBLA.Config;
using QuizzicalFBLA.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuizzicalFBLA.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
		}

        private async void Button_Pressed(object sender, EventArgs e)
        {
            var authenticationService = DependencyService.Get<IAuthenticationService>();
            var authenticationResult = await authenticationService.Authenticate();

            if (!authenticationResult.IsError)
            {
                Dictionary<string, string> profile = authenticationResult.toProfile();

                // Store player profile in the Player singleton
                Player.Current.Nickname = profile["nickname"];
                Player.Current.Name = profile["name"];
                Player.Current.Sub = profile["sub"];
                Player.Current.AutoUsername = profile["auto_username"];
                Player.Current.AutoPassword = profile["auto_password"];

                await App.Current.MainPage.Navigation.PopModalAsync();
            }
        }
    }
}