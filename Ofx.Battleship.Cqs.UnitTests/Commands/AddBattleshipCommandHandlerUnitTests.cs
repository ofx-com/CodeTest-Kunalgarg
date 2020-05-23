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
    public class AddBattleshipCommandHandlerUnitTests
    {
        [TestMethod]
        public async Task AddBattleshipCommandHandler_ValidRequest_Successful()
        {
            //mocking
            var mediator = new Mock<IMediator>();
            var playerRepository = new Mock<IPlayerRepository>();
            var game = new Game() { Id = new Guid(), Players= new List<Player>() };
            var player = new Player() { Id = new Guid() };
            var cancellationToken = new CancellationToken();
            var addBattleshipCommand = new AddBattleshipCommand() { PlayerId= new Guid(), Location = new LocationDto() { X=1, Y=2} };
            playerRepository.Setup(r => r.GetAsync(addBattleshipCommand.PlayerId)).Returns(Task.FromResult(player));
            playerRepository.Setup(r => r.UnitOfWork.SaveChangesAsync(cancellationToken)).Returns(Task.FromResult(1));

            //call

            var acceptJobCommandHandler = new AddBattleshipCommandHandler(playerRepository.Object);
            var response = await acceptJobCommandHandler.Handle(addBattleshipCommand, cancellationToken);
            //assertions
            playerRepository.Verify(mock => mock.UnitOfWork.SaveChangesAsync(cancellationToken), Times.Once());
            Assert.AreEqual(response, true);
        }
    }
}
