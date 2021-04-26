using System;
using System.Collections.Generic;
using System.Text;

namespace Density
{
    public class Location
    {
        internal string Icao { get; set; }
        internal string Sourceicao { get; set; }
        internal string Destinationicao { get; set; }

        internal double Latitude { get; set; }
        internal double Longitude { get; set; }
        internal double Sourcelatitude { get; set; }
        internal double Sourcelongitude { get; set; }
        internal double Destinationlatitude { get; set; }
        internal double Destinationlongitude { get; set; }

        internal string CityName { get; set; }        
    }
}
