using Api.Common;
using Api.Dtos;
using Api.Models.Card;
using AutoMapper;
using DotNetStarter.Commands.Cards.Create;
using DotNetStarter.Commands.Cards.Delete;
using DotNetStarter.Commands.Cards.MoveCards;
using DotNetStarter.Commands.Cards.Update;
using DotNetStarter.Common;
using DotNetStarter.Common.Models;
using DotNetStarter.Extensions;
using DotNetStarter.Queries.Cards.Get;
using DotNetStarter.Queries.Cards.List;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers
{
    [Authorize(Roles = $"{RoleNames.ProjectManager},{RoleNames.Talent}")]
    [ApiVersion(ApiVersions.Version1)]
    [ApiController]
    [Route("api/v{version:apiVersion}/projects/{projectId}/[controller]")]
    public class CardsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CardsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HasPrivilege(PrivilegeNames.ViewCards)]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<CardDto>>> List([FromRoute] Guid projectId)
        {
            var result = await _mediator.Send(new ListCards(HttpContext.GetCurrentUserId()!.Value, projectId));

            return Ok(_mapper.Map<List<CardDto>>(result));
        }

        [HasPrivilege(PrivilegeNames.ViewCards)]
        [HttpGet("{cardId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<CardDto>> Get([FromRoute] Guid projectId, [FromRoute] Guid cardId)
        {
            var result = await _mediator.Send(new GetCard(HttpContext.GetCurrentUserId()!.Value, cardId, projectId));

            return Ok(_mapper.Map<CardDto>(result));
        }

        [HasPrivilege(PrivilegeNames.CreateCards)]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<ActionResult<List<DataChanged<CardDto>>>> Create([FromRoute] Guid projectId, [FromBody] CreateCardRequest request)
        {
            var result = await _mediator.Send(new CreateCard(HttpContext.GetCurrentUserId()!.Value, request.Name!, request.PrevCardId, request.NextCardId, request.StageId, projectId));

            return Ok(_mapper.Map<List<DataChanged<CardDto>>>(result));
        }

        [HasPrivilege(PrivilegeNames.DeleteCards)]
        [HttpDelete("{cardId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<DataChanged<CardDto>>>> Delete([FromRoute] Guid projectId, [FromRoute] Guid cardId)
        {
            var result = await _mediator.Send(new DeleteCard(HttpContext.GetCurrentUserId()!.Value, cardId, projectId));

            return Ok(_mapper.Map<List<DataChanged<CardDto>>>(result));

        }

        [HasPrivilege(PrivilegeNames.UpdateCards)]
        [HttpPut("{cardId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<DataChanged<CardDto>>> Update([FromRoute] Guid projectId, [FromRoute] Guid cardId, [FromBody] UpdateCardRequest request)
        {
            var result = await _mediator.Send(new UpdateCard(HttpContext.GetCurrentUserId()!.Value, cardId, request.Name!, request.Description, projectId));

            return Ok(_mapper.Map<DataChanged<CardDto>>(result));
        }

        [HasPrivilege(PrivilegeNames.UpdateCards)]
        [HttpPost("move")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<DataChanged<MovingCardDto>>>> Move([FromRoute] Guid projectId, [FromBody] List<MovingCardDto> request)
        {
            var cards = request.Select(c => new MovingCard(c.Id, c.PrevCardId, c.NextCardId, c.StageId)).ToList();

            var result = await _mediator.Send(new MoveCards(cards, projectId, HttpContext.GetCurrentUserId()!.Value));

            return Ok(_mapper.Map<List<DataChanged<MovingCardDto>>>(result));
        }
    }
}
