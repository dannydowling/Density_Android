using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DensityServer.ModelsandRepositories.Game;
using DensityServer.Shared;

namespace DensityServer.Server.Services
{
    public class GameModelDataService : IGameDataService
    {
        private HttpClient _httpClient { get; set; }

        public GameModelDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GameModel> AddGameModel(GameModel game)
        {
            var gameJson =
                new StringContent(JsonSerializer.Serialize(game), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"/games/{0}", gameJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<GameModel>(
                    await _httpClient.GetStreamAsync(
                    string.Format($"/games/{0}", game.Id)));
            }

            return null;
        }

        public async Task DeleteGameModel(string Id)
        {
            await _httpClient.DeleteAsync($"/games/{Id}");
        }

        public async Task<IEnumerable<GameModel>> GetAllGames()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<GameModel>>
                (await _httpClient.GetStreamAsync($"/games"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<GameModel> GetGameModelById(string Id)
        {
            return await JsonSerializer.DeserializeAsync<GameModel>
                (await _httpClient.GetStreamAsync($"/games/{Id}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task UpdateGameModel(GameModel game)
        {
            var gameJson =
                new StringContent(JsonSerializer.Serialize(game), Encoding.UTF8, "application/json");

            await _httpClient.PatchAsync($"/games/{0}", gameJson);
        }
    }
}
