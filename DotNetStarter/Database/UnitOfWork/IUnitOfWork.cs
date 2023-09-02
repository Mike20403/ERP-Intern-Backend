namespace DotNetStarter.Database.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
        void Dispose();
    }
}
