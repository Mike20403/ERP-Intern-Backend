using MediatR;

namespace DotNetStarter.Notifications.Users.ImportUserRequested
{
    public sealed class ImportUserRequested : INotification
    {
        public byte[] CsvData { get; }

        public ImportUserRequested(byte[] csvData)
        {
            CsvData = csvData;
        }
    }
}
