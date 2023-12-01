using Api.Common;
using Api.Dtos;
using Api.Hubs;
using Api.Models.Stages;
using AutoMapper;
using DotNetStarter.Commands.Stages.Update;
using DotNetStarter.Commands.Stages.UpdateNotification;
using DotNetStarter.Common;
using DotNetStarter.Extensions;
using DotNetStarter.Queries.Stages.List;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Api.Controllers
{
    [ApiVersion(ApiVersions.Version1)]
    [ApiController]
    [Route("api/v{version:apiVersion}/projects/{projectId}/[controller]")]
    public class StagesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public IHubContext<ProjectHub, IProjectClient> _projectHubContext { get; }

        public StagesController(IMediator mediator, IMapper mapper, IHubContext<ProjectHub, IProjectClient> projectHubContext)
        {
            _mediator = mediator;
            _mapper = mapper;
            _projectHubContext = projectHubContext;
        }

        [Authorize(Roles = $"{RoleNames.ProjectManager},{RoleNames.Talent}")]
        [HasPrivilege(PrivilegeNames.ViewStages)]
        [HttpGet]
        public async Task<ActionResult<List<StageDto>>> List([FromRoute] Guid projectId)
        {
            Guid? projectManagerId = User.IsInRole(RoleNames.ProjectManager) ? HttpContext.GetCurrentUserId()!.Value : null;
            Guid? talentId = User.IsInRole(RoleNames.Talent) ? HttpContext.GetCurrentUserId()!.Value : null;

            var result = await _mediator.Send(new ListStages(
                projectManagerId,
                talentId,
                projectId
            ));

            return Ok(_mapper.Map<List<StageDto>>(result));
        }

        [Authorize(Roles = RoleNames.ProjectManager)]
        [HasPrivilege(PrivilegeNames.UpdateStages)]   
        [HttpPut]
        public async Task<ActionResult<List<StageDto>>> Update([FromRoute] Guid projectId, [FromBody] List<StageDto>? stages)
        {
            var upsertStages = stages?.Select(s => new UpsertStage(s.Id, s.Name!))?.ToList() ?? new List<UpsertStage>();

            var result = await _mediator.Send(new UpdateStages(
                HttpContext.GetCurrentUserId()!.Value,
                projectId,
                upsertStages));

            var dtos = _mapper.Map<List<StageDto>>(result);

            await _projectHubContext.Clients.Group(projectId.ToProjectGroup()).StagesChanged(dtos);

            return Ok(dtos);
        }

        [Authorize(Roles = $"{RoleNames.ProjectManager},{RoleNames.Talent}")]
        [HttpPut("{stageId}")]
        public async Task<ActionResult> UpdateStageNotification([FromRoute] Guid projectId, [FromRoute] Guid stageId, [FromBody] StageNotificationRequest request)
        {
            Guid? projectManagerId = User.IsInRole(RoleNames.ProjectManager) ? HttpContext.GetCurrentUserId()!.Value : null;
            Guid? talentId = User.IsInRole(RoleNames.Talent) ? HttpContext.GetCurrentUserId()!.Value : null;

            await _mediator.Send(new UpdateNotification(projectManagerId, talentId, projectId, stageId, request.IsNotificationEnabled!.Value));

            return Ok();
        }
    }
}
