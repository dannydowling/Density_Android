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

            string[] distances = distance.Split(' ');
            for (int i = 0; i < distances.Length; i += 2)
            {
                double amount = Convert.ToDouble(distances[i]);
                string type = distances[i + 1].ToLower();

                if (type == "km")
                    kilometers = amount;
                else if (type == "m")
                    meters = amount;
                else if (type == "cm")
                    centimeters = amount;
                else if (type == "mm")
                    millimeters = amount;
            }

            return kilometers + (meters / 1000) + (centimeters / 100000) + (millimeters / 1000000);
        }

        internal string getDurationOfRoute(string distance, double speedOfTravel)
        {
            double parsedDistance = ParseDistance(distance);
            return (parsedDistance / speedOfTravel).ToString();
        }


        private string GetURL((double, double) sourcePosition, (double, double) destinationPosition, string mode)
        {
            if (Density.Properties.Resources.Keys != null)
            {
                JArray APIKey = JArray.Parse(Density.Properties.Resources.Keys);
                APIKey.Select(x => x["MapsAPI"].ToString());

                return string.Format(@"https://maps.googleapis.com/maps/api/distancematrix/json?units=metric&origins={0}&destinations={1}&mode={2}&key={3}", sourcePosition, destinationPosition, mode, APIKey);
            }

            return "";
        }

        public async Task<TransportModel> GetInfoForRoute(string mode, LocationClass sourceLocation, LocationClass destinationLocation)
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