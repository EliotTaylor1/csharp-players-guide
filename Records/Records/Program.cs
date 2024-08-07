Sword basic = new Sword(Material.Iron, Gemstone.Empty, 10, 2);
Sword epic = new Sword(Material.Binarium, Gemstone.Emerald, 15, 5);
Sword another = new Sword(Material.Wood, Gemstone.Emerald, 5.2, 3.2);

Console.WriteLine(basic);
Console.WriteLine(epic);
Console.WriteLine(another);

public enum Material
{
    Wood,
    Bronze,
    Iron,
    Steel,
    Binarium
}

public enum Gemstone
{
    Empty,
    Emerald, 
    Amber,
    Sapphire, 
    Diamond, 
    Bitstone
}

public record Sword(Material M, Gemstone G, double L, double W);