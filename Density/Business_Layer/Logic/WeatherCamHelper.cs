using Density.Business_Layer.Repositories;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Density.Business_Layer.Logic
{
    public class WeatherCamHelper
    {
        internal Dictionary<string, List<WeatherCamClass>> WeatherCam_Locations { get; set; }
        internal JArray weatherCamArray { get; set; }
        public WeatherCamHelper()
        {

            weatherCamArray = JArray.Parse(Density.Properties.Resources.WeatherCams);

            var airports = weatherCamArray
                .Select(x => x["airport"].ToString())
            .Distinct().OrderBy(x => x);


            WeatherCam_Locations = airports.Select(a => new
            {
                airport = a,
                webAddresses = weatherCamArray.Where(x => x["airport"].ToString() == a.ToString()).Select(x => new WeatherCamClass
                {
                    airport = x["airport"].ToString(),
                    webAddress = x["webaddress"].ToString()
                }).ToList()
            }).ToDictionary(s => s.airport, s => s.webAddresses);

        }

        internal IEnumerable<string> GetWeatherCams()
        {  return WeatherCam_Locations.Keys.OrderBy(k => k).ToList();  }

        internal List<WeatherCamClass> GetAirport(string airportName)
        {
            return WeatherCam_Locations
                  .Single(c => c.Key == airportName)
                  .Value;         
        }                             
    }
}