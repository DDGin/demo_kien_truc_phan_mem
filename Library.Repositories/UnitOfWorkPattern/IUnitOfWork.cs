using Library.Repositories.Generic;

namespace Library.Repositories.UnitOfWorkPattern
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> GenericRepository<T>() where T : class;
        void Save();
    }
}
