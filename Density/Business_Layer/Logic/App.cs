using Density.Business_Layer.Logic;
using Density.Business_Layer.Repositories;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Density
{
    public class App : Application
    {
        //internal LocationClass locationClass { get; set; }
        //internal WeatherClass weatherClass { get; set; }
        //internal DensityClass densityClass { get; set; }

        //internal DensityHelper getDensity { get; set; }
        //internal LocationHelper getLocation { get; set; }
        //internal WeatherHelper getWeather { get; set; }
        internal HttpClient httpClient { get; set; }
        internal LayoutPage layoutPage { get; set; }
        internal NavigationPage nav { get; set; }


        public App()
        {
            layoutPage = new LayoutPage();

            layoutPage.LayoutCreate();

            nav = new NavigationPage(layoutPage);

            MainPage = nav;

            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "DensityApp");
        }
    }
}

