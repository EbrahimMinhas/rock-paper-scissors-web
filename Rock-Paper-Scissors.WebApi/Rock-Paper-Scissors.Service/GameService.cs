using Rock_Paper_Scissor.Models;
using Rock_Paper_Scissors.Service.Interfaces;
using Rock_Paper_Scissor.Models.Enums;

namespace Rock_Paper_Scissors.Service
{
    public class GameService : IGameService
    {
        private readonly string[] choices = { "rock", "paper", "scissors" };

        public GameResult FetchGameResult(GameSettings userChoice)
        {
            if(userChoice == null)
            {
                return null;
            }

            switch(userChoice.PlayerType)
            {
                case PlayerType.player:
                    return GetGameResult(userChoice.Choice, GetRandomChoice());
                default:
                    return GetGameResult(GetRandomChoice(), GetRandomChoice());
            }
        }
       
        private string GetRandomChoice()
        {
            Random random = new Random();
            int randomIndex = random.Next(choices.Length);
            return choices[randomIndex];
        }

        private GameResult GetGameResult(string userChoice, string computerChoice)
        {
            GameResult result = new GameResult { };

            if (userChoice == computerChoice)
            {
                result.Winner = PlayerType.none;
            }
            else if (
                (userChoice == "rock" && computerChoice == "scissors") ||
                (userChoice == "paper" && computerChoice == "rock") ||
                (userChoice == "scissors" && computerChoice == "paper"))
            {
                result.Winner = PlayerType.player;
            }
            else
            {
                result.Winner = PlayerType.computer;
            }


            return result;
        }
    }
}