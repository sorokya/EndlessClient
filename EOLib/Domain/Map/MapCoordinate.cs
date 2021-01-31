namespace EOLib.Domain.Map
{
    public struct MapCoordinate
    {
        public static MapCoordinate Zero { get; } = new MapCoordinate(0, 0);

        public int X { get; }

        public int Y { get; }

        public MapCoordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static MapCoordinate operator -(MapCoordinate lhs, MapCoordinate rhs)
        {
            return new MapCoordinate(lhs.X - rhs.X, lhs.Y - rhs.Y);
        }

        public static bool operator ==(MapCoordinate left, MapCoordinate right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(MapCoordinate left, MapCoordinate right)
        {
            return !(left == right);
        }

        public static bool operator >=(MapCoordinate left, MapCoordinate right)
        {
            return left.X >= right.X && left.Y >= right.Y;
        }

        public static bool operator <=(MapCoordinate left, MapCoordinate right)
        {
            return left.X <= right.X && left.Y <= right.Y;
        }

        public override string ToString() => $"{X}, {Y}";

        public override bool Equals(object obj)
        {
            if (!(obj is MapCoordinate))
                return false;

            var other = (MapCoordinate) obj;
            return X == other.X && Y == other.Y;
        }

        public override int GetHashCode()
        {
            var hash = 397 ^ X.GetHashCode();
            hash = (hash * 397) ^ Y.GetHashCode();
            return hash;
        }
    }
}
