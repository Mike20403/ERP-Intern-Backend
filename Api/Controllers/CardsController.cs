using Api.Common;
using Api.Dtos;
using Api.Hubs;
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
using Microsoft.AspNetCore.SignalR;
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
        public IHubContext<ProjectHub, IProjectClient> _hubContext;

        public CardsController(IMediator mediator, IMapper mapper, IHubContext<ProjectHub, IProjectClient> hubContext)
        {
            _mediator = mediator;
            _mapper = mapper;
            _hubContext = hubContext;
        }

        [HasPrivilege(PrivilegeNames.ViewCards)]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<CardDto>>> List([FromRoute] Guid projectId)
        {
            Guid? projectManagerId = User.IsInRole(RoleNames.ProjectManager) ? HttpContext.GetCurrentUserId()!.Value : null;
            Guid? talentId = User.IsInRole(RoleNames.Talent) ? HttpContext.GetCurrentUserId()!.Value : null;

            var result = await _mediator.Send(new ListCards(projectManagerId, talentId, projectId));

            return Ok(_mapper.Map<List<CardDto>>(result));
        }

        [HasPrivilege(PrivilegeNames.ViewCards)]
        [HttpGet("{cardId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<CardDto>> Get([FromRoute] Guid projectId, [FromRoute] Guid cardId)
        {
            Guid? projectManagerId = User.IsInRole(RoleNames.ProjectManager) ? HttpContext.GetCurrentUserId()!.Value : null;
            Guid? talentId = User.IsInRole(RoleNames.Talent) ? HttpContext.GetCurrentUserId()!.Value : null;

            var result = await _mediator.Send(new GetCard(projectManagerId, talentId, cardId, projectId));

            return Ok(_mapper.Map<CardDto>(result));
        }

        [HasPrivilege(PrivilegeNames.CreateCards)]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<ActionResult<List<DataChanged<CardDto>>>> Create([FromRoute] Guid projectId, [FromBody] CreateCardRequest request)
        {
            Guid? projectManagerId = User.IsInRole(RoleNames.ProjectManager) ? HttpContext.GetCurrentUserId()!.Value : null;
            Guid? talentId = User.IsInRole(RoleNames.Talent) ? HttpContext.GetCurrentUserId()!.Value : null;

            var result = await _mediator.Send(new CreateCard(projectManagerId, talentId, request.Name!, request.PrevCardId, request.NextCardId, request.StageId, projectId));

            var dto = _mapper.Map<List<DataChanged<CardDto>>>(result);

            await _hubContext.Clients.Group(projectId.ToProjectGroup()).CardsChanged(dto);

            return Ok(dto);
        }

        [HasPrivilege(PrivilegeNames.DeleteCards)]
        [HttpDelete("{cardId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<DataChanged<CardDto>>>> Delete([FromRoute] Guid projectId, [FromRoute] Guid cardId)
        {
            Guid? projectManagerId = User.IsInRole(RoleNames.ProjectManager) ? HttpContext.GetCurrentUserId()!.Value : null;
            Guid? talentId = User.IsInRole(RoleNames.Talent) ? HttpContext.GetCurrentUserId()!.Value : null;

            var result = await _mediator.Send(new DeleteCard(projectManagerId, talentId, cardId, projectId));

            var dto = _mapper.Map<List<DataChanged<CardDto>>>(result);

            await _hubContext.Clients.Group(projectId.ToProjectGroup()).CardsChanged(dto);

            return Ok(dto);
        }

        [HasPrivilege(PrivilegeNames.UpdateCards)]
        [HttpPut("{cardId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<DataChanged<CardDto>>> Update([FromRoute] Guid projectId, [FromRoute] Guid cardId, [FromBody] UpdateCardRequest request)
        {
            Guid? projectManagerId = User.IsInRole(RoleNames.ProjectManager) ? HttpContext.GetCurrentUserId()!.Value : null;
            Guid? talentId = User.IsInRole(RoleNames.Talent) ? HttpContext.GetCurrentUserId()!.Value : null;

            var result = await _mediator.Send(new UpdateCard(projectManagerId, talentId, cardId, request.Name!, request.Description, projectId));

            var dto = _mapper.Map<DataChanged<CardDto>>(result);

            await _hubContext.Clients.Group(projectId.ToProjectGroup()).CardsChanged(new List<DataChanged<CardDto>> { dto });

            return Ok(_mapper.Map<DataChanged<CardDto>>(result));
        }

        [HasPrivilege(PrivilegeNames.UpdateCards)]
        [HttpPost("move")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<DataChanged<MovingCardDto>>>> Move([FromRoute] Guid projectId, [FromBody] List<MovingCardDto> request)
        {
            Guid? projectManagerId = User.IsInRole(RoleNames.ProjectManager) ? HttpContext.GetCurrentUserId()!.Value : null;
            Guid? talentId = User.IsInRole(RoleNames.Talent) ? HttpContext.GetCurrentUserId()!.Value : null;

            var cards = request.Select(c => new MovingCard(c.Id, c.PrevCardId, c.NextCardId, c.StageId)).ToList();

            var result = await _mediator.Send(new MoveCards(cards, projectId, projectManagerId, talentId));

            var dto = _mapper.Map<List<DataChanged<MovingCardDto>>>(result);

            await _hubContext.Clients.Group(projectId.ToProjectGroup()).CardsMoved(dto);

            return Ok(dto);
        }
    }
}
