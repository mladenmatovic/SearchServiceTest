namespace SearchServiceTest.Repository
{
    public interface IRepository<T> where T : class, IEntity
    {
        T GetById(int id);

        IList<T> GetAll();
    }
}
