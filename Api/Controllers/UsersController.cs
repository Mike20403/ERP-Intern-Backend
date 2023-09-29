using Api.Common;
using Api.Dtos;
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
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly IMapper _mapper;

        public UsersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> List([FromQuery] ListUsersQueryParams queryParams)
        {
            var result = await _mediator.Send(new ListUsers(queryParams.PageNumber, queryParams.PageSize, queryParams.SearchQuery, queryParams.Status));

            Response.Headers.Add(DomainConstraints.XPagination, result.PaginationMetadata.SerializeWithCamelCase());
            return Ok(result.Select(_mapper.Map<UserDto>).ToList());
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<ActionResult<UserDto>> Create([FromBody] CreateUserRequest request)
        {
            var result = await _mediator.Send(new CreateUser(request.Username!, request.Firstname!, request.Lastname!, request.Password!, request.PhoneNumber!, request.Status!.Value));

            return CreatedAtAction(nameof(Get), new { userId = result.Id }, _mapper.Map<UserDto>(result));
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<UserDto>> Get([FromRoute] Guid userId)
        {
            var result = await _mediator.Send(new GetUser(userId));

            return Ok(_mapper.Map<UserDto>(result));
        }

        [HttpPut("{userId}")]
        public async Task<ActionResult<UserDto>> Update([FromRoute] Guid userId, [FromBody] UpdateUserRequest request)
        {
            var result = await _mediator.Send(new UpdateUser(userId, request.Firstname!, request.Lastname!, request.PhoneNumber!, request.Status!.Value));

            return Ok(_mapper.Map<UserDto>(result));
        }

        [HttpDelete("{userId}")]
        public async Task<ActionResult> Delete([FromRoute] Guid userId)
        {
            await _mediator.Send(new DeleteUser(userId));

            return Ok();
        }
    }
}
