using DotNetStarter.Common;
using DotNetStarter.Common.Enums;
using DotNetStarter.Common.Models;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;

namespace DotNetStarter.Commands.Comments.Delete
{
    public sealed class DeleteCommentHandler : BaseRequestHandler<DeleteComment, List<DataChanged<Comment>>>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        public DeleteCommentHandler(IServiceProvider serviceProvider, IDotNetStarterUnitOfWork unitOfWork) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<List<DataChanged<Comment>>> Process(DeleteComment request, CancellationToken cancellationToken)
        {
            var comment = await _unitOfWork.CommentRepository.FindAsync(
                includeProperties: ClassUtils.GetPropertyName<Comment>(c => c.User!),
                filter: c => c.Id == request.CommentId);
            var listReplyComments = await _unitOfWork.CommentRepository.ListAsync(filter: c => c.ParentId == request.CommentId);

            var commentChanged = new DataChanged<Comment>(DataChangedType.Deleted, comment);
            var listCommentDelete = new List<DataChanged<Comment>> { commentChanged };
            listCommentDelete.AddRange(listReplyComments.Select(replyComment => new DataChanged<Comment>(DataChangedType.Deleted, replyComment)));

            await _unitOfWork.CommentRepository.DeletesAsync(listReplyComments.ToArray());
            await _unitOfWork.CommentRepository.DeleteAsync(comment);
            await _unitOfWork.SaveChangesAsync();

            return listCommentDelete;
        }
    }
}