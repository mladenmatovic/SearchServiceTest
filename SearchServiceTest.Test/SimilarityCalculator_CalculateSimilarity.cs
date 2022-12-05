using Newtonsoft.Json.Linq;
using SearchServiceTest.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchServiceTest.Test
{
    [TestClass]
    public class SimilarityCalculator_CalculateSimilarity
    {
        private ISimilarityCalculator _similarityCalculator;

        public SimilarityCalculator_CalculateSimilarity()
        {
            _similarityCalculator = new SimilarityCalculator();            

        }
        [TestMethod]
        [DataRow("Massage", "My Massage", 0.7)]
        [DataRow("Thai massage", "Thai massör", 0.8)]
        [DataRow("Massage 30 min", "Massage 30m", 0.8)]
        public void CalculateSimilarity_IsCorrect(string firstValue, string secondValue, double expected)
        {
            double similarity = _similarityCalculator.CalculateSimilarity(firstValue, secondValue);

            Assert.IsTrue(Math.Round(similarity, 1) == expected);
        }
    }
}
