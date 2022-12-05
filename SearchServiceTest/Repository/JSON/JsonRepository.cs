using SearchServiceTest.Context;

namespace SearchServiceTest.Repository.JSON
{
    public class JsonRepository<T> : IRepository<T>
        where T : class, IEntity
    {        
        public JsonRepository(JsonContext context)
        {
            this._jsonContext = context;
        }

        readonly JsonContext _jsonContext;
        IList<T> _entities;

        public IQueryable<T> Entities
        {
            get
            {
                return JsonEntities.AsQueryable();
            }
        }

        protected IList<T> JsonEntities
        {
            get
            {
                return _entities ?? (_entities = _jsonContext.Set<T>());
            }
        }

        public T GetById(int id)
        {
            return Entities.FirstOrDefault(x => x.Id == id);
        }

        public IList<T> GetAll()
        {
            return JsonEntities;
        }

    }
}

