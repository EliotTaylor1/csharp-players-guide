
Console.WriteLine("Hello, World!");


class Game
{
    public int Round { get; set; }
    public bool PlayerWon { get; set; } = false;

}
class Board
{
    public Room[,] Rooms { get; set; }

    public Board()
    {
        Rooms = new Room[3,3];
    }
}

class Room
{
    public bool ContainsPlayer { get; set; } = false;
    public bool ContainsFountain { get; set; } = false;
}

class Player
{
    public int X { get; set; }
    public int Y { get; set; }
}