using Density.Business_Layer.Repositories;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Density
{
    public class DistanceCalculator
    {
        private (double, double) sourcePosition { get; set; }
        private (double, double) destinationPosition { get; set; }

        private double ParseDistance(string distance)
        {
            double kilometers = 0;
            double meters = 0;
            double centimeters = 0;
            double millimeters = 0;

            string[] distances = distance.Split(' ');               //there's a gap between distances sent in
            for (int i = 0; i < distances.Length; i += 2)           //a for loop on every second string.
            {                                                       // 11 km would be 11 and km as two iterations
                double amount = Convert.ToDouble(distances[i]);     //we convert the 11 into a double
                string type = distances[i + 1].ToLower();           //and we set the next iteration to lower case km

                if (type == "km")                                   //this is where we identify what we're dealing with
                    kilometers = amount;
                else if (type == "m")
                    meters = amount;
                else if (type == "cm")
                    centimeters = amount;
                else if (type == "mm")
                    millimeters = amount;
            }

            return kilometers + (meters / 1000) + (centimeters / 100000) + (millimeters / 1000000); //and we want it all in kilometers for now.
        }

        internal string getDurationOfRoute(string distance, double speedOfTravel)
        {
            double parsedDistance = ParseDistance(distance);        //send it to be converted
            return ((parsedDistance / speedOfTravel)/1.852).ToString(); //1.852 is how many kilometers an hour a knot is.
        }

        private string GetURL((double, double) sourcePosition, (double, double) destinationPosition, int mode)
        {
          
                JArray APIKey = JArray.Parse(Density.Properties.Resources.MapsAPIKey);
                string key = APIKey.Select(x => x["MapsAPI"].ToString()).FirstOrDefault();

                return string.Format("https://maps.googleapis.com/maps/api/distancematrix/json?units=metric&origins={0}&destinations={1}&mode={2}&key={3}", sourcePosition, destinationPosition, mode, key);
            
        }

        public async Task<TransportModel> GetInfoForRoute(int mode, LocationClass sourceLocation, LocationClass destinationLocation)
        {         
            sourcePosition = (sourceLocation.lat, sourceLocation.lon);
            destinationPosition = (destinationLocation.lat, destinationLocation.lon);

                string distanceURL = GetURL(
                    sourcePosition, destinationPosition, mode);

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "DensityApp");

            string response = await httpClient.GetStringAsync(distanceURL);
            
            JObject json = JObject.Parse(response);
            return json.ToObject<TransportModel>();
          
        }
    }
}