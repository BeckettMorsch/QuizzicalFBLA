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
    public partial class LeaderboardPage : ContentPage
    {
        public LeaderboardPage()
        {
            InitializeComponent();
            this.BindingContext = new LeaderBoardViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Load the posts
            LeaderBoardViewModel vm = (LeaderBoardViewModel)BindingContext;
            vm.RefreshCommand.Execute(null);
        }
    }
}