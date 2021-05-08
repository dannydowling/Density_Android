using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DensityServer.Shared
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        public string Name { get; set; }

    }
}
