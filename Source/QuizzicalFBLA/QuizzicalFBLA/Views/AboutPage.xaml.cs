using QuizzicalFBLA.Services;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuizzicalFBLA.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();

            BackgroundImage = "Background.png";
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IBugReporter>().Trigger();
        }
    }
}