using Density.Business_Layer.Repositories;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Density.Business_Layer.Logic
{
    public class DensityHelper
    {
        public event EventHandler<HydrometerMovedEventArgs> HydrometerMoved;

        internal DensityClass ConvertToDensity(WeatherClass weatherClass, DensityClass densityModel)
        {
            if (densityModel == null)
            {   densityModel = new DensityClass(); }

            if (weatherClass == null)
            {   weatherClass = new WeatherClass(); }

            var AirTemp_Temp = weatherClass.AirTemperature;
            var pascalPressure = weatherClass.AirPressure /= 100;                    //Ambient air pressure at a temperature
            AirTemp_Temp *= 9;                                                      //conversion to Fahrenheit
            AirTemp_Temp /= 5;
            var TemperatureFarenheit = AirTemp_Temp + 32;           
            var expansionRate = 820.462 * TemperatureFarenheit;                    //fuel expansion rate                   
            var expansion = expansionRate + pascalPressure;                       //combine to give an expansion value that's specific

            var density = Convert.ToInt32(expansion / 15000);         //bulk modulus offset as a science tested value for general oils

            //get the density to 480 at 1015 mB and 60 degrees before this to calibrate

            for (int i = 400; i*10 < density; )                   //start at 40, and start the density scale at 6.90
            {                                                    //we'll go until the i value is equal to density, moving by 1 each time.
                int decrementer = -100;                         //we're going to move by .1 density each iteration
                for (int f = 6900; ; decrementer--)              
                {
                    density = f;
                                                                             //can set a delay here to animate over a time later
                    HydrometerMoved += DensityPage.HydrometerScaled;
                }
            }

            densityModel.densityValue = density.ToString();

            return densityModel;
        }
    }

    public class HydrometerMovedEventArgs : EventArgs
    {
        public double ScaleFactor { get; set; }
    }
}
