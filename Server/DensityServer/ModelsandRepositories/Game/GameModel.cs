using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DensityServer.ModelsandRepositories.Game
{
    [Table("gameModels", Schema = "Games")]
    public class GameModel
    {
        public Guid Id { get; set; }
        public char[] targetWord { get; set; }
        public char[] guessedLetters { get; set; }
        public enum gameState
        {
            no_letters, 
            one_letter,
            two_letters,
            three_letters,
            four_letters,
            five_letters,
            six_letters,
            seven_letters,
            eight_letters,
            nine_letters,
            ten_letters
        }
    }
}
