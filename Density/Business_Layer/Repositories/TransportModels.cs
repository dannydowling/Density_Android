using System;
using System.Collections.Generic;
using System.Text;

namespace Density.Business_Layer.Repositories
{
   public class TransportModel
    {       

        // mode is one of the enumerated values supported by the API
       
            public double ModeDuration { get; set; }
         
            public double ModeDistance { get; set; }                

        public TransportType TransportType { get; set; }

        }
    }

public enum TransportType
{
    Walking = 0,
    Cycling = 1,
    Driving = 2,
    PublicTransit =3
}

