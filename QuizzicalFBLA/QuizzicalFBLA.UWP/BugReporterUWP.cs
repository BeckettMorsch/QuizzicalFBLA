using System;
using Xamarin.Forms;
using QuizzicalFBLA.Services;
using QuizzicalFBLA.UWP;

[assembly: Dependency(typeof(BugReporterUWP))]
namespace QuizzicalFBLA.UWP
{
    public class BugReporterUWP : IBugReporter
    {
        public void Trigger()
        {
            // UWP doesn't have bug reporting
        }
    }
}
