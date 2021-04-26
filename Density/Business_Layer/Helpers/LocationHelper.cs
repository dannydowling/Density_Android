using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;



namespace Density
{
    public class LocationHelper : App
    {
        internal Dictionary<string, List<Location>> Locations { get; set; }
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
                                .Select(x => new Location
                                {

                                    CityName = x["city"].ToString(),
                                    Icao = x["icao"].ToString(),
                                    Latitude = Convert.ToDouble(x["lat"]),
                                    Longitude = Convert.ToDouble(x["lon"])
                                })
                                     .ToList()
            }).ToDictionary(s => s.StateName, s => s.Cities);
        }

        internal IEnumerable<string> GetStates()
        { return Locations.Keys.OrderBy(k => k).ToList(); }

        internal IEnumerable<string> GetCities(string stateName)
        { return Locations.Single(c => c.Key == stateName).Value.Select(v => v.CityName).Distinct().OrderBy(c => c); }

        internal string GetIcao(string stateName, string cityName)
        { return Locations.Single(c => c.Key == stateName).Value.First(v => v.CityName == cityName).Icao; }


        internal Location LookupLocation()
        {
            if (httpClient == null)
            {
                httpClient = new System.Net.Http.HttpClient();
            }
            var IP = httpClient.GetStringAsync("https://icanhazip.com").Result;
            IP.Replace("/n", "");
            var url = String.Format("http://ip-api.com/json/{0}", IP);
            var locationurl = httpClient.GetStringAsync(url).Result;
            JObject reader = JObject.Parse(locationurl);
            JToken thisLocationJToken = 
                locationsArray.Single(x => String.Equals(x["city"].ToString(), reader.SelectToken("city").ToString()));

            location = thisLocationJToken.ToObject<Location>();
            return location;
        }


        internal Location TranslateCity(string city)
        {
            JToken thisLocationJToken = locationsArray.Single(x => String.Equals(x["city"].ToString(), city,
                                      StringComparison.InvariantCultureIgnoreCase));
            location = thisLocationJToken.ToObject<Location>();
            return location;
        }

        internal Location GetLocationFromIcao(string icao)
        {
            JToken thisLocationJToken = locationsArray.Single(x => String.Equals(x["icao"].ToString(), icao,
                                     StringComparison.InvariantCultureIgnoreCase));
            location = thisLocationJToken.ToObject<Location>();
            return location;
        }

        internal Location longlat(string icao)
        {
            if (location == null) { LookupLocation(); }

            JToken thisLocationJToken = locationsArray.Single(x => String.Equals(x["icao"].ToString(), icao,
                                           StringComparison.InvariantCultureIgnoreCase));

            location = thisLocationJToken.ToObject<Location>();
            return location;
        }        
    }
}
