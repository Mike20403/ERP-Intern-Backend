using AutoMapper;
using DotNetStarter.Common.Models;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Queries.Talents.List;
using DotNetStarter.Services.CsvService;
using DotNetStarter.Services.Email;
using MediatR;

namespace DotNetStarter.Notifications.Users.ExportTalentRequested
{
    public sealed class ExportTalentRequestedHandler : INotificationHandler<ExportTalentRequested>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        private readonly CsvService _csvService;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public ExportTalentRequestedHandler(IDotNetStarterUnitOfWork unitOfWork, IMediator mediator, IMapper mapper, CsvService csvService, IEmailService emailService)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
            _mapper = mapper;
            _csvService = csvService;
            _emailService = emailService;
        }
        public async Task Handle(ExportTalentRequested notification, CancellationToken cancellationToken)
        {
            var talents = await _mediator.Send(new ListTalents(
                notification.PageNumber,
                notification.PageSize,
                notification.SearchQuery,
                notification.OrderBy,
                notification.Gender,
                notification.Status,
                notification.IsAvailable,
                false
                ));

            var admin = await _unitOfWork.UserRepository.FindAsync(filter: u => u.Id == notification.AdministratorId);

            var talentDtos = _mapper.Map<List<ImportTalentDto>>(talents);
            var talentCsvData = _csvService.Write(talentDtos);

            var attachments = new List<FileAttachmentInfo>
            {
                new FileAttachmentInfo
                {
                    Data = talentCsvData,
                    FileName = "talents.csv",
                    ContentType = "text/csv",
                }
            };
            await _emailService.SendFileDataAsync(admin.Username, admin.Firstname, attachments);
        }
    }
}
