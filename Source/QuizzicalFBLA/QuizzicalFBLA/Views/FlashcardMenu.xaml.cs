using MLToolkit.Forms.SwipeCardView.Core;
using QuizzicalFBLA.Controls;
using QuizzicalFBLA.Models;
using QuizzicalFBLA.Services;
using QuizzicalFBLA.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuizzicalFBLA.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FlashcardMenu : ContentPage
	{

        public FlashcardMenu()
        {
            InitializeComponent();

            this.BindingContext = this;
            
		}        

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IBugReporter>().Trigger();
        }
        

        private async void CategoryMenu_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            string selectedCategory = (string)e.Item;
            CategoryMenu.SelectedItem = null;

            await Navigation.PushAsync(new FlashcardPage(selectedCategory));
        }
    }
}