using Plugin.Share;
using QuizzicalFBLA.Models;
using QuizzicalFBLA.ViewModels;
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
    public partial class EndPage : ContentPage
    {
        CategoriesViewModel vm;

        public EndPage()
        {
            InitializeComponent();

            this.BindingContext = vm = CategoriesViewModel.Current;
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
            
            await CrossShare.Current.Share(new Plugin.Share.Abstractions.ShareMessage
            {
                Text = "I got " + vm.NumberCorrect + " out of 25 questions correct on QuizzicalFBLA!",
                Title = "QuizzicalFBLA Results"
                //, Url = "hyyps://www.youtube.com"
            });
        }
    }
}