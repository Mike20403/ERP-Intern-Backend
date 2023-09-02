using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;

namespace DotNetStarter.Commands.Users.Delete
{
    public sealed class DeleteUserHandler : BaseRequestHandler<DeleteUser>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        public DeleteUserHandler(IServiceProvider serviceProvider, IDotNetStarterUnitOfWork unitOfWork) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task Process(DeleteUser request, CancellationToken cancellationToken)
        {
            await _unitOfWork.UserRepository.DeleteAsync(request.UserId);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
