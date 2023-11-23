using AutoMapper;
using DotNetStarter.Commands.Users.Create;
using DotNetStarter.Commands.Users.Update;
using DotNetStarter.Common.ImportDataUsers;
using DotNetStarter.Common.Models;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Extensions;
using DotNetStarter.Services.CsvService;
using MediatR;

namespace DotNetStarter.Notifications.Users.ImportUserRequested
{
    public sealed class ImportUserRequestedHandler : INotificationHandler<ImportUserRequested>
    {
        private readonly IMediator _mediator;
        private readonly CsvService _csvService;
        private readonly IMapper _mapper;
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        public ImportUserRequestedHandler(IMediator mediator, IMapper mapper, CsvService csvService, IDotNetStarterUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _mapper = mapper;
            _csvService = csvService;
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(ImportUserRequested notification, CancellationToken cancellationToken)
        {
            var dtos = _csvService.Read<ImportStaffMemberDto>(notification.CsvData);
            var staffMembers = _mapper.Map<List<ImportDataStaffMembers>>(dtos);

            foreach (var staffMember in staffMembers)
            {
                var staffMemberAlreadyExists = await _unitOfWork.UserRepository.FindAsync(filter: u => u.Username == staffMember.Username);
                if (staffMemberAlreadyExists is not null)
                {
                    await _mediator.Send(new UpdateUser(
                        staffMember.RoleName.Value.ToRoleName(),
                        staffMemberAlreadyExists.Id,
                        staffMember.Firstname,
                        staffMember.Lastname,
                        staffMember.PhoneNumber,
                        staffMember.Gender.GetValueOrDefault(),
                        staffMember.Status.Value,
                        staffMember.Privileges
                    ));
                }
                else
                {
                    await _mediator.Send(new CreateUser(
                        staffMember.RoleName.Value.ToRoleName(),
                        staffMember.Username,
                        staffMember.Firstname,
                        staffMember.Lastname,
                        staffMember.Password,
                        staffMember.PhoneNumber,
                        staffMember.Gender.GetValueOrDefault(),
                        staffMember.Status.Value,
                        staffMember.Privileges
                    ));
                }
            }
        }
    }
}
