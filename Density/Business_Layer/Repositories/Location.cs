using System;
using System.Collections.Generic;
using System.Text;

namespace Density
{
    public class Location
    {

        public string state { get; set; }

        public string city { get; set; }

        public string name { get; set; }

        public string icao { get; set; }

        public double lat { get; set; }

        public double lon { get; set; }

    }

    public static class SourceLocation 
    {
        public static string state { get; set; }

        public static string city { get; set; }

        public static string name { get; set; }
        public static string icao { get; set; }
        public static double lat { get; set; }
        public static double lon { get; set; }
    }

    public static class DestinationLocation
    {
        public static string state { get; set; }

        public static string city { get; set; }

        public static string name { get; set; }
        public static string icao { get; set; }
        public static double lat { get; set; }
        public static double lon { get; set; }
    }
}

