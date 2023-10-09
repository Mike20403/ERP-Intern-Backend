using Api.Common;
using Api.Dtos;
using Api.Models.Stages;
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
    [Authorize(Roles = RoleNames.ProjectManager)]
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

        [HasPrivilege(PrivilegeNames.ViewProjects)]
        [HttpGet]
        public async Task<ActionResult<List<StageDto>>> List([FromRoute] Guid projectId)
        {
            var result = await _mediator.Send(new ListStages(HttpContext.GetCurrentUserId()!.Value, projectId));
            return Ok(result.Select(_mapper.Map<StageDto>).ToList());
        }

        [HasPrivilege(PrivilegeNames.UpdateProjects)]   
        [HttpPut]
        public async Task<ActionResult<List<StageDto>>> Update([FromRoute] Guid projectId, [FromBody] UpdateStagesRequest request)
        {
            var upsertStages = request.Stages.Select(s => new UpsertStage(s.Id, s.Name!)).ToList();

            var result = await _mediator.Send(new UpdateStages(
                HttpContext.GetCurrentUserId()!.Value,
                projectId,
                upsertStages));

            return Ok(result.OrderBy(stage => stage.Order).Select(_mapper.Map<StageDto>).ToList());
        }
    }
}
