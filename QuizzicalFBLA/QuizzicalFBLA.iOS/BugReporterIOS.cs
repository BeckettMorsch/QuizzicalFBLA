using System;
using Xamarin.Forms;
using QuizzicalFBLA.Services;
using QuizzicalFBLA.iOS;
using InstabugLib;

[assembly: Dependency(typeof(BugReporterIOS))]
namespace QuizzicalFBLA.iOS
{
    public class BugReporterIOS : IBugReporter
    {
        public void Trigger()
        {
            IBGBugReporting.Invoke();
        }
    }
}
