using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rock_Paper_Scissor.Models;
using Rock_Paper_Scissors.Service.Interfaces;

namespace Rock_Paper_Scissors.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost]
        public IActionResult Play([FromBody] GameSettings userChoice)
        {
            try
            {
                GameResult gameResult = _gameService.FetchGameResult(userChoice);

                return Ok(new { result = gameResult });
            } catch
            {
                // Log Error
                return BadRequest();
            }

        }

    }
}
