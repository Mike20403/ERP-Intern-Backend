using Api.Common;
using Api.Dtos;
using AutoMapper;
using DotNetStarter.Commands.Cards.AddOwner;
using DotNetStarter.Commands.Cards.RemoveOwner;
using DotNetStarter.Common;
using DotNetStarter.Common.Models;
using DotNetStarter.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        public OwnersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPut("{ownerId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<DataChanged<CardDto>>> AddOwner([FromRoute] Guid projectId, [FromRoute] Guid cardId, [FromRoute] Guid ownerId)
        {
            var result = await _mediator.Send(new AddOwner(projectId, cardId, ownerId, HttpContext.GetCurrentUserId()!.Value));

            return Ok(_mapper.Map<DataChanged<CardDto>>(result));
        }

        [HttpDelete("{ownerId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> RemoveOwner([FromRoute] Guid projectId, [FromRoute] Guid cardId, [FromRoute] Guid ownerId)
        {
            var result = await _mediator.Send(new RemoveOwner(projectId, cardId, ownerId, HttpContext.GetCurrentUserId()!.Value));

            return Ok(_mapper.Map<DataChanged<CardDto>>(result));
        }
    }
}
