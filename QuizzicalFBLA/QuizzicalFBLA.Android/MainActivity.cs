using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Content;
using Android.OS;
//using Com.Instabug.Library;
//using Com.Instabug.Library.Invocation;

namespace QuizzicalFBLA.Droid
{
    /*
    [Activity(Label = "QuizzicalFBLA", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

            //new Instabug.Builder(???, "6c4ce2b08ac3afa29539f59017d374a9")
                //.SetInvocationEvent(InstabugInvocationEvent.Shake).Build();
        }
    }
	*/
	/*
    [Activity(Label = "QuizzicalFBLA", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }

        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);
        }

        public override void OnBackPressed()
        {
            if (Popup.SendBackPressed(base.OnBackPressed))
            {
                // Do something if there are some pages in the `PopupStack`
            }
            else
            {
                // Do something if there are not any pages in the `PopupStack`
            }
        }

    }
	*/
}