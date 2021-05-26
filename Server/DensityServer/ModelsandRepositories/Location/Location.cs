using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DensityServer.Shared
{
    [Table("airportModels", Schema = "Airports")]
    public class Location
    {

        public string country { get; set; }

        public string state { get; set; }

        public string city { get; set; }

        public string name { get; set; }

        public string icao { get; set; }

        public string lat { get; set; }

        public string lon { get; set; }

    }
}
