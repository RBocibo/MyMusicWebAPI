namespace MyMusic.Core.Interfaces
{
    public interface IUnitOfWork
    {
        Task CommitAsyc();
    }
}
