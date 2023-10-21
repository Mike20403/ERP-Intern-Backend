using AutoMapper;
using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;
using DotNetStarter.Extensions;
using DotNetStarter.Notifications.Users.UserCreated;

namespace DotNetStarter.Commands.Users.Create
{
    public sealed class CreateUserHandler : BaseRequestHandler<CreateUser, User>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public CreateUserHandler(
            IServiceProvider serviceProvider, 
            IDotNetStarterUnitOfWork unitOfWork, 
            IMapper mapper
        ) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public override async Task<User> Process(CreateUser request, CancellationToken cancellationToken)
        {
            var role = await _unitOfWork.RoleRepository.FindAsync(ClassUtils.GetPropertyName<Role>(u => u.Privileges), r => r.Name == request.RoleName);

            var user = new User
            {
                RoleId = role!.Id,
                Privileges = role!.Privileges,
            };

            _mapper.Map(request, user);
            user.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);

            await _unitOfWork.UserRepository.CreateAsync(user);
            await _unitOfWork.SaveChangesAsync();

            new UserCreated(user.Status, user.Id, user.Username, user.Firstname).Enqueue();

            return user;
        }
    }
}
