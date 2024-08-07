Coordinate a = new Coordinate(10, 5);
Coordinate b = new Coordinate(1, 1);
Coordinate c = new Coordinate(1, 1);

Console.WriteLine(a.CheckAdjacent(a, b));

public readonly struct Coordinate
{
    readonly int Row { get;  init; }
    readonly int Col { get; init; }

    public Coordinate(int row, int col)
    {
        Row = row;
        Col = col;
    }

    public bool CheckAdjacent(Coordinate a, Coordinate b)
    {
        if (a.Row +1 == b.Row) {  return true; }
        if (a.Row -1 == b.Row) { return true; }
        if (a.Col +1 == b.Col) {  return true; }
        if (a.Col -1 == b.Col) { return true; }
        return false;
    }
    
}