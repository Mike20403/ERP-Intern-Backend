using AutoMapper;
using DotNetStarter.Common;
using DotNetStarter.Common.Enums;
using DotNetStarter.Common.Models;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;

namespace DotNetStarter.Commands.Comments.Create
{
    public sealed class CreateCommentHandler : BaseRequestHandler<CreateComment, DataChanged<Comment>>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCommentHandler(IServiceProvider serviceProvider, IDotNetStarterUnitOfWork unitOfWork, IMapper mapper) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public override async Task<DataChanged<Comment>> Process(CreateComment request, CancellationToken cancellationToken)
        {
            var owner = await _unitOfWork.UserRepository.FindAsync(
                includeProperties: ClassUtils.GetPropertyName<Talent>(c => c.Role!),
                filter: u => u.Id == request.ProjectManagerId || u.Id ==  request.TalentId);

            var parentComment = await _unitOfWork.CommentRepository.FindAsync(filter: u => u.Id == request.ParentId);

            var comment = new Comment
            {
                UserId = owner!.Id,
                ParentId = parentComment is not null ? parentComment.Id : null,
            };

            _mapper.Map(request, comment);

            var comments = new DataChanged<Comment>(DataChangedType.Created, comment);

            await _unitOfWork.CommentRepository.CreateAsync(comment);
            await _unitOfWork.SaveChangesAsync();

            return comments;
        }
    }
}
