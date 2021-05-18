namespace Chess
{
    public class Coordinate
    {
        public int Y { get; set; }
        public int X { get; set; }

        public Coordinate(int Y, int X)
        {
            this.Y = Y;
            this.X = X;
        }

        public override bool Equals(object obj)
        {
            return obj is Coordinate coordinate &&
                   Y == coordinate.Y &&
                   X == coordinate.X;
        }

        public override int GetHashCode()
        {
            int hashCode = -1456208474;
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            return hashCode;
        }
    }
}