using Api.Common;
using Api.Dtos;
using Api.Models.Payments;
using AutoMapper;
using DotNetStarter.Commands.Payments.Create;
using DotNetStarter.Commands.Payments.Finalize;
using DotNetStarter.Commands.Payments.Process;
using DotNetStarter.Commands.Payments.Update;
using DotNetStarter.Common;
using DotNetStarter.Extensions;
using DotNetStarter.Queries.Payments.Get;
using DotNetStarter.Queries.Payments.List;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiVersion(ApiVersions.Version1)]
    [ApiController]
    [Route("api/v{version:apiVersion}/projects/{projectId}/[controller]")]
    public class PaymentsController : ControllerBase
    {   
        private readonly IMediator _mediator;

        private readonly IMapper _mapper;

        public PaymentsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<PaymentDto>>> List([FromRoute] Guid projectId, [FromQuery]ListPaymentsQueryParams queryParams)
        {
            Guid? talentId = User.IsInRole(RoleNames.Talent) ? HttpContext.GetCurrentUserId()!.Value : null;
            Guid? staffMenberId = User.IsInRole(RoleNames.AgencyMember) || User.IsInRole(RoleNames.ProjectManager) ? HttpContext.GetCurrentUserId()!.Value : null;

            var payments = await _mediator.Send(new ListPayments(
                talentId,
                staffMenberId,
                projectId,
                queryParams.Status,
                queryParams.PageNumber,
                queryParams.PageSize,
                queryParams.SearchQuery,
                queryParams.OrderBy.ToOrderBy()
            ));

            return Ok(_mapper.Map<List<PaymentDto>>(payments));
        }

        [HttpGet("{paymentId}")]
        [Authorize]
        public async Task<ActionResult<PaymentDto>> Get([FromRoute] Guid projectId, [FromRoute] Guid paymentId)
        {
            var payment = await _mediator.Send(new GetPayment(
                HttpContext.GetCurrentUserId()!.Value,
                paymentId, 
                projectId
            ));

            return Ok(_mapper.Map<PaymentDto>(payment));
        }

        [HttpPost]
        [Authorize(Roles = RoleNames.Talent)]
        public async Task<ActionResult<PaymentDto>> Create([FromRoute] Guid projectId, UpsertPaymentRequest request)
        {
            var payment = await _mediator.Send(new CreatePayment(
                HttpContext.GetCurrentUserId()!.Value,
                projectId, 
                request.CardIds!,
                request.Description,
                request.Amount!.Value
            ));

            return CreatedAtAction(nameof(Get), new { projectId = projectId, paymentId = payment.Id }, _mapper.Map<PaymentDto>(payment));
        }

        [HttpPut("{paymentId}")]
        [Authorize(Roles = RoleNames.Talent)]
        public async Task<ActionResult<PaymentDto>> Update([FromRoute] Guid projectId, [FromRoute] Guid paymentId, UpsertPaymentRequest request)
        {
            var payment = await _mediator.Send(new UpdatePayment(
                HttpContext.GetCurrentUserId()!.Value,
                projectId,
                paymentId,
                request.CardIds!,
                request.Description,
                request.Amount!.Value
            ));

            return Ok(_mapper.Map<PaymentDto>(payment));
        }

        [HttpPost("{paymentId}/process")]
        [Authorize(Roles = RoleNames.AgencyMember)]
        [HasPrivilege(PrivilegeNames.AcceptPayments)]
        public async Task<ActionResult> Accept([FromRoute] Guid projectId, [FromRoute] Guid paymentId, ProcessPaymentRequest request)
        {
            await _mediator.Send(new ProcessPayment(
                paymentId,
                projectId, 
                HttpContext.GetCurrentUserId()!.Value,
                request.IsAccepted!.Value
            ));

            return Ok();
        }

        [HttpPost("{paymentId}/finalize")]
        [Authorize(Roles = RoleNames.ProjectManager)]
        [HasPrivilege(PrivilegeNames.FinalizePayments)]
        public async Task<ActionResult> Finalize([FromRoute] Guid projectId, [FromRoute] Guid paymentId)
        {
            await _mediator.Send(new FinalizePayment(
                paymentId,
                projectId,
                HttpContext.GetCurrentUserId()!.Value
            ));

            return Ok();
        }
    }
}
