using EOLib.Domain.Map;
using EOLib.IO.Map;

namespace EOLib.Domain.Extensions
{
    public static class MapFilePropertiesExtensions
    {
        public static bool IsInBounds(this IMapFileProperties mapFileProperties, int x, int y)
        {
            return IsInBounds(mapFileProperties, new MapCoordinate(x, y));
        }

        public static bool IsInBounds(this IMapFileProperties mapFileProperties, MapCoordinate mapCoordinate)
        {
            return mapCoordinate >= MapCoordinate.Zero && mapCoordinate <= new MapCoordinate(mapFileProperties.Width, mapFileProperties.Height);
        }
    }
}
