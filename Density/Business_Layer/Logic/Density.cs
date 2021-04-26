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

        }


        protected override void OnStart()
        {           
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders
                      .Accept
                      .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            getLocation = new LocationHelper();
            getLocation.Init();
            location = getLocation.LookupLocation();

            weather = new Weather();            
            weather.InitAsync();
            

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

