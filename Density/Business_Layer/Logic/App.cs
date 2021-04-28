﻿using Density.Business_Layer.Logic;
using Density.Business_Layer.Repositories;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Density
{
    public class App : Application
    {
        internal static LocationClass locationClass { get; set; }
        internal static WeatherClass weatherClass { get; set; }
        internal static DensityClass densityClass { get; set; }
        internal DensityHelper getDensity { get; set; }
        internal LocationHelper getLocation { get; set; }
        internal WeatherHelper getWeather { get; set; }
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

            locationClass = new LocationClass { city = "", icao = "", lat = 0, lon = 0, name = "", state = "" };
            weatherClass = new WeatherClass { AirTemperature = 0, AirPressure = 0 };
            densityClass = new DensityClass { densityValue = "" };
        }
    }
}
