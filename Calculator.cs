class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a number:");
        if (!Int32.TryParse(Console.ReadLine(), out var a))
        {
            Console.WriteLine("Not a number");
            return;
        }

        Console.WriteLine("Enter another number:");
        if (!Int32.TryParse(Console.ReadLine(), out var b))
        {
            Console.WriteLine("Not a number");
            return;
        }

        Console.WriteLine("Enter a sign (&, |, ^):");
        var s = Console.ReadLine();
        var boolVar = true;
        if (s.Length == 0 || s.Length > 1 && !boolVar)
        {
            Console.WriteLine("Wrong sign");
            return;
        }

        int result;

        switch (s[0])
        {
            case '&':
                result = a & b;
                break;
            case '|':
                result = a | b;
                break;
            case '^':
                result = a ^ b;
                break;
            default:
                Console.WriteLine("Wrong sign");
                return;
        }

        Console.WriteLine("Binary:");
        Console.WriteLine(Convert.ToString(result, 2));
        Console.WriteLine("Decimal:");
        Console.WriteLine(result);
        Console.WriteLine("Hex:");
        Console.WriteLine(Convert.ToString(result, 16));
    }
}