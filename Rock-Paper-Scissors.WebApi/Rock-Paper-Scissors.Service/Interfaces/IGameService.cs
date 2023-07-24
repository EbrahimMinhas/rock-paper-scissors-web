using Rock_Paper_Scissor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors.Service.Interfaces
{
    public interface IGameService
    {
        GameResult FetchGameResult(GameSettings userChoice);
    }
}
