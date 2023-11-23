using DotNetStarter.Common;
using DotNetStarter.Extensions;
using DotNetStarter.Notifications.Users.ImportUserRequested;

namespace DotNetStarter.Commands.Users.Import
{
    public sealed class ImportUsersHandler : BaseRequestHandler<ImportUsers>
    {
        public ImportUsersHandler(IServiceProvider serviceProvider) : base(serviceProvider) { }

        public override async Task Process(ImportUsers request, CancellationToken cancellationToken)
        {
            var memoryStream = new MemoryStream();
            await request.File.CopyToAsync(memoryStream);
            var csvData = memoryStream.ToArray();

            new ImportUserRequested(csvData).Enqueue();
        }
    }
}
