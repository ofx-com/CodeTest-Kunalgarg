using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ofx.Battleship.Core.Dtos;
using Ofx.Battleship.Cqs.Commands;

namespace Ofx.Battleship.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BattleshipController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BattleshipController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost("CreateBoard")]
        public async Task<ActionResult<GameDto>> CreateBoard([FromBody] CreateBoardCommand createBoardCommand)
        {
            var commandResponse = await _mediator.Send(createBoardCommand);

            if (commandResponse != null)
            {
                return Ok(commandResponse);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPost("")]
        public async Task<ActionResult<bool>> AddBattleship([FromBody] AddBattleshipCommand addBattleshipCommand)
        {
            var commandResponse = await _mediator.Send(addBattleshipCommand);

            return Ok(commandResponse);

        }

        [HttpPost("attack")]
        public async Task<ActionResult<bool>> PlayerAttack([FromBody] PlayerAttackCommand playerAttackCommand)
        {
            var commandResponse = await _mediator.Send(playerAttackCommand);

            return Ok(commandResponse);

        }

    }
}
