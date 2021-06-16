using System.Collections.Generic;
using System.Threading.Tasks;
using DensityServer.ModelsandRepositories.Manifest;

namespace DensityServer.Server.Services
{
    public interface IManifestDataService
    {
        Task<IEnumerable<ManifestModel>> GetAllManifests();
        Task<ManifestModel> GetManifestModelById(string Id);
        Task<ManifestModel> AddManifestModel(ManifestModel game);
        
        Task DeleteManifestModel(string Id);
        
    }
}
