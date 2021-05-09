using System.Collections.Generic;
using System.Threading.Tasks;
using DensityServer.Shared;

namespace DensityServer.Server.Services
{
    public interface ICountryDataService
    {
        Task<IEnumerable<Country>> GetAllCountries();
        Task<Country> GetCountryById(int countryId);
    }
}
