using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Com.Instabug.Library;
using Com.Instabug.Library.Invocation;
using LabelHtml.Forms.Plugin.Droid;

namespace QuizzicalFBLA.Droid
{
    [Activity(Label = "QuizzicalFBLA", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            HtmlLabelRenderer.Initialize();

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

            //new Instabug.Builder(this.Application, "6c4ce2b08ac3afa29539f59017d374a9", new[] { InstabugInvocationEvent.Shake });
            new Instabug.Builder(this.Application, "6c4ce2b08ac3afa29539f59017d374a9").SetInvocationEvent(InstabugInvocationEvent.Shake).Build();
        }
    }
}