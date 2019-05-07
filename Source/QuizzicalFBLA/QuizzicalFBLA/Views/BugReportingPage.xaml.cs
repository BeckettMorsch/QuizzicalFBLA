using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using QuizzicalFBLA.Services;

namespace QuizzicalFBLA.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BugReportingPage : ContentPage
	{
		public BugReportingPage ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IBugReporter>().Trigger();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IBugReporter>().Trigger();
        }
    }
}