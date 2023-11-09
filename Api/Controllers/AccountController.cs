using Api.Common;
using Api.Dtos;
using Api.Models.Account;
using AutoMapper;
using DotNetStarter.Commands.Account.ChangeEmailRequires;
using DotNetStarter.Commands.Account.ChangePassword;
using DotNetStarter.Commands.Account.ConfirmChangeEmail;
using DotNetStarter.Commands.Users.Update;
using DotNetStarter.Common;
using DotNetStarter.Extensions;
using DotNetStarter.Queries.Users.Get;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Api.Controllers
{
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

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<AccountDto>> Get()
        {
            var result = await _mediator.Send(new GetUser(null, HttpContext.GetCurrentUserId()!.Value));

            return Ok(_mapper.Map<AccountDto>(result));
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult<AccountDto>> Update([FromBody] UpdateAccountRequest request)
        {
            var user = await _mediator.Send(new GetUser(null, HttpContext.GetCurrentUserId()!.Value));
            
            var result = await _mediator.Send(new UpdateUser(
                null, 
                user.Id, 
                request.Firstname!,
                request.Lastname!,
                request.PhoneNumber!, 
                request.Gender.GetValueOrDefault(), 
                user.Status,
                user.Privileges.Select(p => p.Name).ToList()
            ));

            return Ok(_mapper.Map<AccountDto>(result));
        }

        [Authorize]
        [HttpPost("request-change-email")]
        public async Task<ActionResult> RequestChangeEmail(ChangeEmailRequest request) // Request to change email then recieve active code via current email
        {
            await _mediator.Send(new RequestChangeEmail(HttpContext.GetCurrentUserId()!.Value, request.Email!));

            return Ok();
        }

        [Authorize]
        [HttpPost("change-email")]
        public async Task<ActionResult> ConfirmChangeEmail(ConfirmChangeEmailRequest request) // Change Email via active code then set user to inactice
        {
            await _mediator.Send(new ConfirmChangeEmail(HttpContext.GetCurrentUserId()!.Value, request.Email!, request.ActiveCode!));

            return Ok();
        }

        [Authorize(DomainConstraints.CanChangePasswordPolicy)]
        [HttpPut]
        [Route("change-password")]
        public async Task<ActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
        {
            await _mediator.Send(new ChangePassword(HttpContext.GetCurrentUserId()!.Value, request.CurrentPassword!, request.NewPassword!));

            return Ok();
        }
    }
}