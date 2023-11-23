using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using FluentValidation;

namespace DotNetStarter.Commands.Users.Import
{
    public sealed class ImportUsersValidator : AbstractValidator<ImportUsers>
    {
        public ImportUsersValidator(IDotNetStarterUnitOfWork unitOfWork)
        {
            RuleFor(x => x.AdministratorId)
                .NotEmpty()
                .MustAsync((administratorId, cancellation) => unitOfWork.UserRepository.AnyAsync(u => u.Id == administratorId))
                .WithErrorCode(DomainExceptions.UserNotFound.Code)
                .WithMessage(DomainExceptions.UserNotFound.Message);

            RuleFor(x => x.File)
                .NotEmpty()
                .Must(file =>
                {
                    var fileExtension = Path.GetExtension(file.FileName).Replace(".", "").ToLower();
                    var fileContentType = file.ContentType.ToLower();

                    return DomainConstraints.AllowedExtensionsForCsvImport.Contains(fileExtension) && DomainConstraints.AllowedContentTypesForCsvImport.Contains(fileContentType);
                })
                .WithMessage("Invalid file. Please upload a file with valid extension and content type.");
        }
    }
}
