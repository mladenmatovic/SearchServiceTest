using SearchServiceTest.Helpers;
using SearchServiceTest.Model.Service;

namespace SearchServiceTest.Test
{
    [TestClass]
    public class PositionCalculator_CalculateDistance
    {
        private IPositionCalculator _positonCalculator;
        private readonly Position _firstPosition;
        private readonly Position _secondPosition;
        public PositionCalculator_CalculateDistance()
        {
            _positonCalculator = new PositionCalculator();
            _firstPosition = PositionHelper.CreateGeoPosition("59.3320299, 18.023149800000056");
            _secondPosition = PositionHelper.CreateGeoPosition("56.3200, 18.5120000042");
        }

        [TestMethod]
        public void CalculateDistance_IsCorrect()
        {
            // TO DO
            // cover corner cases
            double expected = 336458.6;
            double actual = _positonCalculator.CalculateDistance(_firstPosition, _secondPosition);
            double delta = 0.1;
            Assert.AreEqual(expected, actual, delta);
        }

        [TestMethod]
        public void GetStringDistance_IsCorrect()
        {
            // TO DO
            // cover corner cases
            string expected = "336,46km";
            string actual = _positonCalculator.GetStringDistance(_firstPosition, _secondPosition);            
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(1, "1m")]
        [DataRow(999, "999m")]
        [DataRow(1000, "1km")]
        [DataRow(1001, "1km")]
        [DataRow(15201.235, "15,2km")]
        [DataRow(23591.235, "23,59km")]
        public void GetFormattedDistance_IsCorrect(double distance, string expected)
        {       
            string actual = _positonCalculator.GetFormattedDistance(distance);
            Assert.AreEqual(expected, actual);
        }
    }
}