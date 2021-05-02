using Density.Business_Layer.Repositories;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Density.Business_Layer.Logic
{
    public class AircraftHelper
    {
        internal Dictionary<string, double> Aircrafts { get; set; }
        internal JArray aircraftArray { get; set; }

        public AircraftHelper()
        {
            aircraftArray = JArray.Parse(Density.Properties.Resources.Aircraft);
            //find the aircraft by the tag names in the json
            var aircrafts = aircraftArray.Select(x => x["aircraft"].ToString()).Distinct().OrderBy(x => x);

            //select each one.
            Aircrafts = (Dictionary<string, double>)aircrafts.Select(s => new
            {
                AircraftName = s,
                AircraftSpeed = aircraftArray.Where(x => x["aircraft"].ToString() == s
                         && !string.IsNullOrWhiteSpace(x["speed"].ToString()))
                                .Select(x => Convert.ToDouble(x["speed"])
                                )
            });
        }
     

        //used to populate the picker on the page, selecting the aircraft
        internal IEnumerable<string> GetAircrafts()
        {
            return Aircrafts.Keys.OrderBy(k => k).ToList();
        }

       
        internal double GetSpeed(string aircraftName)
        {
            return Aircrafts.Single(c => c.Key == aircraftName).Value;
                 }

        internal AircraftClass GetAircraftFromName(string aircraftName)
        {
            JToken thisAircraftJToken = aircraftArray.Single(x => String.Equals(x["aircraft"].ToString(), aircraftName,
                                     StringComparison.InvariantCultureIgnoreCase));
            AircraftClass aircraftClass = thisAircraftJToken.ToObject<AircraftClass>();
            return aircraftClass;
        }
    }
}
