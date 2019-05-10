using QuizzicalFBLA.Config;
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
using Xamarin.Essentials;

namespace QuizzicalFBLA.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuestionPage : ContentPage
    {
        CategoriesViewModel vm;
        private View[] buttons;
        private double WarningTrigger = 0.66;  // When progress is above 0.8 trigger a warning
        private double NextTrigger = 0;  // No need to set this
        private bool WarningTriggered = false;
        private bool AnsweredQuestion = false;
        private bool AnimationRunning = false;
        private CancellationTokenSource CancelContinueTokenSource = new CancellationTokenSource();
        private int correctAnswerIndex = 2;

        private Dictionary<string, ISimpleAudioPlayer> sounds;

        private bool gameInProgress = false;

        public QuestionPage()
        {
            InitializeComponent();

            //Allows this content page to use the CategoriesViewModel
            this.BindingContext = vm = CategoriesViewModel.Current;

            buttons = new View[] { Button1, Button2, Button3, Button4 };

            ring.OnAnimationCompleted += HandleAnimationCompleted;
            ring.OnProgressChanged += HandleProgressChanged;

            // Load sound effects
            sounds = new Dictionary<string, ISimpleAudioPlayer>();
            sounds.Add("correct", CrossSimpleAudioPlayer.CreateSimpleAudioPlayer());
            sounds.Add("incorrect", CrossSimpleAudioPlayer.CreateSimpleAudioPlayer());
            sounds.Add("timesup", CrossSimpleAudioPlayer.CreateSimpleAudioPlayer());
            sounds.Add("error", CrossSimpleAudioPlayer.CreateSimpleAudioPlayer());
            sounds.Add("clock", CrossSimpleAudioPlayer.CreateSimpleAudioPlayer());
            sounds.Add("button", CrossSimpleAudioPlayer.CreateSimpleAudioPlayer());
            sounds.Add("beep", CrossSimpleAudioPlayer.CreateSimpleAudioPlayer());


            sounds["correct"].Load("correct.wav");
            sounds["incorrect"].Load("incorrect.wav");
            sounds["timesup"].Load("negative_beeps.wav");
            sounds["error"].Load("error.wav");
            sounds["clock"].Load("ultradust_clock.wav");
            sounds["button"].Load("startSound.mp3");
            sounds["beep"].Load("beep.mp3");

            Player.Current.OnLogout += OnLoggedOut;
        }

        private void OnLoggedOut (object o, EventArgs e)
        {
            foreach (String key in sounds.Keys)
            {
                sounds[key].Stop();
            }

            AnimationRunning = false;
            ring.StopAnimation();

            if (CancelContinueTokenSource != null)
                CancelContinueTokenSource.Cancel();

            gameInProgress = false;
            
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            MusicPlayer.Current.Play("tenseMusic");

            if (gameInProgress)
            {
                if (!AnsweredQuestion)
                {
                    ring.AnimatedProgress = 1;
                    AnimationRunning = true;
                }
            }

            await Reset();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            if (CancelContinueTokenSource != null)
                CancelContinueTokenSource.Cancel();
            
            AnimationRunning = false;
            ring.StopAnimation();

        }

        private bool AnimationsEnabled
        {
            get
            {
                return Battery.EnergySaverStatus != EnergySaverStatus.On;
            }
        }

        public async Task Reset()
        {
            CancelContinueTokenSource = new CancellationTokenSource();

            if (gameInProgress) return;

            gameInProgress = true;

            AnsweredQuestion = false;
            ContinueButton.Opacity = 0;
            ContinueButton.IsVisible = false;

            wrongAnimation.IsVisible = false;
            checkAnimation.IsVisible = false;

            ring.Progress = 0;
            ring.AnimationLength = 30000;
            ring.AnimatedProgress = 1;
            AnimationRunning = true;
            WarningTriggered = false;
            
            List<Task> tasks = new List<Task>();
            for (int i = 0; i < buttons.Length; i++)
            {
                ViewExtensions.CancelAnimations(buttons[i]);
                View button = buttons[i];

                button.BackgroundColor = Color.FromHex("4E525D");

                if (AnimationsEnabled)
                {
                    int delay = i * 150;

                    button.Opacity = 0;
                    tasks.Add(Task.Run(async () =>
                    {
                        await button.TranslateTo(0, -60, 0).ContinueWith(async (d) =>
                            {
                                await Task.Delay(delay).ContinueWith(async (g) =>
                                {
                                    await Task.WhenAll(new Task[] {
                                    button.FadeTo(1, 800, Easing.Linear),
                                    button.TranslateTo(0, 0, 500, Easing.CubicInOut)
                                    });
                                });
                            });
                    }));
                }
                else
                {
                    button.Opacity = 1;
                }
            }

            await Task.WhenAll(tasks);
            
            return;
        }

        public void HandleAnimationCompleted(object sender, EventArgs args)
        {
            // TODO: Play the time has run out sound
            if (AnimationRunning && !AnsweredQuestion)
            {
                HandleAnswer(-1);
                sounds["timesup"].Play();
            }
            AnimationRunning = false;
        }

        
        public void HandleProgressChanged(object sender, EventArgs args)
        {
            if (!ring.AnimationIsRunning("Progress")) return;

            if (!WarningTriggered && ring.Progress >= WarningTrigger)
            {
                WarningTriggered = true;
                NextTrigger = WarningTrigger;

                // TODO: Play the time running out sound
            }

            if (WarningTriggered && ring.Progress >= NextTrigger)
            {
                double totalSeconds = (ring.AnimationLength / 1000);
                NextTrigger += 1 / totalSeconds;

                sounds["beep"].Play();
                if (AnimationsEnabled)
                {
                    Task.Run(async () =>
                    {
                        await ring.ScaleTo(1.05, 250, Easing.CubicIn);
                        await ring.ScaleTo(1.0, 250, Easing.CubicIn);
                    });
                }
            }
        }
        

        private async Task PulseElement(VisualElement element, CancellationToken cancellation)
        {
            if (!AnimationsEnabled) return;

            while (!cancellation.IsCancellationRequested)
            {
                await element.ScaleTo(1.1, 1000, Easing.SinIn);
                await element.ScaleTo(1.0, 1000, Easing.SinOut);
            }
        }

        public async void HandleAnswer(int answerNum)
        {
            uint delay = 500;
            int answerIndex = answerNum - 1;

            AnsweredQuestion = true;
            ring.StopAnimation();

            correctAnswerIndex = vm.Question.CorrectAnswer - 1;

            View CorrectButton = buttons[correctAnswerIndex];

            if (answerIndex == correctAnswerIndex)
            {
                checkAnimation.Play();
                wrongAnimation.IsVisible = false;
                checkAnimation.IsVisible = true;

                sounds["correct"].Play();

                vm.NumberCorrect++;
                vm.TotalPoints += 100 + (int)(50 * (1 - ring.Progress));
            }
            else
            {
                wrongAnimation.Play();
                checkAnimation.IsVisible = false;
                wrongAnimation.IsVisible = true;

                if (answerNum != -1)
                {
                    sounds["incorrect"].Play();
                    Vibration.Vibrate();
                }
            }

            List<Task> tasks = new List<Task>();

            if (answerNum != -1)
            {
                View PressedButton = buttons[answerIndex];

                // Pressed button animation
                if (AnimationsEnabled)
                {
                    tasks.Add(Task.Run(async () =>
                    {
                        await PressedButton.ScaleTo(1.025, 150, Easing.CubicInOut);
                        await PressedButton.ScaleTo(1.0, 150, Easing.CubicInOut);
                    }, CancelContinueTokenSource.Token));
                }
            }

            // Add handling for incorrect answers
            for (int i = 0; i < 4; i++)
            {
                if (i != correctAnswerIndex)
                {
                    View b = buttons[i];
                    if (AnimationsEnabled)
                    {
                        tasks.Add(Task.Run(async () =>
                        {
                            await b.ChangeBackgroundColorTo(Color.DarkRed, delay, Easing.CubicOut);
                            await b.FadeTo(0.2, delay * 2, Easing.CubicOut);
                        }, CancelContinueTokenSource.Token));
                    }
                    else
                    {
                        b.BackgroundColor = Color.DarkRed;
                        b.Opacity = 0.2;
                    }
                }
            }

            // Add handling for correct answer
            if (AnimationsEnabled)
            {
                tasks.Add(Task.Run(async () =>
                {
                    await CorrectButton.ChangeBackgroundColorTo(Color.DarkGreen, delay, Easing.CubicOut);
                    await CorrectButton.ChangeBackgroundColorTo(Color.YellowGreen, delay / 2, Easing.CubicOut);
                    await CorrectButton.ChangeBackgroundColorTo(Color.DarkGreen, delay / 2, Easing.CubicOut);
                    await CorrectButton.ChangeBackgroundColorTo(Color.YellowGreen, delay / 2, Easing.CubicOut);
                    await CorrectButton.ChangeBackgroundColorTo(Color.DarkGreen, delay, Easing.CubicOut);
                }, CancelContinueTokenSource.Token));
            }
            else
            {
                CorrectButton.BackgroundColor = Color.DarkGreen;
            }

            // Make continue button appear            
            try
            {
                if (tasks.Count > 0)
                    await Task.WhenAll(tasks);
            }
            catch (OperationCanceledException)
            {
                return;
            }


            ContinueButton.IsVisible = true;
            ContinueButton.IsEnabled = true;

            if (AnimationsEnabled)
            {
                await ContinueButton.TranslateTo(0, -30, 0, Easing.Linear);

                await Task.WhenAll(new Task[] {
                    ContinueButton.TranslateTo(0, 0, 500, Easing.CubicOut),
                    ContinueButton.FadeTo(1.0, 500, Easing.Linear)
                    ,PulseElement(ContinueButton, CancelContinueTokenSource.Token)
              });
            }
            else
            {
                ContinueButton.Opacity = 1;
            }


        }

        private void Button1_Tapped(object sender, EventArgs e)
        {
            if (!AnsweredQuestion)
                HandleAnswer(1);
        }

        private void Button2_Tapped(object sender, EventArgs e)
        {
            if (!AnsweredQuestion)
                HandleAnswer(2);
        }

        private void Button3_Tapped(object sender, EventArgs e)
        {
            if (!AnsweredQuestion)
                HandleAnswer(3);
        }

        private void Button4_Tapped(object sender, EventArgs e)
        {
            if (!AnsweredQuestion)
                HandleAnswer(4);
        }

      

        private async void ContinueButton_Tapped(object sender, EventArgs e)
        {
            CancelContinueTokenSource.Cancel();
            sounds["button"].Play();
            if (vm.CurrentQuestion < vm.Count - 1)
            {
                vm.CurrentQuestion++;
                gameInProgress = false;

                await Reset();
            }
            else
            {
                await Player.Current.RegisterScore(vm.TotalPoints);
                await Player.Current.AddCurrency(Currencies.TotalPoints, vm.TotalPoints);

                //Show ending page
                MasterDetailPage mdp = (MasterDetailPage)Application.Current.MainPage;
                mdp.Detail = new NavigationPage(new EndPage());
            }

        }

        //Loads the next question or brings the player to the end page if the quiz is over
        private async void NextQuestion(object sender, EventArgs e)
        {
            vm.ShowQuestion = true;

            if (vm.CurrentQuestion < vm.Count - 1)
            {
                vm.CurrentQuestion++;
            }
            else
            {
                await Player.Current.RegisterScore(vm.NumberCorrect);

                //Show ending page
                MasterDetailPage mdp = (MasterDetailPage)Application.Current.MainPage;
                mdp.Detail = new NavigationPage(new EndPage());
            }
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IBugReporter>().Trigger();
        }
    }
}