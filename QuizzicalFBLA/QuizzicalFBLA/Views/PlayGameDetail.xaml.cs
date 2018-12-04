using QuizzicalFBLA.Services;
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
    public partial class PlayGameDetail : ContentPage
    {
        public PlayGameDetail()
        {
            InitializeComponent();

            CategoriesViewModel.Current.Reset();

            BackgroundImage = "Background.png";
        }

        //Resets the ViewModel if the page is loaded
        protected override void OnAppearing()
        {
            base.OnAppearing();

            CategoriesViewModel.Current.Reset();
        }

        //Navitgates to the Question page when the start button is tapped
        async private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            MasterDetailPage mdp = (MasterDetailPage)Application.Current.MainPage;
            mdp.Detail = new NavigationPage(new QuestionPage());
        }

        //Navigates to the instructions page if the question mark is tapped
        async private void GoToHowToPlayPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HowToPlayPage());
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IBugReporter>().Trigger();
        }
    }
}