using Density.Business_Layer.Repositories;
using System;
using System.Threading.Tasks;

namespace Density.Business_Layer.Logic
{
    internal class DensityHelper : App
    {        
        internal async Task<DensityClass> ConvertToDensity(WeatherClass weatherClass, LocationHelper getLocation, WeatherHelper getWeather, LocationClass locationClass,DensityClass densityClass)
        {

            if (weatherClass.AirPressure == 0)
            {
                if (string.IsNullOrEmpty(locationClass.icao))
                {
                    await getLocation.LookupLocation(locationClass);
                }                
                await getWeather.GetWeatherAsync(locationClass, weatherClass);
            }
                       

            weatherClass.AirTemperature *= 9;                //conversion to Farenheit
            weatherClass.AirTemperature /= 5;
            var TemperatureFarenheit = weatherClass.AirTemperature + 32;

            var pascalPressure = weatherClass.AirPressure /= 100;                   //Ambient air pressure at a temperature
            var expansionRate = 820.462 * TemperatureFarenheit;        //fuel expansion rate                   
            var expansion = expansionRate + pascalPressure;              //combine to give an expansion value that's specific

            var density = expansion / 15000;                                    //bulk modulus offset as a science tested value for general oils                   
            density = (((1.55 * density) + 254) / 38.5);            //This adjustment should be made to get values from the website database.
            density = Math.Round(density, 3);                       //this concatenates the returned value.
            densityClass.densityValue = density.ToString();

            return densityClass;
        }
    }
}
