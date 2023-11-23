using MediatR;
using Microsoft.AspNetCore.Http;

namespace DotNetStarter.Commands.Users.Import
{
    public sealed class ImportUsers : IRequest
    {
        public Guid AdministratorId { get; }

        public IFormFile File { get; }

        public ImportUsers(Guid administratorId, IFormFile file)
        {
            AdministratorId = administratorId;
            File = file;
        }
    }
}
