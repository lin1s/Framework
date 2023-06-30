namespace Core.Base.Interface
{
    public interface IUnitOfWork
    {
        void BeginTransaction();

        void CommitTransaction();

        void RollBackTransaction();
    }
}