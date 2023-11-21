using Api.Common;
using Api.Dtos;
using Api.Hubs;
using AutoMapper;
using DotNetStarter.Commands.Cards.AddOwner;
using DotNetStarter.Commands.Cards.RemoveOwner;
using DotNetStarter.Common;
using DotNetStarter.Common.Models;
using DotNetStarter.Extensions;
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
    [Route("api/v{version:apiVersion}/projects/{projectId}/cards/{cardId}/[controller]")]
    public class OwnersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public IHubContext<ProjectHub, IProjectClient> _hubContext;

        public OwnersController(IMediator mediator, IMapper mapper, IHubContext<ProjectHub, IProjectClient> hubContext)
        {
            _mediator = mediator;
            _mapper = mapper;
            _hubContext = hubContext;
        }

        [HttpPut("{ownerId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<DataChanged<PersonDto>>> AddOwner([FromRoute] Guid projectId, [FromRoute] Guid cardId, [FromRoute] Guid ownerId)
        {
            Guid? projectManagerId = User.IsInRole(RoleNames.ProjectManager) ? HttpContext.GetCurrentUserId()!.Value : null;
            Guid? talentId = User.IsInRole(RoleNames.Talent) ? HttpContext.GetCurrentUserId()!.Value : null;

            var result = await _mediator.Send(new AddOwner(projectId, cardId, ownerId, projectManagerId, talentId));

            var dto = _mapper.Map<DataChanged<PersonDto>>(result);

            await _hubContext.Clients.Group(projectId.ToProjectGroup()).CardOwnerChanged(dto);

            return Ok(dto);
        }

        [HttpDelete("{ownerId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<DataChanged<PersonDto>>> RemoveOwner([FromRoute] Guid projectId, [FromRoute] Guid cardId, [FromRoute] Guid ownerId)
        {
            Guid? projectManagerId = User.IsInRole(RoleNames.ProjectManager) ? HttpContext.GetCurrentUserId()!.Value : null;
            Guid? talentId = User.IsInRole(RoleNames.Talent) ? HttpContext.GetCurrentUserId()!.Value : null;

            var result = await _mediator.Send(new RemoveOwner(projectId, cardId, ownerId, projectManagerId, talentId));

            var dto = _mapper.Map<DataChanged<PersonDto>>(result);

            await _hubContext.Clients.Group(projectId.ToProjectGroup()).CardOwnerChanged(dto);

            return Ok(dto);
        }
    }
}
