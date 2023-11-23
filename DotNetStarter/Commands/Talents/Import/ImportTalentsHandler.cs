using DotNetStarter.Common;
using DotNetStarter.Extensions;
using DotNetStarter.Notifications.Users.ImportTalentRequested;

namespace DotNetStarter.Commands.Talents.Import
{
    public sealed class ImportTalentsHandler : BaseRequestHandler<ImportTalents>
    {
        public ImportTalentsHandler(IServiceProvider serviceProvider) : base(serviceProvider) { }

        public override async Task Process(ImportTalents request, CancellationToken cancellationToken)
        {
            var memoryStream = new MemoryStream();
            await request.File.CopyToAsync(memoryStream);
            var csvData = memoryStream.ToArray();

            new ImportTalentRequested(csvData).Enqueue();
        }
    }
}
