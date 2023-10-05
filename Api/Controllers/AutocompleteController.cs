using Api.Common;
using Api.Dtos;
using Api.Models;
using AutoMapper;
using DotNetStarter.Common;
using DotNetStarter.Common.Enums;
using DotNetStarter.Extensions;
using DotNetStarter.Queries.Users.List;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion(ApiVersions.Version1)]
    [ApiController]
    public class AutocompleteController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly IMapper _mapper;

        public AutocompleteController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("project-managers")]
        [HasPrivilege(PrivilegeNames.ViewStaffMembers)]
        [Authorize(Roles = RoleNames.AgencyMember)]
        public async Task<ActionResult<List<PersonDto>>> ListProjectManagers([FromQuery] ListQueryParams queryParams)
        {
            var result = await _mediator.Send(new ListUsers(
                queryParams.PageNumber,
                queryParams.PageSize,
                queryParams.SearchQuery,
                queryParams.OrderBy.ToOrderBy(),
                new List<string> { RoleNames.ProjectManager },
                null,
                Status.Active,
                true
                ));

            Response.Headers.Add(DomainConstraints.XPagination, result.PaginationMetadata.SerializeWithCamelCase());
            return Ok(result.Select(_mapper.Map<PersonDto>).ToList());
        }
    }
}
