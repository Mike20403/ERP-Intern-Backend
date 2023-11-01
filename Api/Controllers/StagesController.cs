using Api.Common;
using Api.Dtos;
using AutoMapper;
using DotNetStarter.Commands.Stages.Update;
using DotNetStarter.Common;
using DotNetStarter.Extensions;
using DotNetStarter.Queries.Stages.List;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiVersion(ApiVersions.Version1)]
    [ApiController]
    [Route("api/v{version:apiVersion}/projects/{projectId}/[controller]")]
    public class StagesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public StagesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
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
            var upsertStages = stages?.Select(s => new UpsertStage(s.Id, s.Name!, s.IsNotificationEnabled))?.ToList() ?? new List<UpsertStage>();

            var result = await _mediator.Send(new UpdateStages(
                HttpContext.GetCurrentUserId()!.Value,
                projectId,
                upsertStages));

            return Ok(_mapper.Map<List<StageDto>>(result));
        }
    }
}
