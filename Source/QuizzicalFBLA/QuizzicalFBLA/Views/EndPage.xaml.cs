using Plugin.SimpleAudioPlayer;
using QuizzicalFBLA.Models;
using QuizzicalFBLA.Services;
using QuizzicalFBLA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace QuizzicalFBLA.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EndPage : ContentPage
    {
        CategoriesViewModel vm;
        ISimpleAudioPlayer successSound;

        public EndPage()
        {
            InitializeComponent();

            this.BindingContext = vm = CategoriesViewModel.Current;

            successSound = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            successSound.Load("success.mp3");

            successSound.Play();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //Star.Play();
        }
        

        //Resets the quiz if the Retry button is tapped
        private void Button_Clicked(object sender, EventArgs e)
        {
            MainPage mp = (MainPage)Application.Current.MainPage;
            mp.Detail = new NavigationPage(new PlayGameDetail());

            vm.Reset();
        }

        //Allows the user to share how many questions they got correct if the Share button is tapped
        async private void Share_Clicked(object sender, EventArgs e)
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = "I got " + vm.NumberCorrect + " out of " + vm.Count + " questions correct on QuizzicalFBLA and earned " + vm.TotalPoints + " points!",
                Title = "QuizzicalFBLA Results"
            });
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IBugReporter>().Trigger();
        }
    }
}