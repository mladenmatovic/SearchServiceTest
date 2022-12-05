using SearchServiceTest.Model.Service;

namespace SearchServiceTest.Helpers
{
    public interface IPositionCalculator
    {
        string GetFormattedDistance(double distance);

        string GetStringDistance(Position point1, Position point2);
        double CalculateDistance(Position point1, Position point2);
    }
}
