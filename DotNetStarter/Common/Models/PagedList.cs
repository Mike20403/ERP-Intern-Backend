namespace DotNetStarter.Common.Models
{
    public sealed class PagedList<T> : List<T>
    {
        public PaginationMetadata PaginationMetadata { get; }

        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            PaginationMetadata = new PaginationMetadata(count, pageNumber, pageSize);
            AddRange(items);
        }
    }
}
