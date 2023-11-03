﻿using Api.Common;
using Api.Dtos;
using AutoMapper;
using DotNetStarter.Commands.Projects.RemoveTalent;
using DotNetStarter.Common;
using DotNetStarter.Extensions;
using DotNetStarter.Queries.TalentsOfAProject.List;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers
{
    [Authorize(Roles = $"{RoleNames.AgencyMember},{RoleNames.ProjectManager},{RoleNames.Talent}")]
    [ApiVersion(ApiVersions.Version1)]
    [ApiController]
    [Route("api/v{version:apiVersion}/projects/{projectId}/talents")]
    public class ProjectTalentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProjectTalentsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<PersonDto>>> List([FromRoute] Guid projectId)
        {
            Guid? agencyMemberId = User.IsInRole(RoleNames.AgencyMember) ? HttpContext.GetCurrentUserId()!.Value : null;
            Guid? projectManagerId = User.IsInRole(RoleNames.ProjectManager) ? HttpContext.GetCurrentUserId()!.Value : null;
            Guid? talentId = User.IsInRole(RoleNames.Talent) ? HttpContext.GetCurrentUserId()!.Value : null;

            var result = await _mediator.Send(new ListProjectTalents(agencyMemberId, projectManagerId, talentId, projectId));

            return Ok(_mapper.Map<List<PersonDto>>(result));
        }

        [Authorize(Roles = $"{RoleNames.AgencyMember},{RoleNames.ProjectManager}")]
        [HttpDelete("{talentId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> RemoveTalent([FromRoute] Guid projectId, [FromRoute] Guid talentId)
        {
            Guid? agencyMemberId = User.IsInRole(RoleNames.AgencyMember) ? HttpContext.GetCurrentUserId()!.Value : null;
            Guid? projectManagerId = User.IsInRole(RoleNames.ProjectManager) ? HttpContext.GetCurrentUserId()!.Value : null;

            await _mediator.Send(new RemoveTalent(
                projectId,
                talentId,
                agencyMemberId,
                projectManagerId));

            return Ok();
        }

        [Authorize(Roles = $"{RoleNames.Talent}")]
        [HttpDelete("myself")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> RemoveMySelf([FromRoute] Guid projectId)
        {
            await _mediator.Send(new RemoveTalent(
                projectId,
                HttpContext.GetCurrentUserId()!.Value,
                null,
                null));

            return Ok();
        }
    }
}
