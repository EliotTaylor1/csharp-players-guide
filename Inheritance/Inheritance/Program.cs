Pack pack = new Pack(10,10,5);

int choice = 0;
while (choice !=7)
{
    Console.WriteLine(pack);
    pack.PrintPackStats();
    Console.Write("Enter number for item to enter: ");
    choice = Convert.ToInt32(Console.ReadLine());
    switch (choice)
    {
        case 1:
            InventoryItem newArrow = new Arrow();
            pack.Add(newArrow);
            break;
        case 2:
            InventoryItem newBow = new Bow();
            pack.Add(newBow);
            break;
        case 3:
            InventoryItem newRope = new Rope();
            pack.Add(newRope);
            break;
        case 4:
            InventoryItem newWater = new Water();
            pack.Add(newWater);
            break;
        case 5:
            InventoryItem newFood = new Food();
            pack.Add(newFood);
            break;
        case 6:
            InventoryItem newSword = new Sword();
            pack.Add(newSword);
            break;
        case 7:
            break;
        default:
            Console.WriteLine("Invalid input");
            break;
    }
}

class Pack
{
    private List<InventoryItem> Contents { get; set; }
    private int MaxWeight { get; set; }
    private int MaxItems { get;  set; }
    private int MaxVolume { get;  set; }
    private double CurrentWeight { get; set; }
    private double CurrentVolume { get; set; }

    public Pack(int maxweight, int maxvolume, int maxitems)
    {
        Contents = new List<InventoryItem>();
        MaxWeight = maxweight;
        MaxItems = maxitems;
        MaxVolume = maxvolume;
        CurrentWeight = 0;
        CurrentVolume = 0;
    }

    public void PrintPackStats()
    {
        Console.WriteLine($"Pack weight: {CurrentWeight} / {MaxWeight}");
        Console.WriteLine($"Pack volume: {CurrentVolume} / {MaxVolume}");
        Console.WriteLine($"Items in pack: {Contents.Count} / {MaxItems}");
        Console.WriteLine("===================");
    }

    public override string ToString()
    {
        string contents = "Pack currently contains: ";
        if (Contents.Count == 0)
        {
            return "Pack is empty.";
        }
        foreach (var item in Contents)
        {
            contents += item.ToString() + " ";
        }
        return contents;
    }

    public void Add(InventoryItem item)
    {
        if (Contents.Count +1 > MaxItems)
        {
            Console.WriteLine("Unable to add new item, too many items.");
            Console.WriteLine("=================");
        }
        else if (CurrentVolume + item.Volume > MaxVolume)
        {
            Console.WriteLine("Unable to add new item, volume.");
            Console.WriteLine("=================");

        }
        else if (CurrentWeight + item.Weight > MaxWeight)
        {
            Console.WriteLine("Unable to add new item, weight.");
            Console.WriteLine("=================");
        }
        else
        {
            Console.WriteLine("Item added successfully.");
            Contents.Add(item);
            CurrentVolume += item.Volume;
            CurrentWeight += item.Weight;
            Console.WriteLine("=================");
        }
    }
}
class InventoryItem
{
    public double Weight { get; private set; }
    public double Volume { get; private set; }

    public InventoryItem(double weight, double volume)
    {
        Weight = weight;
        Volume = volume;
    }
}

class Arrow : InventoryItem
{
    public Arrow() : base(1, 0.05)
    {

    }
    public override string ToString()
    {
        return "Arrow";
    }
}

class Bow : InventoryItem
{
    public Bow() : base(1, 4)
    {

    }
}

class Rope : InventoryItem
{
    public Rope() : base(1, 1.5)
    {

    }
}

class Water : InventoryItem
{
    public Water() : base(2, 3)
    {

    }
}
class Food : InventoryItem
{
    public Food() : base(1, 0.5)
    {

    }
}
class Sword : InventoryItem
{
    public Sword() : base(5, 3)
    {

    }
}