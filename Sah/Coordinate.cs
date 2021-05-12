namespace Chess
{
    public class Coordinate
    {
        public int Line { get; set; }
        public int Column { get; set; }

        public Coordinate(int line, int column)
        {
            Line = line;
            Column = column;
        }

        public override bool Equals(object obj)
        {
            return obj is Coordinate coordinate &&
                   Line == coordinate.Line &&
                   Column == coordinate.Column;
        }

        public override int GetHashCode()
        {
            int hashCode = -1456208474;
            hashCode = hashCode * -1521134295 + Line.GetHashCode();
            hashCode = hashCode * -1521134295 + Column.GetHashCode();
            return hashCode;
        }
    }
}