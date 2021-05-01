using Density.Business_Layer.Repositories;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace Density
{
    public class DistanceCalculator
    {
        private readonly string APIKey = ("AIzaSyA7_xqTgHHdFo6Fe19OmcVpkF7If4Vz8Zw");
      //  private string[] API_KEYS = { "", "AIzaSyA7_xqTgHHdFo6Fe19OmcVpkF7If4Vz8Zw" };

        private (double, double) sourcePosition { get; set; }
        private (double, double) destinationPosition { get; set; }



        private TimeSpan ParseTimespan(string time)
        {
            int days = 0;
            int hours = 0;
            int minutes = 0;
            int seconds = 0;
            int milliseconds = 0;

            string[] times = time.Split(' ');
            for (int i = 0; i < times.Length; i += 2)
            {
                int amount = Convert.ToInt32(times[i]);
                string type = times[i + 1].ToLower();

                if (type == "day" || type == "days")
                    days = amount;
                else if (type == "hour" || type == "hours")
                    hours = amount;
                else if (type == "min" || type == "mins")
                    minutes = amount;
                else if (type == "sec" || type == "secs")
                    seconds = amount;
            }

            return new TimeSpan(days, hours, minutes, seconds, milliseconds);
        }

  
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
   
       
        private string GetURL((double, double) sourcePosition, (double, double) destinationPosition, string mode, string apiKey)
        {           

            if (apiKey == "")
            {
                return string.Format(@"https://maps.googleapis.com/maps/api/distancematrix/json?units=metric&origins={0}&destinations={1}&mode={2}",
                                                       sourcePosition,
                                                       destinationPosition,
                                                       mode);
            }
            else
            {
                return string.Format(@"https://maps.googleapis.com/maps/api/distancematrix/json?units=metric&origins={0}&destinations={1}&mode={2}&key={3}",
                                                   sourcePosition,
                                                   destinationPosition,
                                                   mode,
                                                   apiKey);
            }
        }
        
        public TransportModel GetInfoForRoute(string mode, LocationClass sourceLocation, LocationClass destinationLocation)
        {         
            sourcePosition = (sourceLocation.lat, sourceLocation.lon);
            destinationPosition = (destinationLocation.lat, destinationLocation.lon);


            //int curAPIKeyIndex = 0;

            //while (curAPIKeyIndex < API_KEYS.Length)
            //{
                //API_KEYS[curAPIKeyIndex]
                string distanceURL = GetURL(
                    sourcePosition, 
                    destinationPosition, 
                    mode, 
                    APIKey);

                // Making and getting the GET response to get the data
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(distanceURL);
                request.Timeout = 10000;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream resStream = response.GetResponseStream();

                // Reading and parsing the data
                using (var reader = new StreamReader(resStream, Encoding.UTF8))
                {
                    try
                    {
                        string value = reader.ReadToEnd();
                        JObject json = JObject.Parse(value);
                        string modeDuration = (string)json["rows"][0]["elements"][0]["duration"]["text"];
                        string modeDistance = (string)json["rows"][0]["elements"][0]["distance"]["text"];

                        return new TransportModel()
                        {
                            ModeDuration = ParseTimespan(modeDuration).TotalMinutes,
                            ModeDistance = ParseDistance(modeDistance)
                        };
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Maps API Key error...");
                    }
                }
            //    curAPIKeyIndex++;
            //}
            return null;
        }
    }
}