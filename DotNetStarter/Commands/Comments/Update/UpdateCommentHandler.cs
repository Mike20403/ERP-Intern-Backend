using AutoMapper;
using DotNetStarter.Common;
using DotNetStarter.Common.Enums;
using DotNetStarter.Common.Models;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;

namespace DotNetStarter.Commands.Comments.Update
{
    public sealed class UpdateCommentHandler : BaseRequestHandler<UpdateComment, DataChanged<Comment>>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCommentHandler(IServiceProvider serviceProvider, IDotNetStarterUnitOfWork unitOfWork, IMapper mapper) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public override async Task<DataChanged<Comment>> Process(UpdateComment request, CancellationToken cancellationToken)
        {
            var comment = await _unitOfWork.CommentRepository.FindAsync(
                includeProperties: ClassUtils.GetPropertyName<Comment>(c => c.User!),
                filter: c => c.Id == request.CommentId && c.UserId == request.OwnerId);

            _mapper.Map(request, comment);

            var commentChanged = new DataChanged<Comment>(DataChangedType.Updated, comment);

            await _unitOfWork.CommentRepository.UpdateAsync(comment!);
            await _unitOfWork.SaveChangesAsync();

            return commentChanged!;
        }
    }
}
