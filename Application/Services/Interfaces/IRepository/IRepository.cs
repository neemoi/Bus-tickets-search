namespace Application.Services.Interfaces.Repository
{
    public interface IRepository<T> where T : class
    {
        void Create(T item);

        void Read(T item);

        void Update(T item);

        void Delete(int id);
    }
}
