using AutoMapper;
using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;

namespace DotNetStarter.Commands.Users.Update
{
    public sealed class UpdateUserHandler : BaseRequestHandler<UpdateUser, User>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public UpdateUserHandler(IServiceProvider serviceProvider, IDotNetStarterUnitOfWork unitOfWork, IMapper mapper) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public override async Task<User> Process(UpdateUser request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.FindAsync(ClassUtils.GetPropertyName<User>(u => u.Role), u => u.Id == request.UserId);

            _mapper.Map(request, user);

            await _unitOfWork.UserRepository.UpdateAsync(user!);
            await _unitOfWork.SaveChangesAsync();

            return user!;
        }
    }
}
