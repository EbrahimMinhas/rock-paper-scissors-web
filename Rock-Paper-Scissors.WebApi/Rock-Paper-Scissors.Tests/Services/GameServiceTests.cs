using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rock_Paper_Scissor.Models;
using Rock_Paper_Scissor.Models.Enums;
using Rock_Paper_Scissors.Service;
using Moq;

namespace Rock_Paper_Scissors.Tests.Services
{
    [TestClass]
    public class GameServiceTests
    {
        private GameService _service;

        [TestInitialize]
        public void initialize()
        {
            _service = new GameService();
        }

        [TestMethod]
        public void FetchGameResultPvCTest()
        {
            // arrange
            GameSettings setting = new GameSettings
            {
                PlayerType = PlayerType.player,
                Choice = "rock"
            };

            // act
            var result = _service.FetchGameResult(setting);

            // assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsSuccess);

        }
    }
}
