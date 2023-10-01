﻿using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using FluentValidation;

namespace DotNetStarter.Commands.Projects.Update
{
    public sealed class UpdateProjectValidator : AbstractValidator<UpdateProject>
    {
        public UpdateProjectValidator(IDotNetStarterUnitOfWork unitOfWork)
        {
            RuleFor(x => x.AgencyMemberId)
                .NotEmpty()
                .MustAsync((agencyMemberId, cancellation) => unitOfWork.ProjectRepository.AnyAsync(u => u.AgencyMemberId == agencyMemberId))
                .WithErrorCode(DomainExceptions.AgencyMemberNotFound.Code)
                .WithMessage(DomainExceptions.AgencyMemberNotFound.Message);

            RuleFor(x => x.ProjectId)
                .NotEmpty()
                .MustAsync((request, projectId, cancellation) => unitOfWork.ProjectRepository.AnyAsync(p => p.Id == projectId && p.AgencyMemberId == request.AgencyMemberId))
                .WithErrorCode(DomainExceptions.ProjectNotFound.Code)
                .WithMessage(DomainExceptions.ProjectNotFound.Message);        

            RuleFor(x => x.Name)
                .NotEmpty();
        }
    }
}
