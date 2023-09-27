using Api.Common;
using Api.Dtos;
using Api.Models.Account;
using AutoMapper;
using DotNetStarter.Commands.Account;
using DotNetStarter.Commands.Users.Update;
using DotNetStarter.Extensions;
using DotNetStarter.Queries.Users.Get;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [ApiVersion(ApiVersions.Version1)]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly IMapper _mapper;

        public AccountController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<AccountDto>> Get()
        {
            var result = await _mediator.Send(new GetUser(HttpContext.GetCurrentUserId()!.Value));

            return Ok(_mapper.Map<AccountDto>(result));
        }

        [HttpPut]
        public async Task<ActionResult<AccountDto>> Update([FromBody] UpdateAccountRequest request)
        {
            var user = await _mediator.Send(new GetUser(HttpContext.GetCurrentUserId()!.Value));

            var result = await _mediator.Send(new UpdateUser(user.Id, request.Firstname!, request.Lastname!, request.PhoneNumber!, user.Status!.Value));

            return Ok(_mapper.Map<AccountDto>(result));
        }

        [HttpPut]
        [Route("change-password")]
        public async Task<ActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
        {
            await _mediator.Send(new ChangePassword(HttpContext.GetCurrentUserId()!.Value, request.CurrentPassword!, request.NewPassword!));

            return Ok();
        }
    }
}
