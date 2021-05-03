﻿using Density.Business_Layer.Repositories;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Density.Business_Layer.Logic
{
    public class DensityHelper
    {
        
        internal DensityClass ConvertToDensity(WeatherClass weatherClass, DensityClass densityClass)
        {
            if (densityClass == null)
            {   densityClass = new DensityClass(); }

            if (weatherClass == null)
            {   weatherClass = new WeatherClass(); }

            var AirTemp_Temp = weatherClass.AirTemperature;
            var pascalPressure = weatherClass.AirPressure /= 100;                   //Ambient air pressure at a temperature
            AirTemp_Temp *= 9;                                                      //conversion to Fahrenheit
            AirTemp_Temp /= 5;
            var TemperatureFarenheit = AirTemp_Temp + 32;

           
            var expansionRate = 820.462 * TemperatureFarenheit;                     //fuel expansion rate                   
            var expansion = expansionRate + pascalPressure;                         //combine to give an expansion value that's specific

            var density = expansion / 15000;                                    //bulk modulus offset as a science tested value for general oils                   
            density = (((1.55 * density) + 254) / 38.5);            //This adjustment should be made to get values from the website database.
            density = Math.Round(density, 3);                       //this concatenates the returned value.
            densityClass.densityValue = density.ToString();

            return densityClass;
        }
    }
}
