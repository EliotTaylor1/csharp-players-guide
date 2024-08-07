Door door = new Door();

int option = 0;
while (option != 5)
{
    PrintUserOptions();
    option = Convert.ToInt32(Console.ReadLine());

    switch (option)
    {
        case 1:
            door.OpenDoor();
            break;
        case 2:
            door.CloseDoor();
            break;
        case 3:
            door.LockDoor();
            break;
        case 4:
            door.ChangePassword();
            break;
        case 5:
            Console.WriteLine("You chose to exit.");
            break;
        default:
            Console.WriteLine("Invalid input.");
            break;
    }
}

void PrintUserOptions()
{
    Console.WriteLine("");
    door.PrintDoorState();
    Console.WriteLine("=======================");
    Console.WriteLine("Choose what operation you would like to perform on the door:");
    Console.WriteLine("1. Open Door");
    Console.WriteLine("2. Close Door");
    Console.WriteLine("3. Lock Door");
    Console.WriteLine("4. Change Door Password");
    Console.WriteLine("5. Exit");
    Console.WriteLine("=======================");
    Console.Write("Input: ");
}

class Door
{
    public HingeState HingeState { get; private set; }
    public LockState LockState { get; private set; }
    public bool PasswordCorrect { get; private set; }
    public string? Password { get; private set; }
    public string? Guess { get; private set; }

    public Door()
    {
        LockState = LockState.Locked;
        HingeState = HingeState.Closed;
        while (Password is null)
        {
            Console.Write("Set password for door: ");
            Password = Console.ReadLine();
        }
        Console.WriteLine("Door password set");
    }

    void CheckPassword()
    {
        Guess = null;
        while (Guess is null)
        {
            Console.Write("Enter door password: ");
            Guess = Console.ReadLine();
        }
        if (Guess == Password)
        {
            PasswordCorrect = true;
        }
        else
        {
            PasswordCorrect = false;
        }
    }

    public void ChangePassword()
    {
        Console.Write("Current password: ");
        Guess = Console.ReadLine();
        if (Guess == Password)
        {
            Password = null;
            while (Password is null)
            {
                Console.Write("Set new password: ");
                Password = Console.ReadLine();
            }
            Console.WriteLine("Password updated.");
        }
        else
        {
            Console.WriteLine("Incorrect existing password.");
        }
    }

    public void PrintDoorState()
    {
        Console.WriteLine($"The door is currently: {HingeState} and {LockState}");
    }

    public void OpenDoor()
    {
        CheckPassword();
        if (HingeState == HingeState.Closed && LockState == LockState.Locked && PasswordCorrect)
        {
            HingeState = HingeState.Open;
            LockState = LockState.Unlocked;
            Console.WriteLine("Door now open.");
        }
        else if (HingeState == HingeState.Open)
        {
            Console.WriteLine("Door is already open.");
        }
        else
        {
            Console.WriteLine("Password Incorrect.");
        }
    }

    public void CloseDoor()
    {
        if (HingeState == HingeState.Open)
        {
            HingeState = HingeState.Closed;
            Console.WriteLine("Door now closed.");
        }
        else
        {
            Console.WriteLine("Door already closed.");
        }

    }

    public void LockDoor()
    {
        if (HingeState == HingeState.Closed && LockState == LockState.Unlocked)
        {
            LockState = LockState.Locked;
            Console.WriteLine("Door now locked.");
        }
        else if (HingeState == HingeState.Open)
        {
            Console.WriteLine("Door not closed.");
        }
        else
        {
            Console.WriteLine("Door is already locked.");
        }

    }
}

enum HingeState
{
    Open,
    Closed,
}

enum LockState
{
    Locked,
    Unlocked
}