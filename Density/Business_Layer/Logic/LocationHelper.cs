using Density.Business_Layer.Repositories;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Density
{
    public class LocationHelper
    {
        internal Dictionary<string, List<LocationClass>> Locations { get; set; }
        internal JArray locationsArray { get; set; }
        public LocationHelper()
        {
            
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
                                    name = x["name"].ToString(),
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
        { return Locations.Single(c => c.Key == stateName).Value.Select(v => v.city).OrderBy(c => c); }

        internal IEnumerable<string> GetAirports(string stateName)
        { return Locations.Single(c => c.Key == stateName).Value.Select(v => v.name).OrderBy(c => c); }

        internal IEnumerable<LocationClass> GetIcaoLocations(string stateName, string cityName)
        { return Locations.Single(c => c.Key == stateName).Value.TakeWhile(v => v.city == cityName); }

        internal string GetIcaoFromAirport (string stateName, string airportName)
        {
            return Locations.Single(c => c.Key == stateName).Value.Single(v => airportName == v.name).icao;
        }


        internal async Task<LocationClass> LookupLocation(LocationClass locationClass)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "DensityApp");

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


        internal LocationClass TranslateCity(LocationClass locationClass, string city)
        {
            JToken thisLocationJToken = locationsArray.Single(x => String.Equals(x["city"].ToString(), city,
                                      StringComparison.InvariantCultureIgnoreCase));
            locationClass = thisLocationJToken.ToObject<LocationClass>();
            return locationClass;
        }

        internal LocationClass GetLocationFromIcao(LocationClass locationClass)
        {
            JToken thisLocationJToken = locationsArray.Single(x => String.Equals(x["icao"].ToString(), locationClass.icao,
                                     StringComparison.InvariantCultureIgnoreCase));
            locationClass = thisLocationJToken.ToObject<LocationClass>();
            return locationClass;
        }

        internal LocationClass longlat(LocationClass locationClass, string icao)
        {
            
            JToken thisLocationJToken = locationsArray.Single(x => String.Equals(x["icao"].ToString(), icao,
                                           StringComparison.InvariantCultureIgnoreCase));

            locationClass = thisLocationJToken.ToObject<LocationClass>();
            return locationClass;
        }        
    }
}
