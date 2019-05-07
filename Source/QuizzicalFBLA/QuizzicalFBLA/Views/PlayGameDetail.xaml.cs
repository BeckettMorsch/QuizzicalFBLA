using QuizzicalFBLA.Services;
using QuizzicalFBLA.ViewModels;
using QuizzicalFBLA.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.SimpleAudioPlayer;

namespace QuizzicalFBLA.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayGameDetail : ContentPage
    {
        private CancellationTokenSource CancelButtonAnimationTokenSource = new CancellationTokenSource();
        private ISimpleAudioPlayer buttonSound;

        public PlayGameDetail()
        {
            InitializeComponent();

            CategoriesViewModel.Current.Reset();

            BackgroundImage = "Background.png";

            buttonSound = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            buttonSound.Load("startSound.mp3");

        }

        //Resets the ViewModel if the page is loaded
        protected override void OnAppearing()
        {
            base.OnAppearing();

            CancelButtonAnimationTokenSource = new CancellationTokenSource();

            Logo.Opacity = 0;
            StartButton.Opacity = 0;

            Task.Run(async () =>
            {
                await Logo.TranslateTo(-App.Current.MainPage.Width, 0, 0, Easing.Linear)
                        .ContinueWith((t) =>
                        {
                            Logo.FadeTo(1, 750, Easing.CubicInOut);
                            Logo.TranslateTo(0, 0, 750, Easing.CubicInOut);
                        })
                        .ContinueWith((u) =>
                        {
                            Task.WhenAll(new Task[] {
                                StartButton.FadeTo(1, 1250, Easing.Linear),
                                StartButton.PulseElement(CancelButtonAnimationTokenSource.Token)
                            });
                        });
                
                
            });

            //Task.Run(() => StartButton.PulseElement(CancelButtonAnimationTokenSource.Token));
            
            CategoriesViewModel.Current.Reset(5);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            CancelButtonAnimationTokenSource.Cancel();
        }

        //Navigates to the Question page when the start button is tapped
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            buttonSound.Play();
            CancelButtonAnimationTokenSource.Cancel();

            MasterDetailPage mdp = (MasterDetailPage)Application.Current.MainPage;
            mdp.Detail = new NavigationPage(new QuestionPage());
        }

        //Navigates to the instructions page if the question mark is tapped
        async private void GoToHowToPlayPage(object sender, EventArgs e)
        {
            CancelButtonAnimationTokenSource.Cancel();

            await Navigation.PushAsync(new HowToPlayPage());
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            CancelButtonAnimationTokenSource.Cancel();

            DependencyService.Get<IBugReporter>().Trigger();
        }
    }
}