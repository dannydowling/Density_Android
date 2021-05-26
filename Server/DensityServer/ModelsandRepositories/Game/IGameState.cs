using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DensityServer.ModelsandRepositories.Game
{
    public interface IGameState
    {
        public GameModel StartNewGame(char[] targetWord, int numberOfTurns);
        public GameModel FinishGame(int elapsedTurns, char[] targetWord, char[] guessedLetters);
        public GameModel GuessLetter(char letter);
        public GameModel Increment_GameState(int gameState);

    }


}
