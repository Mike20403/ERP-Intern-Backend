using Api.Common;
using Api.Dtos;
using Api.Hubs;
using Api.Models.Attachment;
using AutoMapper;
using DotNetStarter.Commands.Attachments.Create;
using DotNetStarter.Commands.Attachments.Delete;
using DotNetStarter.Common;
using DotNetStarter.Common.Models;
using DotNetStarter.Extensions;
using DotNetStarter.Queries.Attachments.List;
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
    public class AttachmentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public IHubContext<ProjectHub, IProjectClient> _hubContext;

        public AttachmentsController(IMediator mediator, IMapper mapper, IHubContext<ProjectHub, IProjectClient> hubContext)
        {
            _mediator = mediator;
            _mapper = mapper;
            _hubContext = hubContext;
        }

        [HasPrivilege(PrivilegeNames.ViewCards)]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<AttachmentDto>>> ListAttachments([FromRoute] Guid projectId, [FromRoute] Guid cardId)
        {
            var result = await _mediator.Send(new ListAttachments(HttpContext.GetCurrentUserId()!.Value, cardId, projectId));

            return Ok(_mapper.Map<List<AttachmentDto>>(result));
        }

        [HasPrivilege(PrivilegeNames.UpdateCards)]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<ActionResult<DataChanged<AttachmentDto>>> CreateAttachment([FromRoute] Guid projectId, [FromRoute] Guid cardId, [FromForm] CreateAttachmentRequest request)
        {
            var result = await _mediator.Send(new CreateAttachment(HttpContext.GetCurrentUserId()!.Value, request.File!, cardId, projectId));

            var dto = _mapper.Map<DataChanged<AttachmentDto>>(result);

            await _hubContext.Clients.Group(projectId.ToProjectGroup()).AttachmentChanged(dto);

            return Ok(dto);
        }

        [HasPrivilege(PrivilegeNames.UpdateCards)]
        [HttpDelete("{attachmentId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<DataChanged<AttachmentDto>>> DeleteAttachment([FromRoute] Guid projectId, Guid cardId, [FromRoute] Guid attachmentId)
        {
            var result = await _mediator.Send(new DeleteAttachment(HttpContext.GetCurrentUserId()!.Value, attachmentId, projectId, cardId));

            var dto = _mapper.Map<DataChanged<AttachmentDto>>(result);

            await _hubContext.Clients.Group(projectId.ToProjectGroup()).AttachmentChanged(dto);

            return Ok(dto);
        }
    }
}
