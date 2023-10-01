using DotNetStarter.Entities;
using MediatR;

namespace DotNetStarter.Commands.Projects.Create
{
    public sealed class CreateProject : IRequest<Project>
    {
        public Guid AgencyMemberId { get; }

        public string Name { get; }

        public CreateProject(Guid agencyMemberId, string name) 
        {
            AgencyMemberId = agencyMemberId;
            Name = name;
        }
    }
}
