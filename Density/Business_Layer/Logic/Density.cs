using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Density
{
    public class App : Application
    {
        internal static GetLocation getLocation { get; set; }
        internal static Location location { get; set; }
        internal JArray JPositions { get; set; }
        internal HttpClient httpClient { get; set; }

        internal LayoutPage layoutPage { get; set; }
        internal NavigationPage nav { get; set; }


        public App()
        {
            MainPage = nav;

        }


        protected override void OnStart()
        {
            //on start, create the main page
            layoutPage = new LayoutPage();
            layoutPage.LayoutCreate();
            nav = new NavigationPage(layoutPage);
            MainPage = nav;


            getLocation = new GetLocation();
            location = new Location();
            getLocation.Init();
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

