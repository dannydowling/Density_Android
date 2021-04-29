using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Density;

[assembly: Xamarin.Forms.Dependency(typeof(BrowserLaunchActivity))]

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
