using AutoMapper;
using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;
using DotNetStarter.Services.Storage;

namespace DotNetStarter.Commands.Attachments.Create
{
    public sealed class CreateAttachmentHandler : BaseRequestHandler<CreateAttachment, Attachment>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IStorageService _storageService;

        public CreateAttachmentHandler(
            IServiceProvider serviceProvider,
            IDotNetStarterUnitOfWork unitOfWork,
            IMapper mapper,
            IStorageService storageService) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _storageService = storageService;
        }

        public override async Task<Attachment> Process(CreateAttachment request, CancellationToken cancellationToken)
        {
            var originalName = request.File.FileName;
            var name = $"{DateTime.Now.ToString("yyyyMMddHHmmss")}_{originalName}";

            var folderPath = $"projects/{request.ProjectId}/cards/{request.CardId}";

            var attachment = new Attachment
            {
                Name = name,
                OriginalName = request.File.FileName,
            };

            var contentType = request.File.ContentType;

            _mapper.Map(request, attachment);
            await _unitOfWork.AttachmentRepository.CreateAsync(attachment);

            string blobName = $"{folderPath}/{name}";
            await _storageService.UploadAsync(request.File.OpenReadStream(), blobName, contentType);

            await _unitOfWork.SaveChangesAsync();

            return attachment;
        }
    }
}
