using DotNetStarter.Common;
using DotNetStarter.Common.Enums;
using DotNetStarter.Common.Models;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;
using DotNetStarter.Services.Storage;

namespace DotNetStarter.Commands.Attachments.Delete
{
    public sealed class DeleteAttachmentHandler : BaseRequestHandler<DeleteAttachment, DataChanged<Attachment>>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;
        private readonly IStorageService _storageService;

        public DeleteAttachmentHandler(
            IServiceProvider serviceProvider,
            IDotNetStarterUnitOfWork unitOfWork,
            IStorageService storageService)
            : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
            _storageService = storageService;
        }

        public override async Task<DataChanged<Attachment>> Process(DeleteAttachment request, CancellationToken cancellationToken)
        {
            var attachment = await _unitOfWork.AttachmentRepository.GetByIdAsync(request.AttachmentId);

            var blobName = attachment!.Name;

            await _storageService.DeleteAsync($"projects/{request.ProjectId}/cards/{request.CardId}/{blobName}");

            await _unitOfWork.AttachmentRepository.DeleteAsync(request.AttachmentId);
            await _unitOfWork.SaveChangesAsync();

            return new DataChanged<Attachment>(DataChangedType.Deleted, attachment!);
        }
    }
}