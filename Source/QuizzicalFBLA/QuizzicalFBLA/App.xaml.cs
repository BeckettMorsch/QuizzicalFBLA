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
using Xamarin.Essentials;
using QuizzicalFBLA.Models;
using QuizzicalFBLA.Helpers;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace QuizzicalFBLA
{
    public partial class App : Application
    {
        public MainPage MainApplicationPage { get; set; }

        public App()
        {
            InitializeComponent();

            MainApplicationPage = new MainPage();
            MainApplicationPage.Appearing += MainApplicationPage_Appearing;

            MessagingCenter.Subscribe<Walkthrough>(this, "GetStarted", (sender) => {

                Application.Current.MainPage = MainApplicationPage;

            });

#if DEBUG
            bool watchedTutorial = false;
#else
            bool watchedTutorial = Preferences.Get("WatchedTutorial", false);
#endif

            if (watchedTutorial)
            {
                MainPage = MainApplicationPage;
            }
            else
            {
                MainPage = new Walkthrough();
            }

            
        }

        private void MainApplicationPage_Appearing(object sender, EventArgs e)
        {
            // When the main application appears we should check to see if the user is logged in
            Xamarin.Forms.Device.BeginInvokeOnMainThread(async () =>
            {
                await LoginCheck();
            });
        }

        public async Task LoginCheck ()
        {
            // If not currently logged in (Store authentication details somewhere)
            if (!Player.Current.LoggedIn && Xamarin.Forms.Device.RuntimePlatform != Xamarin.Forms.Device.UWP)
            {
                await Application.Current.MainPage.Navigation.PushModalAsync(new LoginPage());
            }
            else
                await Player.Current.AuthenticateGameSparks();

        }

        protected override void OnStart()
        {
            AppCenter.Start(Secrets.VSAppCenterAndroid + ";" + Secrets.VSAppCenterIOS + ";" + Secrets.VSAppCenterUWP,
                             typeof(Analytics), typeof(Crashes));

            MusicPlayer.Current.Play("daftCat");
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            MusicPlayer.Current.Pause();
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
            MusicPlayer.Current.Resume();
        }
    }
}
