using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Com.Instabug.Library;
using Com.Instabug.Library.Invocation;
using LabelHtml.Forms.Plugin.Droid;
using Lottie.Forms.Droid;

namespace QuizzicalFBLA.Droid
{
    [Activity(Label = "QuizzicalFBLA", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, LaunchMode = LaunchMode.SingleTask)]
    [IntentFilter(
    new[] { Intent.ActionView },
    Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable },
    DataScheme = "com.eastonsd.quizzicalfbla", // App package name, ex: com.devisland.Auth0XamarinForms
    DataHost = "quizzical.auth0.com", // Auth0 domain, ex: devisland.eu.auth0.com
    DataPathPrefix = "/android/com.eastonsd.quizzicalfbla/callback")]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            HtmlLabelRenderer.Initialize();

            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            AnimationViewRenderer.Init();
            LoadApplication(new App());

            new Instabug.Builder(this.Application, "6c4ce2b08ac3afa29539f59017d374a9").Build();
            Instabug.Enable();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);

            Auth0.OidcClient.ActivityMediator.Instance.Send(intent.DataString);
        }
    }



}