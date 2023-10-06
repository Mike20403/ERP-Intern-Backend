using Api.Common;
using Api.Dtos;
using Api.Models.Talents;
using AutoMapper;
using DotNetStarter.Commands.Talents.Create;
using DotNetStarter.Commands.Talents.Update;
using DotNetStarter.Commands.Talents.Delete;
using DotNetStarter.Common;
using DotNetStarter.Extensions;
using DotNetStarter.Queries.Talents.Get;
using DotNetStarter.Queries.Talents.List;
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
    public class TalentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly IMapper _mapper;

        public TalentsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [HasPrivilege(PrivilegeNames.ViewTalents)]
        public async Task<ActionResult<List<TalentDto>>> List([FromQuery] ListTalentsQueryParams queryParams)
        {
            var result = await _mediator.Send(new ListTalents(
                queryParams.PageNumber,
                queryParams.PageSize,
                queryParams.SearchQuery,
                queryParams.OrderBy.ToOrderBy(),
                queryParams.Gender,
                queryParams.Status,
                queryParams.IsAvailable
            ));
            Response.Headers.Add(DomainConstraints.XPagination, result.PaginationMetadata.SerializeWithCamelCase());
            return Ok(result.Select(_mapper.Map<TalentDto>).ToList());
        }

        [HttpGet("{talentId}")]
        [HasPrivilege(PrivilegeNames.ViewTalents)]
        public async Task<ActionResult<TalentDto>> Get([FromRoute] Guid talentId)
        {
            var result = await _mediator.Send(new GetTalent(talentId));

            return Ok(_mapper.Map<TalentDto>(result));
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [HasPrivilege(PrivilegeNames.CreateTalents)]
        public async Task<ActionResult<TalentDto>> Create([FromBody] CreateTalentRequest request)
        {
            var result = await _mediator.Send(new CreateTalent(
                request.Username!,
                request.Firstname!,
                request.Lastname!,
                request.Password!,
                request.PhoneNumber!,
                request.Gender.GetValueOrDefault(),
                request.Status!.Value,
                request.IsAvailable!.Value
                ));

            return CreatedAtAction(nameof(Get), new { talentId = result.Id }, _mapper.Map<TalentDto>(result));
        }

        [HttpPut("{talentId}")]
        [HasPrivilege(PrivilegeNames.UpdateTalents)]
        public async Task<ActionResult<TalentDto>> Update([FromRoute] Guid talentId, [FromBody] UpdateTalentRequest request)
        {
            var result = await _mediator.Send(new UpdateTalent(
                talentId,
                request.Firstname!,
                request.Lastname!,
                request.PhoneNumber!,
                request.Gender.GetValueOrDefault(),
                request.Status!.Value,
                request.IsAvailable!.Value
                ));

            return Ok(_mapper.Map<TalentDto>(result));
        }

        [HttpDelete("{talentId}")]
        [HasPrivilege(PrivilegeNames.DeleteTalents)]
        public async Task<ActionResult> Delete([FromRoute] Guid talentId)
        {
            await _mediator.Send(new DeleteTalent(talentId));

            return Ok();
        }
    }
}
