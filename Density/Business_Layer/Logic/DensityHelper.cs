using Density.Business_Layer.Repositories;
using System;
using System.Threading.Tasks;

namespace Density.Business_Layer.Logic
{
    internal class DensityHelper : App
    {        
        internal async Task<DensityClass> ConvertToDensity(double AirTemperature, double AirPressure)
        {
            if (App.densityClass == null)
            {  App.densityClass = new DensityClass();  }

            if (weatherClass == null)
            {
                if (locationClass == null)
                {
                    getLocation = new LocationHelper();
                    await getLocation.LookupLocation();
                }
                getWeather = new WeatherHelper();
                await getWeather.GetWeatherAsync(App.locationClass.icao);
            }
                       

            AirTemperature *= 9;                //conversion to Farenheit
            AirTemperature /= 5;
            var TemperatureFarenheit = AirTemperature + 32;

            var pascalPressure = AirPressure /= 100;                   //Ambient air pressure at a temperature
            var expansionRate = 820.462 * TemperatureFarenheit;        //fuel expansion rate                   
            var expansion = expansionRate + pascalPressure;              //combine to give an expansion value that's specific

            var density = expansion / 15000;                                    //bulk modulus offset as a science tested value for general oils                   
            density = (((1.55 * density) + 254) / 38.5);            //This adjustment should be made to get values from the website database.
            density = Math.Round(density, 3);                       //this concatenates the returned value.
            App.densityClass.densityValue = density.ToString();

            return App.densityClass;          
        }
    }
}
