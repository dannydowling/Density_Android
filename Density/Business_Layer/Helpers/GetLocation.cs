using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Density
{
    public class GetLocation : App
    {
        private Dictionary<string, List<Location>> Locations { get; set; }
        private JArray locationsArray { get; set; }

        public void Init()
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
                                    Latitude = string.IsNullOrWhiteSpace(x["lat"].ToString()) ? default : Convert.ToDouble(x["lat"]),
                                    Longitude = string.IsNullOrWhiteSpace(x["lon"].ToString()) ? default : Convert.ToDouble(x["lon"])
                                })
                                     .ToList()
            }).ToDictionary(s => s.StateName, s => s.Cities);
        }

        public IEnumerable<string> GetStates()
        { return Locations.Keys.OrderBy(k => k).ToList(); }

        public IEnumerable<string> GetCities(string stateName)
        { return Locations.Single(c => c.Key == stateName).Value.Select(v => v.CityName).Distinct().OrderBy(c => c); }

        public string GetIcao(string stateName, string cityName)
        { return Locations.Single(c => c.Key == stateName).Value.First(v => v.CityName == cityName).Icao; }


        public async Task<Location> LookupLocation()
        {
            var IP = await httpClient.GetStringAsync("https://icanhazip.com");
            IP.Replace("/n", "");
            var url = String.Format("http://ip-api.com/json/{0}", IP);
            var locationurl = await httpClient.GetStringAsync(url);
            JObject reader = JObject.Parse(locationurl);
            JToken thisLocationJToken = locationsArray.SelectToken(reader.SelectToken("city").ToString());
            return thisLocationJToken.ToObject<Location>();
        }


        public Location TranslateCity(string city)
        {
            JToken thisLocationJToken = locationsArray.First(x => String.Equals(x["city"].ToString(), city,
                                      StringComparison.InvariantCultureIgnoreCase));
            return thisLocationJToken.ToObject<Location>();
        }     

        public (double, double) longlat(string icao)
        {
            if (location == null) { LookupLocation(); }

            JToken thisLocationJtoken = locationsArray.First(x => String.Equals(x["icao"].ToString(), icao,
                                           StringComparison.InvariantCultureIgnoreCase));

            App.location = thisLocationJtoken.ToObject<Location>();                                           
            return (location.Longitude, location.Latitude);
        }
    }


}
