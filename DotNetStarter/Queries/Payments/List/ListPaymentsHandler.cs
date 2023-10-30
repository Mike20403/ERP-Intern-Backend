using DotNetStarter.Common;
using DotNetStarter.Common.Models;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;
using System.Linq.Expressions;

namespace DotNetStarter.Queries.Payments.List
{
    public sealed class ListPaymentsHandler : BaseRequestHandler<ListPayments, PagedList<Payment>>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        public ListPaymentsHandler(IServiceProvider serviceProvider, IDotNetStarterUnitOfWork unitOfWork) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<PagedList<Payment>> Process(ListPayments request, CancellationToken cancellationToken)
        {
            var filter = new List<Expression<Func<Payment, bool>>>() {
                p => p.ProjectId == request.ProjectId,
                p => p.Cards!.Any(c => c.Stage!.ProjectId == request.ProjectId)
            };

            if (request.TalentId is not null)
            {
                filter.Add(p => p.TalentId == request.TalentId);
            }

            if (request.PaymentStatus is not null)
            {
                filter.Add(p => p.PaymentStatus == request.PaymentStatus);
            }

            if (!string.IsNullOrEmpty(request.SearchQuery))
            {
                filter.Add(
                    p => p.Project!.Name.Contains(request.SearchQuery)
                        || (p.Talent!.Firstname + " " + p.Talent!.Lastname).Contains(request.SearchQuery)
                        || p.Talent!.Username.Contains(request.SearchQuery)
                );
            }

            return await _unitOfWork.PaymentRepository.GetPagedListAsync(
                request.OrderBy,
                includeProperties: 
                    $"{ClassUtils.GetPropertyName<Payment>(p => p.Cards!)}," +
                    $"{ClassUtils.GetPropertyName<Payment>(p => p.Cards!)}.{ClassUtils.GetPropertyName<Card>(p => p.Stage!)}," +
                    $"{ClassUtils.GetPropertyName<Payment>(p => p.Talent!)}," +
                    $"{ClassUtils.GetPropertyName<Payment>(p => p.Project!)}",
                pageNumber: request.PageNumber,
                pageSize: request.PageSize,
                filter: filter.ToArray()
            );
        }
    } 
}
