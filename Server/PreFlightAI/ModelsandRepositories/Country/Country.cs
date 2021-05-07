﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PreFlightAI.Shared
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        public string Name { get; set; }

    }
}
