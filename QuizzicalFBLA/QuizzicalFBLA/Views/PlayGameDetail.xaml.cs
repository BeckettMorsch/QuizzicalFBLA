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

        protected override void OnAppearing()
        {
            base.OnAppearing();

            CategoriesViewModel.Current.Reset();
        }

        async private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            MasterDetailPage mdp = (MasterDetailPage)Application.Current.MainPage;
            mdp.Detail = new NavigationPage(new QuestionPage());
        }

        async private void GoToHowToPlayPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HowToPlayPage());
        }
    }
}