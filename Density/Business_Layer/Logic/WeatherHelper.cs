using Density.Business_Layer.Repositories;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Density.Business_Layer.Logic
{
    public class WeatherHelper
    {
        HttpClient httpClient;

        internal async Task<WeatherClass> GetWeatherAsync( LocationClass locationClass, WeatherClass weatherClass)
        {
            if (locationClass == null)
            { locationClass = new LocationClass(); }

            if (httpClient == null)
            {
                httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                httpClient.DefaultRequestHeaders.Add("User-Agent", "DensityApp");
            }           

            string weatherWebsite = String.Format("https://api.weather.gov/stations/{0}/observations/current", locationClass.icao);
            string weather_From_Website_in_Json = await httpClient.GetStringAsync(weatherWebsite);

            JObject w = JObject.Parse(weather_From_Website_in_Json);
            if (w.SelectToken("properties.temperature.value") != null)
            {
                weatherClass.AirTemperature = Convert.ToInt32(w.SelectToken("properties.temperature.value"));

                if (w.SelectToken("properties.barometricPressure.value") != null)
                { weatherClass.AirPressure = Convert.ToInt32(w.SelectToken("properties.barometricPressure.value")); }
            }
            else
            {
                weatherClass.AirTemperature = 0;
                weatherClass.AirPressure = 0;
            }           

            return weatherClass;
        }
    }
}



