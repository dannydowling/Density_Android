using Density.Business_Layer.Repositories;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

namespace Density.Business_Layer.Logic
{
    internal class WeatherHelper : App
    {
        internal async Task<WeatherClass> GetWeatherAsync(LocationClass locationClass, WeatherClass weatherClass)
        {

            if (weatherClass.AirPressure == 0)
            { weatherClass = new WeatherClass();              
            }
            string weatherWebsite = String.Format("https://api.weather.gov/stations/{0}/observations/current", locationClass.icao);
            string weather_From_Website_in_Json = await httpClient.GetStringAsync(weatherWebsite);

            JObject w = JObject.Parse(weather_From_Website_in_Json);
            weatherClass.AirTemperature = Convert.ToInt32(w.SelectToken("properties.temperature.value"));
            weatherClass.AirPressure = Convert.ToInt32(w.SelectToken("properties.barometricPressure.value"));

            return weatherClass;
        }
    }
}



