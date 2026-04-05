namespace HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1a
            int[] fibonacci1 = { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34 };

            for (int i = 0; i < fibonacci1.Length; i++)
            {
                Console.WriteLine(fibonacci1[i]);
            }

            //1b
            int[] fibonacci2 = { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89 };

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(fibonacci2[i]);
            }

            //2
            for (int i = 2; i <= 20; i += 2)
            {
                Console.WriteLine(i);
            }

            //3
            for (int i = 1; i <= 5; i++)
            {
                for (int j = 1; j <= 5; j++)
                {
                    Console.WriteLine($"{i} * {j} = {i * j}");
                }
                Console.WriteLine();
            }

            //4
            string password = "qwerty";
            string input;
            do
            {
                Console.WriteLine("Enter password:");
                input = Console.ReadLine();
                if (input != password)
                {
                    Console.WriteLine("Incorrect password!");
                }

                } while (input != password);
                Console.WriteLine("Correct password");



        }
    }
}