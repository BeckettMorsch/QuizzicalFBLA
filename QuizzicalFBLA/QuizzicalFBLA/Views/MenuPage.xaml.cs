using QuizzicalFBLA.Config;
using QuizzicalFBLA.Models;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuizzicalFBLA.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        //Populates the Navigation Menu
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();

            this.BindingContext = Player.Current;

            menuItems = new List<HomeMenuItem>
            {
                //Creates the items in the Navigation Menu
                new HomeMenuItem {Id = MenuItemType.Play, Title="Play Game", Icon="menu_play.png" },
                new HomeMenuItem {Id = MenuItemType.LeaderBoard, Title="Leaderboard", Icon="menu_leaderboard.png"},
                new HomeMenuItem {Id = MenuItemType.BugReporting, Title="Report An Issue", Icon="menu_bug.png" },
                new HomeMenuItem {Id = MenuItemType.TermsOfService, Title="Terms of Service", Icon="menu_terms.png" },
                new HomeMenuItem {Id = MenuItemType.About, Title="About", Icon="menu_info.png" },
                new HomeMenuItem {Id = MenuItemType.Logout, Title="Sign out", Icon="menu_logout.png" }
            };

            ListViewMenu.ItemSelected += ListViewMenu_ItemSelected;
            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;

                ListViewMenu.SelectedItem = null;

                RootPage.IsPresented = false;

                await RootPage.NavigateFromMenu(id);
            };
        }

        private void ListViewMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListViewMenu.SelectedItem = null;
        }
    }
}