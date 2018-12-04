using System;
using Xamarin.Forms;
using QuizzicalFBLA.Services;
using QuizzicalFBLA.Android;
//using InstabugLib;
using Com.Instabug.Bug;

[assembly: Dependency(typeof(BugReporterDroid))]
namespace QuizzicalFBLA.Android
{
    public class BugReporterDroid : IBugReporter
    {
        public void Trigger()
        {
            BugReporting.Invoke();
        }
    }
}
