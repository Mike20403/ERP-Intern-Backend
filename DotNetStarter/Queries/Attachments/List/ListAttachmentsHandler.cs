using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;

namespace DotNetStarter.Queries.Attachments.List
{
    public sealed class ListAttachmentsHandler : BaseRequestHandler<ListAttachments, List<Attachment>>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        public ListAttachmentsHandler(IServiceProvider serviceProvider, IDotNetStarterUnitOfWork unitOfWork) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<List<Attachment>> Process(ListAttachments request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.AttachmentRepository.ListAsync(filter: s => s.Card!.Id == request.CardId);
        }
    }
}