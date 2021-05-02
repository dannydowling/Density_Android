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
        internal Dictionary<string, List<AircraftClass>> Aircrafts { get; set; }
        internal JArray aircraftArray { get; set; }

        public AircraftHelper()
        {
            aircraftArray = JArray.Parse(Density.Properties.Resources.Aircraft);
            //find the aircraft by the tag names in the json
            var aircrafts = aircraftArray.Select(x => x["aircraft"].ToString()).Distinct().OrderBy(x => x);

            //select each one.
            Aircrafts = aircrafts.Select(s => new
            {
                AircraftName = s,
                AircraftSpeed = aircraftArray.Where(x => x["aircraft"].ToString() == s
                         ).Select(x => new AircraftClass
                         {
                             aircraftName = x["aircraft"].ToString(),
                             aircraftSpeed = Convert.ToDouble(x["speed"])
                         }
                                ).ToList()
            }).ToDictionary(s => s.AircraftName, s => s.AircraftSpeed);
         }
     

        //used to populate the picker on the page, selecting the aircraft
        internal IEnumerable<string> GetAircrafts()
        {
            return Aircrafts.Keys.OrderBy(k => k).ToList();
        }

       
        internal string GetSpeed(string aircraftName)
        {
            return Aircrafts.Single(c => c.Key == aircraftName).Value.ToString();
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
