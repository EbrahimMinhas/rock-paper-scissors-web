using Rock_Paper_Scissor.Models.Enums;

namespace Rock_Paper_Scissor.Models
{
    public class GameResult
    {
        public PlayerType Winner { get; set; }
        public string Message  { get; set; }
        public string PlayerOneChoice { get; set; }
        public string PlayerTwoChoice { get; set; }

    }
}
