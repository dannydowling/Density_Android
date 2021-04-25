using System;
using System.Collections.Generic;
using System.Text;

namespace Density
{
    public class Location
    {
        public string Icao { get; set; }
        public string Sourceicao { get; set; }
        public string Destinationicao { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Sourcelatitude { get; set; }
        public double Sourcelongitude { get; set; }
        public double Destinationlatitude { get; set; }
        public double Destinationlongitude { get; set; }

        public string CityName { get; set; }
        public string Sourcecity { get; set; }
        public string Destinationcity { get; set; }
    }
}
