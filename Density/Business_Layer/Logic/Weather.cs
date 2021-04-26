using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Density
{
    public class Weather : App
    {   
        internal double AirTemperature { get; set; }
        internal double AirPressure { get; set; }
        internal Dictionary<double, double> TempPressureDictionary { get; set; }

        public void Init() {
            //this will populate the dictionary with the current weather
            TempPressureDictionary = GetWeatherAsync(App.location.Icao).Result;
        }

        public async Task<Dictionary<double, double>> GetWeatherAsync(string icao)
        {
            if (!String.IsNullOrWhiteSpace(icao))
            {
                string weatherWebsite = String.Format("https://api.weather.gov/stations/{0}/observations/current", icao);
                string weather_From_Website_in_Json = await httpClient.GetStringAsync(weatherWebsite);


                if (!string.IsNullOrEmpty(weather_From_Website_in_Json))
                {
                    JObject w = JObject.Parse(weather_From_Website_in_Json);

                    TempPressureDictionary.Add(Convert.ToInt32(w.SelectToken("properties.temperature.value")), 
                                               Convert.ToInt32(w.SelectToken("properties.barometricPressure.value")));
                    
                    AirTemperature = Convert.ToInt32(w.SelectToken("properties.temperature.value"));
                    
                    AirPressure = Convert.ToInt32(w.SelectToken("properties.barometricPressure.value"));
                }                
            }
            return TempPressureDictionary;
        }

        internal string ConvertToDensity(double? AirPressure, double? AirTemperature, Dictionary<double?, double?> densityDictionary)
        {
            if (densityDictionary != null)
            {
                if (AirPressure == 0) //if the pressure isn't there, try looking it up by key
                {
                    densityDictionary.TryGetValue(AirTemperature, out AirPressure);
                }
                if (AirTemperature == 0) //if the key isn't there, remove it from the dictionary
                {
                    densityDictionary.Remove(0);
                    return "";
                }
            }

            if (AirPressure != null || AirTemperature != null)
            {
                this.AirPressure = AirPressure.Value;
                this.AirTemperature = AirTemperature.Value;
            }

                AirTemperature *= 9;                //conversion to Farenheit
                AirTemperature /= 5;
                var TemperatureFarenheit = AirTemperature + 32;

                var pascalPressure = AirPressure /= 100;                   //Ambient air pressure at a temperature
                var expansionRate = 820.462 * TemperatureFarenheit;        //fuel expansion rate                   
                var expansion = expansionRate + pascalPressure;              //combine to give an expansion value that's specific

                var density = expansion / 15000;                                    //bulk modulus offset as a science tested value for general oils                   
                density = (((1.55 * density) + 254) / 38.5);            //This adjustment should be made to get values from the website database.
                density = Math.Round(density.Value, 3);                       //this concatenates the returned value.


                return density.ToString();

            
        }      
    }
}


