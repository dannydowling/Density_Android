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
            var states = locationsArray
                .Select(x => x["state"]             //select every state
                .ToString())                        //as a string
                .Distinct()                         //one of each
                .OrderBy(x => x);                   //and set them in order

            Locations = states.Select(s => new                          //select a new string from the collection of states                               
            {
                StateName = s,                                          //set the state name to be the entry in the states collection
                Cities = locationsArray                                 
                .Where(x => x["state"]                                  //the cities are where the state name matches
                .ToString() == s                                        //as a string to the state
                         && !string.IsNullOrWhiteSpace(x["icao"]        //and there is a valid icao code
                         .ToString()))                                  //as a string
                                .Select(x => new LocationClass          //so we make a new location for the city
                                {
                                    city = x["city"].ToString(),        //the name of the city matches the city tag
                                    icao = x["icao"].ToString(),        //the icao code matches the icao tag
                                    name = x["name"].ToString(),        //the name of the airport matches the name tag
                                    lat = Convert.ToDouble(x["lat"]),   //the latitude matches the lat tag
                                    lon = Convert.ToDouble(x["lon"])    //the longitude matches the lon tag
                                })
                                     .ToList()                          //set the locations into a list
            }).ToDictionary(s => s.StateName, s => s.Cities);           //into a dictionary of statename and a list of locations called cities
        }

        internal IEnumerable<string> GetStates()
        { 
            return Locations.Keys.OrderBy(k => k).ToList(); }

        internal IEnumerable<string> GetCities(string stateName)
        { return Locations
                .Single(c => c.Key == stateName)    //pick a single state
                .Value                              //and the value in that state
                .Select(v => v.city)                //that matches a city value
                .Distinct()                         //but only one of each
                .OrderBy(c => c); }                 //and set them in order

        internal IEnumerable<string> GetAirports(string stateName)
        { return Locations
                .Single(c => c.Key == stateName)                //pick a single state
                .Value                                          //and the value in that state
                .Select(v => v.name)                            //that matches an airport name
                .OrderBy(c => c); }                             //and set them in order

        internal IEnumerable<string> GetAirports(string stateName, string cityName)
        { return Locations
                .Single(c => c.Key == stateName)                //pick a single state
                .Value                                          //and the value in that state
                .Where(v => v.city == cityName)                 //with a condition that the city is the city passed in
                .Distinct()                                     //one of each
                .Select(v => v.name)                            //where the value matches an airport name
                .OrderBy(c => c); }                             //and set them in order

        internal string GetIcaoFromAirport (string stateName, string airportName)
        {
            return Locations                                    
                .Single(c => c.Key == stateName)                //pick a single state 
                .Value                                          //and the value in that state
                .Single(v => airportName == v.name)             //where the airport matches the value
                .icao;                                          //return the icao string
        }


        internal async Task<LocationClass> LookupLocation(LocationClass locationClass)
        {
            var httpClient = new HttpClient();                                          //create an http client
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");         //accepting json headers
            httpClient.DefaultRequestHeaders.Add("User-Agent", "DensityApp");           //identifying correctly

            var IP = await httpClient.GetStringAsync("https://icanhazip.com");          //get the public facing IP address
            IP.Replace("/n", "");                                                       //erasing any new line character
            var url = String.Format("http://ip-api.com/json/{0}", IP);                  //set up a string to look up the location
            var locationurl = await httpClient.GetStringAsync(url);                     //and set the http client to get it
            JObject reader = JObject.Parse(locationurl);                                //we need to parse json for this
            JToken thisLocationJToken =                                                 //and we'll do that by token
                locationsArray                                                          //so we load up our list of locations
                .Single(x => String.Equals(x["city"]                                    //and find the city
                .ToString(), reader.SelectToken("city")                                 //that matches the token from the http client
                .ToString()));                                                          //conversion to JSON

            locationClass = thisLocationJToken.ToObject<LocationClass>();               //our location class is now that location
            return locationClass;                                                       //so we'll return that
        }


        internal LocationClass TranslateCity(LocationClass locationClass, string city)
        {
            JToken thisLocationJToken = locationsArray                                  
                .Single(x => String.Equals(x["city"]
                .ToString(), 
                city,                                                               //match the city to the city tag
                StringComparison.InvariantCultureIgnoreCase));
            locationClass = thisLocationJToken.ToObject<LocationClass>();           //and convert that to a location class                     
            return locationClass;                                                   //which is what is returned
        }

        internal LocationClass GetLocationFromIcao(LocationClass locationClass)
        {
            JToken thisLocationJToken = locationsArray
                .Single(x => String.Equals(x["icao"]
                .ToString(), 
                locationClass.icao,                                                 //match the icao code to the icao tag
                StringComparison.InvariantCultureIgnoreCase));
            locationClass = thisLocationJToken.ToObject<LocationClass>();           //and return the location class back more populated
            return locationClass;
        }
    }
}
