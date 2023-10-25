using Api.Common;
using Api.Dtos;
using Api.Models.Attachment;
using AutoMapper;
using DotNetStarter.Commands.Attachments.Create;
using DotNetStarter.Commands.Attachments.Delete;
using DotNetStarter.Common;
using DotNetStarter.Extensions;
using DotNetStarter.Queries.Attachments.List;
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
    public class AttachmentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AttachmentsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
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
        public async Task<ActionResult<AttachmentDto>> CreateAttachment([FromRoute] Guid projectId, [FromRoute] Guid cardId, [FromForm] CreateAttachmentRequest request)
        {
            var result = await _mediator.Send(new CreateAttachment(HttpContext.GetCurrentUserId()!.Value, request.File!, cardId, projectId));

            return Ok(_mapper.Map<AttachmentDto>(result));
        }

        [HasPrivilege(PrivilegeNames.UpdateCards)]
        [HttpDelete("{attachmentId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> DeleteAttachment([FromRoute] Guid projectId, Guid cardId, [FromRoute] Guid attachmentId)
        {
            await _mediator.Send(new DeleteAttachment(HttpContext.GetCurrentUserId()!.Value, attachmentId, projectId, cardId));

            return Ok();
        }
    }
}
