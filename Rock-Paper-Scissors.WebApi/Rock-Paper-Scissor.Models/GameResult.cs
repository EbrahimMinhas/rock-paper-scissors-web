using Rock_Paper_Scissor.Models.Enums;

namespace Rock_Paper_Scissor.Models
{
    public class GameResult
    {
        public PlayerType Winner { get; set; }
        public string Result  { get; set; }
        public bool IsSuccess => Result != null;
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
