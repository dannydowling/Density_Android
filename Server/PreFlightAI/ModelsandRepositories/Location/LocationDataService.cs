using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PreFlightAI.Shared;

namespace PreFlightAI.Server.Services
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

            var response = await _httpClient.PostAsync("api/location", locationJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Location>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async Task DeleteLocation(string icao)
        {
            await _httpClient.DeleteAsync($"api/location/{icao}");
        }

        public async Task<IEnumerable<Location>> GetAllLocations()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Location>>
                (await _httpClient.GetStreamAsync($"api/location"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Location> GetLocationById(string icao)
        {
            return await JsonSerializer.DeserializeAsync<Location>
                (await _httpClient.GetStreamAsync($"api/location{icao}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task UpdateLocation(Location location)
        {
            var locationJson =
                new StringContent(JsonSerializer.Serialize(location), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync("api/location", locationJson);
        }
    }
}
