using Api.Common;
using Api.Models.Account;
using Api.Models.Auth;
using Api.Models.Invitations;
using DotNetStarter.Commands.Auth.ActivateAccount;
using DotNetStarter.Commands.Auth.ForgotPassword;
using DotNetStarter.Commands.Auth.Login;
using DotNetStarter.Commands.Auth.RefreshToken;
using DotNetStarter.Commands.Auth.ResetPassword;
using DotNetStarter.Commands.Auth.TwoFactorsLogin;
using DotNetStarter.Commands.Invitations.RegisterTalent;
using DotNetStarter.Common;
using DotNetStarter.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiVersion(ApiVersions.Version1)]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest request)
        {
            var result = await _mediator.Send(new Login(request.Username!, request.Password!));

            return Ok(result);
        }

        [Authorize(DomainConstraints.TwoFactorAuthorizationPolicy)]
        [HttpPost("two-factors-login")]
        public async Task<ActionResult<LoginResponse>> TwoFactorsLogin(TwoFactorsLoginRequest request)
        {
            var result = await _mediator.Send(new TwoFactorsLogin(
                HttpContext.GetCurrentUserId()!.Value,
                request.TwoFactorsCode!
            )); 

            return Ok(result);
        }

        [HttpPost]
        [Route("forgot-password")]
        public async Task<ActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            await _mediator.Send(new ForgotPassword(request.Username!));

            return Ok();
        }

        [HttpPost]
        [Route("reset-password")]
        public async Task<ActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            await _mediator.Send(new ResetPassword(request.Username!, request.Password!, request.Code!));

            return Ok();
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<LoginResponse>> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            var result = await _mediator.Send(new RefreshToken(request.UserId!, request.TokenId!, request.Secret!));

            return Ok(result);
        }

        [HttpPost("activate-account")]
        public async Task<ActionResult> ActivateAccount(ActivateAccountRequest request) // Activate new Email after change email by any one has authorized
        {
            await _mediator.Send(new ActivateAccount(request.Email!, request.ActiveCode!));

            return Ok();
        }

        [HttpPost("register-talent")] // New talent create account then join into project
        public async Task<ActionResult> RegisterTalent(RegisterTalentRequest request)
        {
            await _mediator.Send(new RegisterTalent(
                request.InvitationId!.Value,
                request.Code!,
                request.Username!,
                request.Password!,
                request.Firstname!,
                request.Lastname!,
                request.PhoneNumber!,
                request.Gender.GetValueOrDefault()
            ));

            return Ok();
        }
    }
}
