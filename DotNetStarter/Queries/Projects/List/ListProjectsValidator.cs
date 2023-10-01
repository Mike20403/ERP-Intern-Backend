using FluentValidation;

namespace DotNetStarter.Queries.Projects.List
{
    public sealed class ListProjectsValidator : AbstractValidator<ListProjects>
    {
        public ListProjectsValidator()
        {
            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1);
        }
    }
}