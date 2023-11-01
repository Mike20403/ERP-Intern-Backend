using Api.Common;
using Api.Dtos;
using Api.Models.Projects;
using AutoMapper;
using DotNetStarter.Commands.Projects.Create;
using DotNetStarter.Commands.Projects.Delete;
using DotNetStarter.Commands.Projects.Update;
using DotNetStarter.Common;
using DotNetStarter.Extensions;
using DotNetStarter.Queries.Projects.Get;
using DotNetStarter.Queries.Projects.List;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers
{
    [Authorize]
    [ApiVersion(ApiVersions.Version1)]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly IMapper _mapper;

        public ProjectsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [Authorize(Roles = $"{RoleNames.ProjectManager},{RoleNames.AgencyMember},{RoleNames.Talent}")]
        [HasPrivilege(PrivilegeNames.ViewProjects)]
        [HttpGet]
        public async Task<ActionResult<List<ProjectDto>>> List([FromQuery] ListProjectsQueryParams queryParams)
        {
            Guid? agencyMenberId = User.IsInRole(RoleNames.AgencyMember) ? HttpContext.GetCurrentUserId()!.Value : null;
            Guid? projectManagerId = User.IsInRole(RoleNames.ProjectManager) ? HttpContext.GetCurrentUserId()!.Value : null;
            Guid? talentId = User.IsInRole(RoleNames.Talent) ? HttpContext.GetCurrentUserId()!.Value : null;

            var result = await _mediator.Send(new ListProjects(
                queryParams.PageNumber,
                queryParams.PageSize,
                queryParams.SearchQuery,
                queryParams.OrderBy.ToOrderBy(),
                agencyMenberId,
                projectManagerId,
                talentId,
                queryParams.Status
            ));

            Response.Headers.Add(DomainConstraints.XPagination, result.PaginationMetadata.SerializeWithCamelCase());

            return Ok(_mapper.Map<List<ProjectDto>>(result));
        }

        [Authorize(Roles = RoleNames.AgencyMember)]
        [HasPrivilege(PrivilegeNames.CreateProjects)]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<ActionResult<ProjectDto>> Create([FromBody] CreateProjectRequest request)
        {
            var result = await _mediator.Send(new CreateProject(HttpContext.GetCurrentUserId()!.Value, request.Name!));

            return CreatedAtAction(nameof(Get), new { projectId = result.Id }, _mapper.Map<ProjectDto>(result));
        }

        [Authorize(Roles = $"{RoleNames.ProjectManager},{RoleNames.AgencyMember},{RoleNames.Talent}")]
        [HasPrivilege(PrivilegeNames.ViewProjects)]
        [HttpGet("{projectId}")]
        public async Task<ActionResult<ProjectDto>> Get([FromRoute] Guid projectId)
        {
            Guid? agencyMenberId = User.IsInRole(RoleNames.AgencyMember) ? HttpContext.GetCurrentUserId()!.Value : null;
            Guid? projectManagerId = User.IsInRole(RoleNames.ProjectManager) ? HttpContext.GetCurrentUserId()!.Value : null;
            Guid? talentId = User.IsInRole(RoleNames.Talent) ? HttpContext.GetCurrentUserId()!.Value : null;

            var result = await _mediator.Send(new GetProject(
                agencyMenberId, 
                projectManagerId, 
                talentId,
                projectId
            ));

            return Ok(_mapper.Map<ProjectDto>(result));
        }

        [Authorize(Roles = RoleNames.AgencyMember)]
        [HasPrivilege(PrivilegeNames.UpdateProjects)]
        [HttpPut("{projectId}")]
        public async Task<ActionResult<ProjectDto>> Update([FromRoute] Guid projectId, [FromBody] UpdateProjectRequest request)
        {
            var result = await _mediator.Send(new UpdateProject(HttpContext.GetCurrentUserId()!.Value, projectId, request.Name!, request.ProjectManagerId, request.Status!.Value));

            return Ok(_mapper.Map<ProjectDto>(result));
        }

        [Authorize(Roles = RoleNames.AgencyMember)]
        [HasPrivilege(PrivilegeNames.DeleteProjects)]
        [HttpDelete("{projectId}")]
        public async Task<ActionResult> Delete([FromRoute] Guid projectId)
        {
            await _mediator.Send(new DeleteProject(HttpContext.GetCurrentUserId()!.Value, projectId));

            return Ok();
        }
    }
}