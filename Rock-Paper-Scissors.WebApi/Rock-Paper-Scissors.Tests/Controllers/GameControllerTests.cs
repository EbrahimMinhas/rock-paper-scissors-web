using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Rock_Paper_Scissor.Models;
using Rock_Paper_Scissor.Models.Constants;
using Rock_Paper_Scissor.Models.Enums;
using Rock_Paper_Scissors.Service.Interfaces;
using Rock_Paper_Scissors.WebApi.Controllers;

namespace Rock_Paper_Scissors.Tests.Controllers
{
    [TestClass]
    public  class GameControllerTests
    {
        Mock<IGameService> _mockGameService;

        [TestInitialize]
        public void initialize() {
            _mockGameService = new Mock<IGameService>();
        }

        [TestMethod]
        public void TestPlayControllerSuccess()
        {

            //arrange
            GameSettings setting = new GameSettings { PlayerType = PlayerType.player, Choice = GamePlayerOptions.Rock };
            _mockGameService.Setup(x => x.FetchGameResult(It.IsAny<GameSettings>())).Returns(new GameResult { Winner= PlayerType.player, Result = "winner"});
            GameController controller = new GameController(_mockGameService.Object);

            //act
            var result = controller.Play(setting);

            //assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            OkObjectResult? okResult = result as OkObjectResult;
        }

        [TestMethod]
        public void TestPlayControllerError()
        {
            //arrange
            GameSettings setting = new GameSettings { PlayerType = PlayerType.player, Choice = GamePlayerOptions.Rock };
            _mockGameService.Setup(x => x.FetchGameResult(It.IsAny<GameSettings>())).Returns(new GameResult { Winner = PlayerType.player });
            GameController controller = new GameController(_mockGameService.Object);

            //act
            var result = controller.Play(setting);

            //assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            OkObjectResult? okResult = result as OkObjectResult;
        }

        [TestMethod]
        public void TestPlayControllerHandlesException()
        {

            //arrange
            _mockGameService.Setup(x => x.FetchGameResult(It.IsAny<GameSettings>())).Throws(new Exception());
            GameController controller = new GameController(_mockGameService.Object);

            //act
            var result = controller.Play(new GameSettings());

            //assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }


    }
}
