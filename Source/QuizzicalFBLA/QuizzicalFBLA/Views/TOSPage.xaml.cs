using Microsoft.AppCenter;
using Microsoft.AppCenter.Crashes;
using QuizzicalFBLA.Services;
using QuizzicalFBLA.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuizzicalFBLA.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TOSPage : ContentPage
	{
        private TermsOfServiceViewModel vm;

		public TOSPage ()
		{
			InitializeComponent ();
            
            //Allows this content page to use the TermsOfService ViewModel
            this.BindingContext = vm = new TermsOfServiceViewModel();

		}

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IBugReporter>().Trigger();
        }
    }
}