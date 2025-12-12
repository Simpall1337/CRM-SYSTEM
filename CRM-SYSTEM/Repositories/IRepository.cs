namespace CRM_SYSTEM.Repositories
{
    public interface IRepository<T>
    {
        T? GetById(int id);
        void Add(T entity);
        void Update();
        void Delete(T entity);
    }
}
