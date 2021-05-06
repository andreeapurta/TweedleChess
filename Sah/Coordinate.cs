namespace Sah
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
    }
}