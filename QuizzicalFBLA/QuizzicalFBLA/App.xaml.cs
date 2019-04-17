using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using QuizzicalFBLA.Views;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

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
        }

        protected override void OnStart()
        {
             AppCenter.Start("android=b07e290b-6de6-47ba-96ee-b126f75815b5;" +
                  "uwp=ac278b47-a061-44e5-96c0-389f70f445b8;" +
                  "ios=74f30c0c-ab9a-480a-a785-d69ac8bd4283",
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
