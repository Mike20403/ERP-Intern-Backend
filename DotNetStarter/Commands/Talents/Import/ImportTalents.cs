using MediatR;
using Microsoft.AspNetCore.Http;

namespace DotNetStarter.Commands.Talents.Import
{
    public sealed class ImportTalents : IRequest
    {
        public Guid AdministratorId { get; }

        public IFormFile File { get; }

        public ImportTalents(Guid administratorId, IFormFile file)
        {
            AdministratorId = administratorId;
            File = file;
        }
    }
}
