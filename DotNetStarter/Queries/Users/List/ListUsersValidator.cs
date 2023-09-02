using FluentValidation;

namespace DotNetStarter.Queries.Users.List
{
    public sealed class ListUsersValidator : AbstractValidator<ListUsers>
    {
        public ListUsersValidator()
        {
            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1);
        }
    }
}
