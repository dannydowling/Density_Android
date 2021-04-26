using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Density
{
    public class App : Application
    {
        internal static LocationHelper getLocation { get; set; }
        internal static Location location { get; set; }
        internal static Weather weather { get; set; }
        internal HttpClient httpClient { get; set; }
        internal LayoutPage layoutPage { get; set; }
        internal NavigationPage nav { get; set; }


        public App()
        {
            //on start, create the main page
            layoutPage = new LayoutPage();
            layoutPage.LayoutCreate();

            nav = new NavigationPage(layoutPage);
            MainPage = nav;

            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders
                      .Add("Accept", "application/json");
            httpClient.DefaultRequestHeaders
                      .Add("User-Agent", "DensityApp");

        }


        protected override void OnStart()
        {
            Task.Factory.StartNew(async () =>
            {
                location = new Location();
                getLocation = new LocationHelper();
                location = await getLocation.LookupLocation();
            });

            Task.Factory.StartNew(async () =>
            {
                weather = new Weather();
                await weather.InitAsync();
            });

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }




    }

}

