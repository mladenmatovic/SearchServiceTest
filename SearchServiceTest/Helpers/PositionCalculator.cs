using SearchServiceTest.Model.Service;

namespace SearchServiceTest.Helpers
{
    public class PositionCalculator : IPositionCalculator
    {
        /// <summary>
        /// Format string distance to meters (suffix 'm') or kilometers (suffix 'km' with 2 decimal points)
        /// <param name="distance"></param>
        /// </summary>
        public string GetFormattedDistance(double distance)
        {
            if (distance < 1000)
                return $"{Math.Round(distance)}m";
            else
                return $"{Math.Round(distance / 1000, 2)}km";
        }

        /// <summary>
        /// Calculates distance and returns formatted result 
        /// e.g. to meters (suffix 'm') or kilometers (suffix 'km' with 2 decimal points)
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// </summary>
        public string GetStringDistance(Position point1, Position point2)
        {
            var distance = CalculateDistance(point1, point2);

            return GetFormattedDistance(distance);
        }

        /// <summary>
        /// Returns distanace in meters between to geo locations
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// </summary>
        public double CalculateDistance(Position point1, Position point2)
        {
            var d1 = point1.Lat * (Math.PI / 180.0);
            var num1 = point1.Lng * (Math.PI / 180.0);
            var d2 = point2.Lat * (Math.PI / 180.0);
            var num2 = point2.Lng * (Math.PI / 180.0) - num1;
            var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) +
                     Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);
            return 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3)));
        }
    }
}
