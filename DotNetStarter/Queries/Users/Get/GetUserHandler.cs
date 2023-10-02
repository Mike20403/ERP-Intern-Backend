using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;

namespace DotNetStarter.Queries.Users.Get
{
    public sealed class GetUserHandler : BaseRequestHandler<GetUser, User>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        public GetUserHandler(IServiceProvider serviceProvider, IDotNetStarterUnitOfWork unitOfWork) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<User> Process(GetUser request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.UserRepository.FindAsync(ClassUtils.GetPropertyName<User>(u => u.Role), u => u.Id == request.UserId);
        }
    }
}
