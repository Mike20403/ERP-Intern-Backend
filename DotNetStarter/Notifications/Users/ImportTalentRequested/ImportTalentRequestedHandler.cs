using AutoMapper;
using DotNetStarter.Commands.Talents.Create;
using DotNetStarter.Commands.Talents.Update;
using DotNetStarter.Common.ImportDataUsers;
using DotNetStarter.Common.Models;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Services.CsvService;
using MediatR;

namespace DotNetStarter.Notifications.Users.ImportTalentRequested
{
    public sealed class ImportTalentRequestedHandler : INotificationHandler<ImportTalentRequested>
    {
        private readonly IMediator _mediator;
        private readonly CsvService _csvService;
        private readonly IMapper _mapper;
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        public ImportTalentRequestedHandler(IMediator mediator, IMapper mapper, CsvService csvService, IDotNetStarterUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _mapper = mapper;
            _csvService = csvService;
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(ImportTalentRequested notification, CancellationToken cancellationToken)
        {
            var dtos = _csvService.Read<ImportTalentDto>(notification.CsvData);
            var talents = _mapper.Map<List<ImportDataTalents>>(dtos);

            foreach (var talent in talents)
            {
                var talentAlreadyExists = await _unitOfWork.UserRepository.FindAsync(filter: u => u.Username == talent.Username);

                if (talentAlreadyExists is not null)
                {
                    await _mediator.Send(new UpdateTalent(
                        talentAlreadyExists.Id,
                        talent.Firstname,
                        talent.Lastname,
                        talent.PhoneNumber,
                        talent.Gender.GetValueOrDefault(),
                        talent.Status!.Value,
                        talent.IsAvailable!.Value,
                        talent.Privileges
                    ));
                }
                else
                {
                    await _mediator.Send(new CreateTalent(
                        talent.Username,
                        talent.Firstname,
                        talent.Lastname,
                        talent.Password,
                        talent.PhoneNumber,
                        talent.Gender.GetValueOrDefault(),
                        talent.Status!.Value,
                        talent.IsAvailable!.Value,
                        talent.Privileges
                    ));
                }
            }
        }
    }
}
