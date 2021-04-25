using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Density
{
    public class GetLocation : App
    {
        public Dictionary<string, List<Location>> Locations { get; protected set; }
        public JArray locationsArray { get; init; }

        #region Populate Values for the Pickers
        public void Init()
         {
            var jsonPositions = files.find("Positions.txt");
            JPositions = JArray.Parse(jsonPositions);
            var states = locationsArray.Select(x => x["state"].ToString()).Distinct().OrderBy(x => x);

            Locations = states.Select(s => new
            {
                StateName = s,
                Cities = locationsArray.Where(x => x["state"].ToString() == s
                         && !string.IsNullOrWhiteSpace(x["icao"].ToString()))
                                .Select(x => new Location
                                {

                                    //populate the Airport Class
                                    CityName = x["city"].ToString(),
                                    Icao = x["icao"].ToString(),
                                    Latitude = string.IsNullOrWhiteSpace(x["lat"].ToString())
                                    ? default : Convert.ToDouble(x["lat"]),
                                    Longitude = string.IsNullOrWhiteSpace(x["lon"].ToString())
                                    ? default : Convert.ToDouble(x["lon"])

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
        #endregion

        #region Figure out the current location
             

        protected async Task<string> GetIPAsync()
        {
            string IPwebsite = String.Format("https://icanhazip.com");
            string IP = await httpClient.GetStringAsync(IPwebsite);

            return IP.Replace("/n", "");
        }


        public async Task<string> LookupLocation()
        {
            string IP = await GetIPAsync();
            var url = String.Format("http://ip-api.com/json/{0}", IP);
            var locationurl = await httpClient.GetStringAsync(url);
            JObject reader = JObject.Parse(locationurl);
            JToken CityAssert = reader.SelectToken("city");
            location.CityName = CityAssert.ToString().Trim();
            return location.CityName;
        }
    

    #endregion

    #region Convert a City Name into something useable

    public string TranslateCity(string city)
    {
        var icaoJToken = locationsArray.First(x => String.Equals(x["city"].ToString(), city,
                                      StringComparison.InvariantCultureIgnoreCase)
                                      && !string.IsNullOrWhiteSpace(x["icao"].ToString()))["icao"];

        location.Icao = String.Format(icaoJToken.ToString());
        return location.Icao;
    }

    #endregion

    #region Convert an Icao Code into a Position

    public double? latitude(string icao)
    {
        if (string.IsNullOrWhiteSpace(location.Icao))
        { 
                LookupLocation(); 
                TranslateCity(location.CityName); 
            }

        var icaoJToken = locationsArray.First(x => String.Equals(x["icao"].ToString(), icao,
                                       StringComparison.InvariantCultureIgnoreCase)
                                       && !string.IsNullOrWhiteSpace(x["lat"].ToString()))["lat"];
        location.Latitude = Convert.ToDouble(icaoJToken);

        return location.Latitude;
    }

    public double? longitude(string icao)
    {
        if (string.IsNullOrWhiteSpace(location.Icao)) { LookupLocation(); TranslateCity(location.CityName); }
        var icaoJToken = locationsArray.First(x => String.Equals(x["icao"].ToString(), icao,
                                       StringComparison.InvariantCultureIgnoreCase)

                                       && !string.IsNullOrWhiteSpace(x["lon"].ToString()))["lon"];
        location.Longitude = Convert.ToDouble(icaoJToken);

        return location.Longitude;
    }
}

    #endregion  
}
