using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class ListQueryParams
    {
        [Range(0, int.MaxValue)]
        public int PageNumber { get; set; } = 0;

        [Range(1, int.MaxValue)]
        public int PageSize { get; set; } = 25;

        public string? SearchQuery { get; set; }

        public List<string>? OrderBy { get; set; }
    }
}
