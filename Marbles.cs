using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickTest
{

    public class Marbles
    {
        /// <summary>
        /// Generates an array of random numbers, each number signifying a color based on a set of probabilities. Probabilities are inputed in integer form
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int red, green, blue, orange;
            red = PromptInt("Ratio red marbles?");
            blue = PromptInt("Ratio blue marbles?");
            green = PromptInt("Ratio green marbles?");
            orange = PromptInt("Ratio orange marbles?");

            int[] results = Solve(red, green, blue, orange, 1000);
            WriteOutStats(results);
            Console.ReadLine();
        }

        private static readonly Random mRandom = new Random(); // use to generate random color marble

        public const int RED_MARBLE = 1;
        public const int BLUE_MARBLE = 2;
        public const int GREEN_MARBLE = 3;
        public const int ORANGE_MARBLE = 4;

        public static int[] Solve(int red, int green, int blue, int orange, int count)
        {
            int[] array = new int[count];
            int[] probs = {red, blue, green, orange};
          

            for(int i=0; i<count; i++)
                array[i] = generateNumber(probs);
           
            return array;
        }
        /// <summary>
        /// Generates a random number signifying a color based on a set of probablities in integer form
        /// </summary>
        /// <param name="probs">Probablities in integer form, ex: 40, 30, 20, 10, don't have to add up to 100</param>
        /// <returns>Random number signifying a color</returns>
        public static int generateNumber(int[] probs)
        {
            // we divide the vector into 4 segments and figure out which segment does the number belongs to
            int rnd = mRandom.Next(0, probs.Sum()); // generate the random integer in between 0 and sum of all segments
            int sum = 0;
            int i = 0;
            foreach (int color in probs)
            {
                sum += color;
                i++;

                if(rnd < sum) // find which segment the random number belongs to and retrive the number (i) of that segment
                    break;
                       
            }
            return i;
        }
        /// <summary>
        /// Counts the number of occurences of each color number in the array as well as number of occurances of red number in the first 100 numbers of the array
        /// </summary>
        /// <param name="results"></param>
        public static void WriteOutStats(int[] results)
        {
            int[] counts = { 0, 0, 0, 0 };
            int red100 = 0;
            for (int i = 0; i < results.Length; i++)
            {
                counts[results[i] - 1]++;

                if(i <= 100 & results[i] == 1)
                    red100++;
            }

            Console.WriteLine("red: " + counts[0]);
            Console.WriteLine("blue: " + counts[1]);
            Console.WriteLine("green: " + counts[2]);
            Console.WriteLine("orange: " + counts[3]);

            Console.WriteLine("red in first 100: " + red100);
        }

        public static int PromptInt(string message)
        {
            int ret = -1;
            while (true)
            {
                Console.WriteLine(message);
                string str = Console.ReadLine();
                if (Int32.TryParse(str, out ret))
                    break;
                else
                    Console.WriteLine("'{0}' is invalid", str);
            }
            return ret;
        }
    }
}
