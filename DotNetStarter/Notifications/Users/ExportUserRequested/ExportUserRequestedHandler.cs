using AutoMapper;
using DotNetStarter.Common.Models;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Queries.Users.List;
using DotNetStarter.Services.CsvService;
using DotNetStarter.Services.Email;
using MediatR;

namespace DotNetStarter.Notifications.Users.ExportUserRequested
{
    public sealed class ExportUserRequestedHandler : INotificationHandler<ExportUserRequested>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        private readonly CsvService _csvService;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public ExportUserRequestedHandler(IDotNetStarterUnitOfWork unitOfWork, IMediator mediator, IMapper mapper, CsvService csvService, IEmailService emailService)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
            _mapper = mapper;
            _csvService = csvService;
            _emailService = emailService;
        }
        public async Task Handle(ExportUserRequested notification, CancellationToken cancellationToken)
        {
            var staffMembers = await _mediator.Send(new ListUsers(
                notification.PageNumber,
                notification.PageSize,
                notification.SearchQuery,
                notification.OrderBy,
                notification.RoleNames,
                notification.Gender,
                notification.Status,
                false));

            var admin = await _unitOfWork.UserRepository.FindAsync(filter: u => u.Id == notification.AdministratorId);

            var staffMemberDtos = _mapper.Map<List<ImportStaffMemberDto>>(staffMembers);
            var staffMemberCsvData = _csvService.Write(staffMemberDtos);

            var attachments = new List<FileAttachmentInfo>
            {
                new FileAttachmentInfo
                {
                    Data = staffMemberCsvData,
                    FileName = "staff_members.csv",
                    ContentType = "text/csv",
                }
            };
            await _emailService.SendFileDataAsync(admin.Username, admin.Firstname, attachments);
        }
    }
}
