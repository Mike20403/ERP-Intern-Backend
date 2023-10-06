using DotNetStarter.Database.UnitOfWork;
using FluentValidation;

namespace DotNetStarter.Queries.Talents.List
{
    public sealed class ListTalentsValidator : AbstractValidator<ListTalents>
    {
        public ListTalentsValidator(IDotNetStarterUnitOfWork unitOfWork)
        {
            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1);
        }
    }
}
