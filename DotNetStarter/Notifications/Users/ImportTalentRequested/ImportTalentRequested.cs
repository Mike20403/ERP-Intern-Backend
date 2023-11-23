using MediatR;

namespace DotNetStarter.Notifications.Users.ImportTalentRequested
{
    public sealed class ImportTalentRequested : INotification
    {
        public byte[] CsvData { get; }

        public ImportTalentRequested(byte[] csvData)
        {
            CsvData = csvData;
        }
    }
}
