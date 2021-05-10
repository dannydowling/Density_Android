using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DensityServer.Shared;

namespace DensityServer.Server.Services
{
    public class LocationDataService : ILocationDataService
    {
        private readonly HttpClient _httpClient;

        public LocationDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Location> AddLocation(Location location)
        {
            var locationJson =
                new StringContent(JsonSerializer.Serialize(location), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"/location/{0}", locationJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Location>(
                    await _httpClient.GetStreamAsync(
                    string.Format($"/location/{0}", location.icao)));
            }

            return null;
        }

        public async Task DeleteLocation(string icao)
        {
            await _httpClient.DeleteAsync($"/location/{icao}");
        }

        public async Task<IEnumerable<Location>> GetAllLocations()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Location>>
                (await _httpClient.GetStreamAsync($"/location"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Location> GetLocationById(string icao)
        {
            return await JsonSerializer.DeserializeAsync<Location>
                (await _httpClient.GetStreamAsync($"/location/{icao}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task UpdateLocation(Location location)
        {
            var locationJson =
                new StringContent(JsonSerializer.Serialize(location), Encoding.UTF8, "application/json");

            await _httpClient.PatchAsync($"/location/{0}", locationJson);
        }
    }
}
