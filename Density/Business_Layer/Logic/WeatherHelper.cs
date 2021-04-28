using Density.Business_Layer.Repositories;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

namespace Density.Business_Layer.Logic
{
    internal class WeatherHelper : App
    {

        internal async Task<WeatherClass> GetWeatherAsync(string icao)
        {
            if (weatherClass == null)
            { weatherClass = new WeatherClass();              
            }

            if (locationClass == null)
            {
                locationClass = new LocationClass();
                locationClass = getLocation.LookupLocation().Result;
            }
            locationClass.icao = icao;

            string weatherWebsite = String.Format("https://api.weather.gov/stations/{0}/observations/current", icao);
            string weather_From_Website_in_Json = await httpClient.GetStringAsync(weatherWebsite);

            JObject w = JObject.Parse(weather_From_Website_in_Json);
            weatherClass.AirTemperature = Convert.ToInt32(w.SelectToken("properties.temperature.value"));
            weatherClass.AirPressure = Convert.ToInt32(w.SelectToken("properties.barometricPressure.value"));

            return weatherClass;

        }
    }
}



