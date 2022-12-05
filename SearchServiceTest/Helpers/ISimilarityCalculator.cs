namespace SearchServiceTest.Helpers
{
    public interface ISimilarityCalculator
    {
        int GetScore(string serviceName, string matchName);
        double CalculateSimilarity(string source, string target);
    }
}
