using Api.Common;
using Api.Dtos;
using Api.Hubs;
using Api.Models.Comments;
using AutoMapper;
using DotNetStarter.Commands.Comments.Create;
using DotNetStarter.Commands.Comments.Delete;
using DotNetStarter.Commands.Comments.Update;
using DotNetStarter.Common;
using DotNetStarter.Common.Models;
using DotNetStarter.Extensions;
using DotNetStarter.Queries.Comments.List;
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
    [Route("api/v{version:apiVersion}/projects/{projectId}/card/{cardId}/[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public IHubContext<ProjectHub, IProjectClient> _hubContext;

        public CommentsController(IMediator mediator, IMapper mapper, IHubContext<ProjectHub, IProjectClient> hubContext)
        {
            _mediator = mediator;
            _mapper = mapper;
            _hubContext = hubContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<CommentDto>>> List([FromRoute] Guid projectId, [FromRoute] Guid cardId, [FromQuery] ListCommentsQueryParams queryParams)
        {
            Guid? projectManagerId = User.IsInRole(RoleNames.ProjectManager) ? HttpContext.GetCurrentUserId()!.Value : null;
            Guid? talentId = User.IsInRole(RoleNames.Talent) ? HttpContext.GetCurrentUserId()!.Value : null;

            var result = await _mediator.Send(new ListComments(
                queryParams.PageNumber,
                queryParams.PageSize,
                queryParams.SearchQuery,
                queryParams.OrderBy.ToOrderBy(),
                projectId,
                cardId,
                queryParams.ParentId,
                projectManagerId,
                talentId,
                queryParams.Status));

            Response.Headers.Add(DomainConstraints.XPagination, result.PaginationMetadata.SerializeWithCamelCase());

            return Ok(_mapper.Map<List<CommentDto>>(result));
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<ActionResult<DataChanged<CommentDto>>> Create([FromRoute] Guid projectId, [FromRoute] Guid cardId, [FromBody] CreateCommentRequest request)
        {
            Guid? projectManagerId = User.IsInRole(RoleNames.ProjectManager) ? HttpContext.GetCurrentUserId()!.Value : null;
            Guid? talentId = User.IsInRole(RoleNames.Talent) ? HttpContext.GetCurrentUserId()!.Value : null;

            var result = await _mediator.Send(new CreateComment(projectId, cardId, request.Description!, request.ParentId, projectManagerId, talentId));

            var dto = _mapper.Map<DataChanged<CommentDto>>(result);
            await _hubContext.Clients.Group(projectId.ToProjectGroup()).CommentChanged(new List<DataChanged<CommentDto>> { dto });

            return Ok(dto);
        }

        [HttpPut("{commentId}")]
        public async Task<ActionResult<DataChanged<CommentDto>>> Update([FromRoute] Guid projectId, [FromRoute] Guid cardId, [FromRoute] Guid commentId, UpdateCommentRequest request)
        {
            var result = await _mediator.Send(new UpdateComment(projectId, cardId, commentId, request.Description, request.CommentStatus, HttpContext.GetCurrentUserId()!.Value));

            var dto = _mapper.Map<DataChanged<CommentDto>>(result);
            await _hubContext.Clients.Group(projectId.ToProjectGroup()).CommentChanged(new List<DataChanged<CommentDto>> { dto });

            return Ok(dto);
        }

        [HttpDelete("{commentId}")]
        public async Task<ActionResult<List<DataChanged<CommentDto>>>> Delete([FromRoute] Guid projectId, [FromRoute] Guid cardId, [FromRoute] Guid commentId)
        {
            var result = await _mediator.Send(new DeleteComment(projectId, cardId, commentId, HttpContext.GetCurrentUserId()!.Value));

            var dto = _mapper.Map<List<DataChanged<CommentDto>>>(result);
            await _hubContext.Clients.Group(projectId.ToProjectGroup()).CommentChanged(dto);

            return Ok(dto);
        }
    }
}
