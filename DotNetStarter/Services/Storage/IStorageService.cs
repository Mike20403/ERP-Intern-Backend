namespace DotNetStarter.Services.Storage
{
    public interface IStorageService
    {
        Task UploadAsync(Stream stream, string blobName, string contentType);
        Task DeleteAsync(string blobName);
        Task DeleteDirectoryAsync(string directoryName);
    }
}
