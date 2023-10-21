using Api.Common;
using Api.Dtos;
using Api.Models.Invitations;
using Api.Models.StaffMembers;
using AutoMapper;
using DotNetStarter.Commands.Invitations.InviteTalent;
using DotNetStarter.Commands.Invitations.ProcessInvitation;
using DotNetStarter.Common;
using DotNetStarter.Extensions;
using DotNetStarter.Queries.Invitations.List.StaffMemberInvitation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [ApiVersion(ApiVersions.Version1)]
    [ApiController]
    [Route("api/v{version:apiVersion}/projects/{projectId}/[controller]")]
    public class InvitationsController : ControllerBase
    {
        public readonly IMediator _mediator;

        public readonly IMapper _mapper;

        public InvitationsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = $"{RoleNames.AgencyMember},{RoleNames.ProjectManager}")]
        public async Task<ActionResult<InvitationDto>> GetInvitations([FromRoute] Guid projectId, [FromQuery] ListStaffInvitationQueryParams queryParams)
        {
            var invitations = await _mediator.Send(new ListStaffInvitations(
                HttpContext.GetCurrentUserId()!.Value,
                HttpContext.GetCurrentUserRole()!,
                projectId,
                queryParams.IsTalentExisted,
                queryParams.InvitationStatus,
                queryParams.PageNumber,
                queryParams.PageSize,
                queryParams.SearchQuery,
                queryParams.OrderBy.ToOrderBy()
            ));

            return Ok(invitations.Select(_mapper.Map<InvitationDto>).ToList());
        }

        [HttpPost]
        [Authorize(Roles = $"{RoleNames.ProjectManager},{RoleNames.AgencyMember}")]
        [HasPrivilege(PrivilegeNames.InviteTalents)]
        public async Task<ActionResult<InvitationDto>> InviteTalent([FromRoute] Guid projectId, InviteTalentRequest request)
        {
            var invitation = await _mediator.Send(new InviteTalent(
                request.Email,
                projectId, 
                HttpContext.GetCurrentUserId()!.Value,
                HttpContext.GetCurrentUserRole()!,
                request.TalentId
            ));

            return Ok(_mapper.Map<InvitationDto>(invitation));
        }

        [HttpPost("{invitationId}/process-invitation")]
        [Authorize(Roles = RoleNames.Talent)]
        public async Task<ActionResult> ProcessInvitation([FromRoute] Guid projectId, [FromRoute] Guid invitationId, ProccessInvitationRequest request)
        {
            await _mediator.Send(new ProcessInvitation(projectId, invitationId, HttpContext.GetCurrentUserId()!.Value, request.IsAccepted!.Value));

            return Ok();
        }
    }
}
