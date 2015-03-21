namespace JustBlueberry
{
    // Base structure.
    public struct Point
    {
        public int Row { get; set; }
        public int Col { get; set; }

        public Point(int row, int col)
            : this()
        {
            this.Row = row;
            this.Col = col;
        }
    }
}
