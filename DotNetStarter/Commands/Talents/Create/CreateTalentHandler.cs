using AutoMapper;
using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;
using DotNetStarter.Extensions;
using DotNetStarter.Notifications.Users.UserCreated;
using System.Linq.Expressions;

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

            var filter = new List<Expression<Func<Privilege, bool>>>();

            // TODO: remove not null check
            if (request.PrivilegeNames is not null)
            {
                filter.Add(p => request.PrivilegeNames!.Contains(p.Name));
            }
            else // Create user with all role privileges
            {
                filter.Add(p => role!.Privileges.Contains(p));
            }

            var privileges = await _unitOfWork.PrivilegeRepository.ListAsync(filter: filter.ToArray());

            var talent = new Talent
            {
                RoleId = role!.Id,
                Privileges = privileges,
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
