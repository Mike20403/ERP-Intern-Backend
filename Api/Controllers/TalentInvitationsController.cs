using Api.Dtos;
using Api.Models.Invitations;
using AutoMapper;
using DotNetStarter.Common;
using DotNetStarter.Extensions;
using DotNetStarter.Queries.Invitations.List.TalentInvitation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/v{version:apiVersion}/Invitations")]
    [ApiController]
    public class TalentInvitationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly IMapper _mapper;

        public TalentInvitationsController(IMediator mediator, IMapper mapper) { 
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = RoleNames.Talent)]
        public async Task<ActionResult<List<InvitationDto>>> GetInvitations([FromQuery] ListInvitationsQueryParams queryParams)
        {
            var result = await _mediator.Send(new ListTalentInvitations
            (
                HttpContext.GetCurrentUserId()!.Value,
                queryParams.InvitationStatus,
                queryParams.PageNumber,
                queryParams.PageSize,
                queryParams.SearchQuery,
                queryParams.OrderBy.ToOrderBy()
            ));

            return Ok(_mapper.Map<List<InvitationDto>>(result));
        }
    }
}
