namespace JBlog.Core.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
    }
}
