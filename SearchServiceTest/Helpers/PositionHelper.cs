using SearchServiceTest.Helpers;
using SearchServiceTest.Model.Service;
using System.Globalization;

namespace SearchServiceTest
{
    public class PositionHelper
    {
        /// <summary>
        /// Creates Geo Position with longitude and latitde from string Geo Location
        /// <param name="geoLocation"></param>
        /// </summary>        
        public static Position CreateGeoPosition(string geoLocation)
        {
            if (geoLocation.Split(',').Count() != 2)
                return null;

            Position searchPosition = new Position();
            bool validData;
            double helperCoordinate;
           
            validData = TryParseDouble(geoLocation.Split(',')[0].Trim(), out helperCoordinate);
            if (validData)
                searchPosition.Lat = helperCoordinate;
            validData = TryParseDouble(geoLocation.Split(',')[1].Trim(), out helperCoordinate);
            if (validData)
                searchPosition.Lng = helperCoordinate;

            if (validData)
                return searchPosition;
            else
                return null;
        }

        private static bool TryParseDouble(string value, out double parsedValue)
        { 
            bool isValid = double.TryParse(value, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out parsedValue);

            return isValid;
        }        
    }
}
