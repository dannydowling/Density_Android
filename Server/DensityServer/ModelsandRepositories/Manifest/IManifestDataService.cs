using System.Collections.Generic;
using System.Threading.Tasks;
using DensityServer.ModelsandRepositories.Game;
using DensityServer.ModelsandRepositories.Manifest;
using DensityServer.Shared;
using DocumentFormat.OpenXml.Packaging;

namespace DensityServer.Server.Services
{
    public interface IManifestDataService
    {
        Task<IEnumerable<ManifestModel>> GetAllManifests();
        Task<ManifestModel> GetManifestModelById(string Id);
        Task<ManifestModel> AddManifestModel(ManifestModel game);
        Task UpdateManifestModel(ManifestModel manifest, WorksheetPart newWorkSheet);
        Task DeleteManifestModel(string Id);
        
    }
}
