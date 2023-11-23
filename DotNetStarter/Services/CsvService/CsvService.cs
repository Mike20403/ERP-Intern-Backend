using CsvHelper;
using System.Globalization;

namespace DotNetStarter.Services.CsvService
{
    public class CsvService
    {
        public List<T> Read<T>(byte[] csvData)
        {
            var memoryStream = new MemoryStream(csvData);
            var reader = new StreamReader(memoryStream);
            var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
            return csvReader.GetRecords<T>().ToList();
        }

        public byte[] Write<T>(List<T> dtos)
        {
            var memoryStream = new MemoryStream();
            var writer = new StreamWriter(memoryStream);
            var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);

            var headers = typeof(T).GetProperties().Select(p => p.Name).ToArray();

            foreach (var header in headers)
            {
                csvWriter.WriteField(header);
            }

            csvWriter.NextRecord();

            foreach (var dto in dtos)
            {
                foreach (var property in typeof(T).GetProperties())
                {
                    var value = property.GetValue(dto);
                    csvWriter.WriteField(value);
                }

                csvWriter.NextRecord();
            }

            writer.Flush();
            return memoryStream.ToArray();
        }
    }
}
