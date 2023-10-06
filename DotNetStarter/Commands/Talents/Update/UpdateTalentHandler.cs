using AutoMapper;
using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;

namespace DotNetStarter.Commands.Talents.Update
{
    public sealed class UpdateTalentHandler : BaseRequestHandler<UpdateTalent, Talent>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public UpdateTalentHandler(IServiceProvider serviceProvider, IDotNetStarterUnitOfWork unitOfWork, IMapper mapper) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public override async Task<Talent> Process(UpdateTalent request, CancellationToken cancellationToken)
        {
            var talent = await _unitOfWork.TalentRepository.FindAsync(ClassUtils.GetPropertyName<Talent>(u => u.Role!), u => u.Id == request.UserId);

            _mapper.Map(request, talent);

            await _unitOfWork.TalentRepository.UpdateAsync(talent!);
            await _unitOfWork.SaveChangesAsync();

            return talent!;
        }
    }
}
