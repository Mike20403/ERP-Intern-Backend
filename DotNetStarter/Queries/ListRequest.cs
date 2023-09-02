using DotNetStarter.Common.Models;
using MediatR;

namespace DotNetStarter.Queries
{
    public class ListRequest<T> : IRequest<PagedList<T>>
    {
        public int PageNumber { get; }

        public int PageSize { get; }

        public string? SearchQuery { get; }

        public ListRequest(int pageNumber, int pageSize, string? searchQuery)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            SearchQuery = searchQuery;
        }
    }
}
