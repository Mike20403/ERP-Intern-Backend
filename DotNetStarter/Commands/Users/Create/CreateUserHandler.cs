using AutoMapper;
using DotNetStarter.Common;
using DotNetStarter.Common.Enums;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;
using DotNetStarter.Services.Email;
using Microsoft.Extensions.Configuration;

namespace DotNetStarter.Commands.Users.Create
{
    public sealed class CreateUserHandler : BaseRequestHandler<CreateUser, User>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        private readonly IEmailService _emailService;

        private readonly IConfiguration _configuration;

        public CreateUserHandler(
            IServiceProvider serviceProvider, 
            IDotNetStarterUnitOfWork unitOfWork, 
            IMapper mapper, 
            IEmailService emailService,
            IConfiguration configuration
        ) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _emailService = emailService;
            _configuration = configuration;
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

            if (request.Status == Status.Active)
            {
                string message = "Your account is created successfully!";
                await _emailService.SendNotificationAsync(request.Username, request.Firstname, message);
            }

            else if (request.Status == Status.Inactive) {
                var activeOtp = new Otp
                {
                    UserId = user!.Id,
                    Type = OtpType.ActivateAccount,
                    Code = new Random().Next(0, 1000000).ToString("D6"),
                    IsUsed = false,
                    ExpiredDate = DateTime.Now.AddMinutes(int.Parse(_configuration["Otp:ActiveOtpLifetimeDuration"]!)),
                };

                await _emailService.SendActivateAccountAsync(request.Username, request.Firstname, activeOtp.Code);
            }
            return user;
        }
    }
}
