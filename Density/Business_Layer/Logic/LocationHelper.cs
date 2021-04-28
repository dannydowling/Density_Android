using Density.Business_Layer.Repositories;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Density
{
    public class LocationHelper : App
    {
        internal Dictionary<string, List<LocationClass>> Locations { get; set; }
        internal JArray locationsArray { get; set; }


        public LocationHelper()
        {
            if (locationClass == null)
            {  locationClass = new LocationClass();                
               locationClass = getLocation.LookupLocation().Result;
            }

            locationsArray = JArray.Parse(Density.Properties.Resources.Positions);
            var states = locationsArray.Select(x => x["state"].ToString()).Distinct().OrderBy(x => x);

            Locations = states.Select(s => new
            {
                StateName = s,
                Cities = locationsArray.Where(x => x["state"].ToString() == s
                         && !string.IsNullOrWhiteSpace(x["icao"].ToString()))
                                .Select(x => new LocationClass
                                {

                                    city = x["city"].ToString(),
                                    icao = x["icao"].ToString(),
                                    lat = Convert.ToDouble(x["lat"]),
                                    lon = Convert.ToDouble(x["lon"])
                                })
                                     .ToList()
            }).ToDictionary(s => s.StateName, s => s.Cities);
        }

        internal IEnumerable<string> GetStates()
        { 
            return Locations.Keys.OrderBy(k => k).ToList(); }

        internal IEnumerable<string> GetCities(string stateName)
        { return Locations.Single(c => c.Key == stateName).Value.Select(v => v.city).Distinct().OrderBy(c => c); }

        internal string GetIcao(string stateName, string cityName)
        { return Locations.Single(c => c.Key == stateName).Value.First(v => v.city == cityName).icao; }


        internal async Task<LocationClass> LookupLocation()
        {           
            var IP = await httpClient.GetStringAsync("https://icanhazip.com");
            IP.Replace("/n", "");
            var url = String.Format("http://ip-api.com/json/{0}", IP);
            var locationurl = await httpClient.GetStringAsync(url);
            JObject reader = JObject.Parse(locationurl);
            JToken thisLocationJToken = 
                locationsArray.Single(x => String.Equals(x["city"].ToString(), reader.SelectToken("city").ToString()));

            locationClass = thisLocationJToken.ToObject<LocationClass>();
            return locationClass;
        }


        internal LocationClass TranslateCity(string city)
        {
            JToken thisLocationJToken = locationsArray.Single(x => String.Equals(x["city"].ToString(), city,
                                      StringComparison.InvariantCultureIgnoreCase));
            locationClass = thisLocationJToken.ToObject<LocationClass>();
            return locationClass;
        }

        internal LocationClass GetLocationFromIcao(string icao)
        {
            JToken thisLocationJToken = locationsArray.Single(x => String.Equals(x["icao"].ToString(), icao,
                                     StringComparison.InvariantCultureIgnoreCase));
            locationClass = thisLocationJToken.ToObject<LocationClass>();
            return locationClass;
        }

        internal LocationClass longlat(string icao)
        {
            
            JToken thisLocationJToken = locationsArray.Single(x => String.Equals(x["icao"].ToString(), icao,
                                           StringComparison.InvariantCultureIgnoreCase));

            locationClass = thisLocationJToken.ToObject<LocationClass>();
            return locationClass;
        }        
    }
}
