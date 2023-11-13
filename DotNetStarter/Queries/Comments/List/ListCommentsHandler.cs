using DotNetStarter.Common;
using DotNetStarter.Common.Models;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;
using System.Linq.Expressions;

namespace DotNetStarter.Queries.Comments.List
{
    public sealed class ListCommentsHandler : BaseRequestHandler<ListComments, PagedList<Comment>>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        public ListCommentsHandler(IServiceProvider serviceProvider, IDotNetStarterUnitOfWork unitOfWork) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
        }
        public override async Task<PagedList<Comment>> Process(ListComments request, CancellationToken cancellationToken)
        {
            var filter = new List<Expression<Func<Comment, bool>>>();

            if (!string.IsNullOrEmpty(request.SearchQuery))
            {
                filter.Add(
                    p => p.User!.Username.Contains(request.SearchQuery) ||
                    p.User!.Firstname.Contains(request.SearchQuery) || 
                    p.User!.Lastname.Contains(request.SearchQuery)
                );
            }

            if (request.Status is not null)
            {
                filter.Add(u => u.CommentStatus == request.Status);
            }

            if (request.ParentId is not null)
            {
                filter.Add(u => u.ParentId == request.ParentId);
            }

            return await _unitOfWork.CommentRepository.GetPagedListAsync(
                request.OrderBy,
                includeProperties: ClassUtils.GetPropertyName<Comment>(p => p.User!),
                pageNumber: request.PageNumber,
                pageSize: request.PageSize,
                filter: filter.ToArray()
            );
        }
    }
}
