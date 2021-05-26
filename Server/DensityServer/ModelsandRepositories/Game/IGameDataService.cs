using System.Collections.Generic;
using System.Threading.Tasks;
using DensityServer.ModelsandRepositories.Game;
using DensityServer.Shared;

namespace DensityServer.Server.Services
{
    public interface IGameDataService
    {
        Task<IEnumerable<GameModel>> GetAllGames();
        Task<GameModel> GetGameModelById(string Id);
        Task<GameModel> AddGameModel(GameModel game);
        Task UpdateGameModel(GameModel game);
        Task DeleteGameModel(string Id);
        
    }
}
