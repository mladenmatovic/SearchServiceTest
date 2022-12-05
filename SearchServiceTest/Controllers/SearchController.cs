using Microsoft.AspNetCore.Mvc;
using SearchServiceTest.Repository;
using SearchServiceTest.Model.Response;
using SearchServiceTest.Model.Service;
using SearchServiceTest.Helpers;

namespace SearchServiceTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly ILogger<SearchController> _logger;
        private IRepository<BokaService> _repository;
        private IPositionCalculator _positonCalculator;
        private ISimilarityCalculator _similarityCalculator;

        public SearchController(ILogger<SearchController> logger, IRepository<BokaService> repository, IPositionCalculator positonCalculator, ISimilarityCalculator similarityCalculator)
        {
            _logger = logger;            
            _repository = repository;
            _positonCalculator = positonCalculator;
            _similarityCalculator = similarityCalculator;
        }      

        [HttpGet(Name = "Search")]        
        public SearchResponse GetByNameAndAddress([FromQuery] string serviceName, [FromQuery] string geoLocation)
        {
            var searchPosition = PositionHelper.CreateGeoPosition(geoLocation);

            if (searchPosition == null)
                return new SearchResponse();
                       
            IEnumerable<BokaService> serviceMatch = _repository.GetAll().Where(item => _similarityCalculator.CalculateSimilarity(serviceName, item.Name) > 0.6);
                      
            return GetResponse(serviceName, searchPosition, _repository.GetAll().Count, serviceMatch);
        }

        private SearchResponse GetResponse(string searchName, Position searchPosition, int totalDocumens, IEnumerable<BokaService> serviceMatch)
        {
            SearchResponse response = new SearchResponse();
            response.TotalHits = serviceMatch.Count();
            response.TotalDocuments = totalDocumens;
            response.Results = new List<RespsonseResult>(response.TotalHits);

            foreach (var match in serviceMatch)
            {
                RespsonseResult res = new RespsonseResult();
                res.Id = match.Id;
                res.Name = match.Name;
                res.Position = new Position(match.Position.Lat, match.Position.Lng);
                res.Distance = _positonCalculator.GetStringDistance(searchPosition, match.Position);
                res.Score = _similarityCalculator.GetScore(searchName, match.Name);
                response.Results.Add(res);
            }

            return response;
        }
    }
}