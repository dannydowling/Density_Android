using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DensityServer.ModelsandRepositories.Manifest;
using static DensityServer.ModelsandRepositories.Manifest.ManifestModel;

namespace DensityServer.Server.Services
{
    public class ManifestModelDataService : IManifestDataService
    {
        private HttpClient _httpClient { get; set; }
        public ManifestModelDataService(HttpClient httpClient)
        { _httpClient = httpClient; }

        public EventHandler<ManifestStateChangedEventArgs> manifestChanged { get; set; }

        public async Task<ManifestModel> AddManifestModel(ManifestModel manifest)
        {
            var manifestJson = new StringContent(JsonSerializer.Serialize(manifest), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"/manifests/{0}", manifestJson);
            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<ManifestModel>(
                      await _httpClient.GetStreamAsync(
                      string.Format($"/manifests/{0}", manifest.Id)));
            }
            return null;
        }

        public async Task DeleteManifestModel(string Id)
        {
            await _httpClient.DeleteAsync($"/manifests/{Id}");
        }

        public async Task<IEnumerable<ManifestModel>> GetAllManifests()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<ManifestModel>>
                (await _httpClient.GetStreamAsync($"/manifests"),
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<ManifestModel> GetManifestModelById(string Id)
        {
            return await JsonSerializer.DeserializeAsync<ManifestModel>
                (await _httpClient.GetStreamAsync($"/manifests/{Id}"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

            //ready,
            //changes_pending,
            //read_only,
            //write_only,
            //final

        public async Task<ManifestModel> ReadManifestEnum(string Id)
        {
            //get manifest by its ID
            ManifestModel manifest =  await JsonSerializer.DeserializeAsync<ManifestModel>
                 (await _httpClient.GetStreamAsync($"/manifests/{Id}"),
                 new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
  
            //convert the integer being stored into the enum
        StateEnum dbManifestState = (StateEnum)manifest.manifestState;

           //raise an event that shows what state the manifest is now in.
            manifestChanged?.Invoke(this, new ManifestStateChangedEventArgs { ManifestState = ((int)dbManifestState) });

            switch (dbManifestState)
            {
                case StateEnum.ready:
                     manifest.ready = true;                   
                    break;
                case StateEnum.changes_pending:
                    manifest.changes_pending = true;
                    break;
                case StateEnum.read_only:
                    manifest.read_only = true;
                    break;
                case StateEnum.write_only:
                    manifest.write_only = true;
                    break;
                case StateEnum.final:
                    manifest.final = true;
                    break;
                default:
                    break;
            }
        }
        public class ManifestStateChangedEventArgs : EventArgs
        {
            public int ManifestState { get; set; }
        }


    }
}


