using Plugin.SimpleAudioPlayer;
using QuizzicalFBLA.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuizzicalFBLA.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Walkthrough : ContentPage
	{
        public ObservableCollection<Board> Boards { get; set; } = new ObservableCollection<Board>();
        private CancellationTokenSource TokenSource = new CancellationTokenSource();
        private ISimpleAudioPlayer buttonSound;

        public Walkthrough ()
		{

			InitializeComponent ();

            buttonSound = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            buttonSound.Load("startSound.mp3");

            Boards.Add(new Board
            {
                Title= "Welcome to Quizzical",
                Text = "Test your FBLA knowledge with over 100 questions in 5 quiz categories!",
                Animation = GetAnimation("4887-book.json", true),
                BackgroundColor =  Color.FromHex("#53BA92")
            });

            Boards.Add(new Board
            {
                Title = "Climb your way to the top",
                Text = "The leaderboard shows the top users who have accumulated the most points playing.  Where will you rank?",
                Animation = GetAnimation("677-trophy.json"),
                BackgroundColor = Color.FromHex("#2E8DE0")
            });

            Boards.Add(new Board
            {
                Title = "Make sure you study",
                Text = "Swipe through our intuitive flashcards for extra practice in any category you choose",
                Animation = GetAnimation("3520-light-bulb.json"),
                BackgroundColor = Color.FromHex("#CC2A2A")
            });

            Boards.Add(new Board
            {
                Title = "Share your results",
                Text = "Challenge your friends to beat your score as you soar to the level of FBLA genius",
                Animation = GetAnimation("4892-star.json"),
                BackgroundColor = Color.FromHex("#8481DB")
            });

            CV.ItemsSource = Boards;
            CV.Scrolled += CV_Scrolled;
        }

        private Lottie.Forms.AnimationView GetAnimation(String filename, bool autoplay = false)
        {
            return new Lottie.Forms.AnimationView
            {
                Animation = filename,
                Loop = false,
                AutoPlay = autoplay,
                IsVisible = true,
                Scale = 1.3,
                BackgroundColor = Color.Transparent,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.EndAndExpand,
                WidthRequest = 300,
                HeightRequest = 300
            };
        }

        private void CV_Scrolled(object sender, CarouselView.FormsPlugin.Abstractions.ScrolledEventArgs e)
        {
            int nextPosition = CV.Position;
            TokenSource.Cancel();

            if (e.Direction == CarouselView.FormsPlugin.Abstractions.ScrollDirection.Right)
                nextPosition++;
            else
                nextPosition--;

            if (nextPosition == Boards.Count)
                nextPosition--;
            else if (nextPosition < 0)
                nextPosition = 0;

            Lottie.Forms.AnimationView animation = Boards[nextPosition].Animation;

            animation.Scale = 1.3;

            TokenSource = new CancellationTokenSource();
            Task.Run(async () =>
            {
                await animation.ScaleTo(1.6, 10000, Easing.Linear);
            }, TokenSource.Token);
            
            animation.Play();
        }

        private void SignIn_Button_Clicked(object sender, EventArgs e)
        {
            buttonSound.Play();
            Preferences.Set("WatchedTutorial", true);
            MessagingCenter.Send<Walkthrough>(this, "GetStarted");
        }
    }
}
 