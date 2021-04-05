using System;

namespace Density
{    
    public class StringHandler : App
    {
        public String city;        

        public async System.Threading.Tasks.Task<string> StringEvaluateAsync(string source)
        {
            source = source.Trim();
            
            if (!String.IsNullOrWhiteSpace(source))
            {
                
                if (source.Length > 4)
                {
                    city = source;                    
                    location.Icao =getLocation.TranslateCity(city);                    
                    return location.Icao;
                }
                if (source.Length == 4)
                {
                    location.Icao = source.ToUpperInvariant();
                    return location.Icao;
                }
                if (source.Length < 4)
                {
                    string city = await getLocation.LookupLocation();
                    location.Icao = getLocation.TranslateCity(city);
                    return location.Icao;
                }
            }
            return location.Icao;
        }                
    }
    
    
}

