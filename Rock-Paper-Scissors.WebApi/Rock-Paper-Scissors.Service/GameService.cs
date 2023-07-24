using Rock_Paper_Scissor.Models;
using Rock_Paper_Scissors.Service.Interfaces;
using Rock_Paper_Scissor.Models.Enums;
using Rock_Paper_Scissor.Models.Constants;

namespace Rock_Paper_Scissors.Service
{
    public class GameService : IGameService
    {
        private readonly string[] choices = { GamePlayerOptions.Rock, GamePlayerOptions.Paper, GamePlayerOptions.Scissors };

        public GameResult FetchGameResult(GameSettings userChoice)
        {
            if(userChoice == null || (userChoice.PlayerType == PlayerType.player && string.IsNullOrEmpty(userChoice.Choice)))
            {
               return new GameResult();
            }

            switch(userChoice.PlayerType)
            {
                case PlayerType.player:
                    return GetGameResult(userChoice.Choice, GetRandomChoice());
                case PlayerType.computer:
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
                result.Result = $"{userChoice} == {computerChoice}";
            }
            else if (
                (userChoice == GamePlayerOptions.Rock && computerChoice == GamePlayerOptions.Scissors) ||
                (userChoice == GamePlayerOptions.Paper && computerChoice == GamePlayerOptions.Rock) ||
                (userChoice == GamePlayerOptions.Scissors && computerChoice == GamePlayerOptions.Paper))
            {
                result.Winner = PlayerType.player;
                result.Result = $"{userChoice} > {computerChoice}";
            }
            else
            {
                result.Winner = PlayerType.computer;
                result.Result = $"{computerChoice} > {userChoice}";
            }

            return result;
        }
    }
}