using SearchServiceTest.Repository;
using SearchServiceTest.Model.Service;
using System.Text.Json;

namespace SearchServiceTest.Context
{
    public class JsonContext : IContext
    {   
        public JsonContext(string fileName)
        {
            _jsonFileName = fileName;
        }

        readonly string _jsonFileName;

        public IList<T> Set<T>()
        where T : IEntity
        {            
            string filePath = _jsonFileName;
            IList<T> entities = new List<T>();
            if (File.Exists(filePath))
            {
                string jsonString = System.IO.File.ReadAllText(filePath);
                entities = JsonSerializer.Deserialize<List<T>>(jsonString)!;               
            }
            return entities.OrderBy(e => e.Id).ToList();
        }
    }
}
