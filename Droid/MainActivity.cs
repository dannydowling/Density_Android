using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using static Density.LayoutPage;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Density.Density;

[assembly: Xamarin.Forms.Dependency(typeof(BrowserLaunchActivity))]

namespace Density
{

    [Activity(Label = "Density", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.FullUser)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            Xamarin.FormsMaps.Init(this, bundle);

            LoadApplication(new App());

        }
    }

     
namespace Density
    {
        [Activity(Label = "FlightRadar")]
        public class BrowserLaunchActivity : ILaunchBrowserPage
        {
            public void StartBrowser(double lat, double lon)
            {
                Android.Net.Uri browserIntentUri = Android.Net.Uri.Parse("https://www.flightradar24.com/" + lat + "," + lon);
                Intent browserIntent = new Intent(Intent.ActionView);
                browserIntent.SetData(browserIntentUri);
                browserIntent.SetPackage("com.android.chrome");
                Forms.Context.StartActivity(browserIntent);
            }
        }
    }    
}


   

