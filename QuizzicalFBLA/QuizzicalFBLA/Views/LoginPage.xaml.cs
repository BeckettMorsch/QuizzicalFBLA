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
            bool LoggedIn = await Player.Current.Login();

            if (LoggedIn)
            {
                await App.Current.MainPage.Navigation.PopModalAsync();
            }
        }
    }
}