PasswordValidator password = new PasswordValidator();

password.CheckPasswordValid();

Console.WriteLine($"Password is valid: {password.IsValid}");

class PasswordValidator
{
    public string? Password { get; private set; }
    public bool IsValid { get; private set; }

    private bool _lengthValid = false;

    private bool _charactersValid = false;

    public PasswordValidator()
    {
        while (Password is null)
        {
            Console.Write("Set password: ");
            Password = Console.ReadLine();
        }
        Console.WriteLine("Password set.");
    }

    private void CheckLength()
    {
        if (Password?.Length > 6 && Password?.Length < 13)
        {
            _lengthValid = true;
        }
        else
        {
            _lengthValid = false;
        }
    }

    private void CheckCharacters()
    {
        foreach (var letter in Password) 
        { 
            if (char.IsUpper(letter))
            {
                _charactersValid = true;
                break;
            }
        }
    }

    public bool CheckPasswordValid()
    {
        CheckLength();
        CheckCharacters();
        if (_lengthValid && _charactersValid)
        {
            return IsValid = true;
        }
        else
        {
            return IsValid = false;
        }
    }
}
