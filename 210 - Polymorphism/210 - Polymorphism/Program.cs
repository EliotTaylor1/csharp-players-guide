

Robot robot = new Robot();
IRobotCommand turnOn = new OnCommand();
turnOn.Run(robot);

for (int i = 0; i < robot.Commands.Length; i++)
{
    Console.Write("Enter choice (0-3): ");
    int choice;
    choice = Convert.ToInt32(Console.ReadLine());
    IRobotCommand command;
    switch (choice)
    {
        case 0:
            command = new NorthCommand();
            robot.Commands[i] = command;
            break;
        case 1:
            command = new SouthCommand();
            robot.Commands[i] = command;
            break;
        case 2:
            command = new EastCommand();
            robot.Commands[i] = command;
            break;
        case 3:
            command = new WestCommand();
            robot.Commands[i] = command;
            break;
        default:
            break;
    }
}
Console.WriteLine("Commands set.Running robot.");

robot.Run();
public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public IRobotCommand?[] Commands { get; } = new IRobotCommand?[3];
    public void Run()
    {
        foreach (IRobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}

public interface IRobotCommand
{
    public void Run(Robot robot);
}

public class OnCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.IsPowered = true;
    }
}

public class OffCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
}

public class NorthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered == true) { robot.X++; }
    }
}

public class SouthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered == true) { robot.X--; }
    }
}

public class EastCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered == true) { robot.Y++; }
    }
}

public class WestCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered == true) { robot.Y--; }
    }
}