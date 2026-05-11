using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Classes2
{
    internal struct Interval
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public int Get { get 
            {
            return Random.Next(Min, Max) ;
            } 
        }

        public Random Random = new Random(); 

        public Interval(int minValue, int maxValue) 
        {  
            Min = minValue; 
            Max = maxValue;

            if (minValue > maxValue)
            {
                (minValue, maxValue) = (maxValue, minValue);
                Console.WriteLine($"Некорректные данные");
            }
            if (minValue < 0)
            {
                minValue = 0;
                Console.WriteLine("Некорректные данные");
            }
            if (maxValue < 0)
            {
                maxValue = 0;
                Console.WriteLine("Некорректные данные");
            }
            if (minValue == maxValue)
            {
                maxValue += 10;
                Console.WriteLine("Некорректные данные");
            }
        }
        
    }
}
