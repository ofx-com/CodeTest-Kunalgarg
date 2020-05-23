using AutoMapper;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ofx.Battleship.Core.Dtos;
using Ofx.Battleship.Cqs.Commands;
using Ofx.Battleship.Domain.Aggregates.GameAggregate;
using Ofx.Battleship.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ofx.Battleship.Cqs.UnitTests.Commands
{
    [TestClass]
    public class CreateBoardCommandHandlerUnitTests
    {
        [TestMethod]
        public async Task CreateBoardCommandHandler_ValidRequest_Successful()
        {
            //mocking
            var mediator = new Mock<IMediator>();
            var automapper = new Mock<IMapper>();
            var gameRepository = new Mock<IGameRepository>();
            var game = new Game() { Id = new Guid(), Players= new List<Player>() };
            var cancellationToken = new CancellationToken();
            gameRepository.Setup(r => r.Add(game)).Returns(Task.FromResult(game));
            automapper.Setup(a => a.Map<GameDto>(It.IsAny<Game>())).Returns(new GameDto() { Id = game.Id, Players = new List<PlayerDto>() });
            gameRepository.Setup(r => r.UnitOfWork.SaveChangesAsync(cancellationToken)).Returns(Task.FromResult(1));

            //call
            var acceptJobCommand = new CreateBoardCommand() { };
            var acceptJobCommandHandler = new CreateBoardCommandHandler(gameRepository.Object, automapper.Object);
            var gameDto = await acceptJobCommandHandler.Handle(acceptJobCommand, cancellationToken);

            //assertions
            gameRepository.Verify(mock => mock.UnitOfWork.SaveChangesAsync(cancellationToken), Times.Once());
            Assert.AreEqual(game.Id, gameDto.Id);
            Assert.AreEqual(game.Players.Count, 0);
        }
    }
}
