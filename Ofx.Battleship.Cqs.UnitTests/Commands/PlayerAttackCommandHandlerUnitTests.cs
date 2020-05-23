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
    public class PlayerAttackCommandHandlerUnitTests
    {
        [TestMethod]
        public async Task PlayerAttackCommandHandler_ValidRequest_Successful()
        {
            //mocking
            var mediator = new Mock<IMediator>();
            var playerRepository = new Mock<IPlayerRepository>();
            
            var player = new Player() { Id = new Guid(), GameId = new Guid() };
            var cancellationToken = new CancellationToken();
            playerRepository.Setup(r => r.GetAsync(player.Id)).Returns(Task.FromResult(player));
            IList<Player> list = new List<Player>() { player, new Player()};
            playerRepository.Setup(r => r.GetAll(It.IsAny<Guid>())).Returns(Task.FromResult(list));
            playerRepository.Setup(r => r.UnitOfWork.SaveChangesAsync(cancellationToken)).Returns(Task.FromResult(1));

            //call
            var playerAttackCommand = new PlayerAttackCommand() { Location = new LocationDto() { X=1, Y =2} };
            var acceptJobCommandHandler = new PlayerAttackCommandHandler(playerRepository.Object);
            var response = await acceptJobCommandHandler.Handle(playerAttackCommand, cancellationToken);

            //assertions
            Assert.AreEqual(response, false);
        }
    }
}
