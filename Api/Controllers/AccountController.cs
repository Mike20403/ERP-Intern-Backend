using Api.Common;
using Api.Dtos;
using Api.Models.Account;
using AutoMapper;
using DotNetStarter.Commands.Account.ActivateEmail;
using DotNetStarter.Commands.Account.ConfirmChangeEmail;
using DotNetStarter.Commands.Account.ChangeEmailRequires;
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

        [HttpPost("request-change-email")]
        public async Task<ActionResult> RequestChangeEmail(ChangeEmailRequest request) // Request to change email then recieve active code via current email
        {
            var user = await _mediator.Send(new GetUser(HttpContext.GetCurrentUserId()!.Value));

            await _mediator.Send(new RequestChangeEmail(user.Username!, request.NewEmail!));

            return Ok();
        }

        [HttpPost("change-email")]
        public async Task<ActionResult> ConfirmChangeEmail(ConfirmChangeEmailRequest request) // Change Email via active code then set user to inactice
        {
            await _mediator.Send(new ConfirmChangeEmail(request.CurrentEmail!, request.NewEmail!, request.ActiveCode!));

            return Ok($"Email is changed into {request.NewEmail}, please check the inbox and activate your account soon");
        }

        [HttpPost("activate-email")]
        [AllowAnonymous]
        public async Task<ActionResult> ActivateNewEmail(ActivateEmailRequest request) // Activate new Email after change email by any one has authorized
        {
            await _mediator.Send(new ActivateEmail(request.Email!, request.ActiveCode!));

            return Ok("Account Activated!");
        }
    }
}
