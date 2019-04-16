using Microsoft.AppCenter.Analytics;
using QuizzicalFBLA.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuizzicalFBLA.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        //Implements Navigation Menu
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            Icon = "hamburger.png";

            MenuPages.Add((int)MenuItemType.Play, (NavigationPage)Detail);
        }

        //Loads the items on the Navigation Menu
        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Play:
                        MenuPages.Add(id, new NavigationPage(new PlayGameDetail()));
                        break;
                    case (int)MenuItemType.About:
                        MenuPages.Add(id, new NavigationPage(new AboutPage()));
                        break;
                    case (int)MenuItemType.TermsOfService:
                        MenuPages.Add(id, new NavigationPage(new TOSPage()));
                        break;
                    case (int)MenuItemType.BugReporting:
                        MenuPages.Add(id, new NavigationPage(new BugReportingPage()));
                        break;
                    case (int)MenuItemType.LeaderBoard:
                        MenuPages.Add(id, new NavigationPage(new LeaderboardPage()));
                        break;

                }
            }

            //Tracks navigation
            string pageTitle = ((MenuItemType)id).ToString();
            Analytics.TrackEvent("Visited " + pageTitle);

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                await newPage.PopToRootAsync();

                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}