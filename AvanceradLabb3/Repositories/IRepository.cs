namespace AvanceradLabb3.Repositories
{
    public interface IRepository<T>
    {
        public Task<ICollection<T>> GetAll();

        public Task<T> GetById(int id);

        public Task Update(T t);
        public Task Delete(T t);
        public Task Create(T t);
    }
}
