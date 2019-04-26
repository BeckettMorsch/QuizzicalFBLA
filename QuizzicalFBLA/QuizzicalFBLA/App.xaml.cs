using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using QuizzicalFBLA.Views;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using QuizzicalFBLA.Config;
using GameSparks.NET.Infrastructure.Settings;
using System.Threading.Tasks;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace QuizzicalFBLA
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();


            MainPage = new MainPage();

            // If not currently logged in (Store authentication details somewhere)
            // MainPage.Navigation.PushModalAsync(new LoginPage());
            
            Task.Run(() => Player.Current.AuthenticateGameSparks());
        }

        protected override void OnStart()
        {
            AppCenter.Start(Secrets.VSAppCenterAndroid + ";" + Secrets.VSAppCenterIOS + ";" + Secrets.VSAppCenterUWP,
                             typeof(Analytics), typeof(Crashes));

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
