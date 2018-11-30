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

        }

        async private void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new QuestionPage());
        }
    }
}