using Newtonsoft.Json.Linq;
using System;

namespace Density
{
    public class Weather : App
    { 
        public async System.Threading.Tasks.Task<String> GetWeatherAsync(String icao)
        {
            double webAirPressure = 0;
            double webAirTemperature = 0;
            double density = 0;
            try
            {
                if (!String.IsNullOrWhiteSpace(icao))
                {
                    using (var webClient = new System.Net.WebClient())
                    {
                        webClient.Headers.Add("Accept", "application / geo + json; version = 1");
                        webClient.Headers.Add("User-Agent", "Density App");
                        var weatherUrl = String.Format("https://api.weather.gov/stations/{0}/observations/current", icao);
                        string json = await webClient.DownloadStringTaskAsync(weatherUrl);
                        if (!string.IsNullOrEmpty(json))
                        {
                            JObject w = JObject.Parse(json);
                            webAirTemperature = Convert.ToInt32(w.SelectToken("properties.temperature.value"));
                            webAirPressure = Convert.ToInt32(w.SelectToken("properties.barometricPressure.value"));
                        }
                        else
                        {
                            throw new TimeoutException();
                        }
                    }
                }
            }
            catch (TimeoutException)
            {
                await App.Current.MainPage.DisplayAlert("The weather website is unreachable at this time.", "Weather.gov no response", "OK");
            }
            finally
            {
                if (webAirPressure != 0 && webAirTemperature != 0)
                {

                    webAirTemperature *= 9;                //conversion to Farenheit
                    webAirTemperature /= 5;
                    double TemperatureFarenheit = webAirTemperature + 32;

                    double pascalPressure = webAirPressure /= 100;                   //Ambient air pressure at a temperature
                    double expansionRate = 820.462 * TemperatureFarenheit;        //fuel expansion rate                   
                    double expansion = expansionRate + pascalPressure;              //combine to give an expansion value that's specific

                    density = expansion / 15000;                                    //bulk modulus offset as a science tested value for general oils                   
                    density = (((1.55 * density) + 254) / 38.5);            //This adjustment should be made to get values from the website database.
                    density = Math.Round(density, 3);                       //this concatenates the returned value.
                }
            }
            return density.ToString();
        }      
    }
}


