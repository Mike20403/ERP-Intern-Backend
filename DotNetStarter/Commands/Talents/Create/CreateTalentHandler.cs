using AutoMapper;
using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;
using DotNetStarter.Extensions;
using DotNetStarter.Notifications.Users.UserCreated;

namespace DotNetStarter.Commands.Talents.Create
{
    public sealed class CreateTalentHandler : BaseRequestHandler<CreateTalent, Talent>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public CreateTalentHandler(
            IServiceProvider serviceProvider,
            IDotNetStarterUnitOfWork unitOfWork,
            IMapper mapper
        ) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public override async Task<Talent> Process(CreateTalent request, CancellationToken cancellationToken)
        {
            var role = await _unitOfWork.RoleRepository.FindAsync(ClassUtils.GetPropertyName<Role>(u => u.Privileges), r => r.Name == RoleNames.Talent);

            var talent = new Talent
            {
                RoleId = role!.Id,
                Privileges = role!.Privileges,
            };

            _mapper.Map(request, talent);
            talent.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);

            await _unitOfWork.TalentRepository.CreateAsync(talent);
            await _unitOfWork.SaveChangesAsync();

            new UserCreated(talent.Status, talent.Id, talent.Username, talent.Firstname).Enqueue();

            return talent;
        }
    }
}
