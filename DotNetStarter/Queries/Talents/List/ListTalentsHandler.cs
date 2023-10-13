using DotNetStarter.Common;
using DotNetStarter.Common.Models;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;
using System.Linq.Expressions;

namespace DotNetStarter.Queries.Talents.List
{
    public sealed class ListTalentsHandler : BaseRequestHandler<ListTalents, PagedList<Talent>>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        public ListTalentsHandler(IServiceProvider serviceProvider, IDotNetStarterUnitOfWork unitOfWork) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<PagedList<Talent>> Process(ListTalents request, CancellationToken cancellationToken)
        {
            var filter = new List<Expression<Func<Talent, bool>>>();

            if (!string.IsNullOrEmpty(request.SearchQuery))
            {
                if (request.IsAutocomplete)
                {
                    filter.Add(u => u.Username.Contains(request.SearchQuery)
                                    || u.Firstname.Contains(request.SearchQuery)
                                    || u.Lastname.Contains(request.SearchQuery));
                }    
                else
                {
                    filter.Add(u => u.Username.Contains(request.SearchQuery)
                                    || u.Firstname.Contains(request.SearchQuery)
                                    || u.Lastname.Contains(request.SearchQuery)
                                    || u.PhoneNumber.Contains(request.SearchQuery));
                }    
            }

            var role = await _unitOfWork.RoleRepository.FindAsync(filter: r => r.Name == RoleNames.Talent);
            filter.Add(u => u.RoleId == role!.Id);

            if (request.IsAvailable != null)
            {
                filter.Add(t => t.IsAvailable == request.IsAvailable);
            }

            if (request.Gender != null)
            {
                filter.Add(t => t.Gender == request.Gender);
            }

            if (request.Status != null)
            {
                filter.Add(t => t.Status == request.Status);
            }

            return await _unitOfWork.TalentRepository.GetPagedListAsync(
                request.OrderBy,
                ClassUtils.GetPropertyName<Talent>(u => u.Role),
                pageNumber: request.PageNumber,
                pageSize: request.PageSize,
                filter: filter.ToArray()
            );
        }
    }
}
