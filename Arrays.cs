using System.Text;

namespace HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1
            int[] numbers = new int[] { 0, 1, 1, 2, 3, 5, 8, 13 };

            //2
            string[] months = new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

            //3
            int[,] myArray = new int[3, 3]
            {
                {2, 3, 4},
                {4, 9, 16},
                {8, 27, 64}
            };

            //4
            double[][] a = new double[3][] {
                new double[] {1, 2, 3, 4, 5},
                new double[] {Math.E, Math.PI},
                new double[] {Math.Log10(1), Math.Log10(10), Math.Log10(100), Math.Log10(1000)}
            };

            //Б
            int[] array = { 1, 2, 3, 4, 5 };
            int[] array2 = { 7, 8, 9, 10, 11, 12, 13 };

            //5
            Array.Copy(array, array2, 3);

            //6
            Array.Resize(ref array, array.Length*2);
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }

    }
}