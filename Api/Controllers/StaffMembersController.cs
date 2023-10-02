using Api.Common;
using Api.Dtos;
using Api.Models.StaffMembers;
using Api.Models.Users;
using AutoMapper;
using DotNetStarter.Commands.Users.Create;
using DotNetStarter.Commands.Users.Delete;
using DotNetStarter.Commands.Users.Update;
using DotNetStarter.Common;
using DotNetStarter.Extensions;
using DotNetStarter.Queries.Users.Get;
using DotNetStarter.Queries.Users.List;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers
{
    [Authorize(Roles = RoleNames.Administrator)]
    [ApiVersion(ApiVersions.Version1)]
    [ApiController]
    [Route("api/v{version:apiVersion}/staff-members")]
    public class StaffMembersController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly IMapper _mapper;

        public StaffMembersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [HasPrivilege(PrivilegeNames.ViewStaffMembers)]
        public async Task<ActionResult<List<StaffMemberDto>>> List([FromQuery] ListStaffMembersQueryParams queryParams)
        {
            var result = await _mediator.Send(new ListUsers(queryParams.PageNumber, queryParams.PageSize, queryParams.SearchQuery, queryParams.Type.ToRoleNames(), queryParams.Gender, queryParams.Status));

            Response.Headers.Add(DomainConstraints.XPagination, result.PaginationMetadata.SerializeWithCamelCase());
            return Ok(result.Select(_mapper.Map<StaffMemberDto>).ToList());
        }

        [HttpGet("{staffMemberId}")]
        [HasPrivilege(PrivilegeNames.ViewStaffMembers)]
        public async Task<ActionResult<StaffMemberDto>> Get([FromRoute] Guid staffMemberId)
        {
            var result = await _mediator.Send(new GetUser(staffMemberId));

            return Ok(_mapper.Map<StaffMemberDto>(result));
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [HasPrivilege(PrivilegeNames.CreateStaffMembers)]
        public async Task<ActionResult<StaffMemberDto>> Create([FromBody] CreateStaffMemberRequest request)
        {
            var result = await _mediator.Send(new CreateUser(
                request.Type!.Value.ToRoleName(),
                request.Username!,
                request.Firstname!,
                request.Lastname!,
                request.Password!,
                request.PhoneNumber!,
                request.Gender.GetValueOrDefault(),
                request.Status!.Value
                ));

            return CreatedAtAction(nameof(Get), new { staffMemberId = result.Id }, _mapper.Map<StaffMemberDto>(result));
        }

        [HttpPut("{staffMemberId}")]
        [HasPrivilege(PrivilegeNames.UpdateStaffMembers)]
        public async Task<ActionResult<StaffMemberDto>> Update([FromRoute] Guid staffMemberId, [FromBody] UpdateUserRequest request)
        {
            var result = await _mediator.Send(new UpdateUser(
                staffMemberId,
                request.Firstname!,
                request.Lastname!,
                request.PhoneNumber!,
                request.Gender.GetValueOrDefault(),
                request.Status!.Value));

            return Ok(_mapper.Map<StaffMemberDto>(result));
        }

        [HttpDelete("{staffMemberId}")]
        [HasPrivilege(PrivilegeNames.DeleteStaffMembers)]
        public async Task<ActionResult> Delete([FromRoute] Guid staffMemberId)
        {
            await _mediator.Send(new DeleteUser(staffMemberId));

            return Ok();
        }
    }
}
