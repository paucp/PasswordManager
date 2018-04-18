using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Test
{
    internal class Program
    {
        public static byte[] MixBytes2(byte[] input, int seed)
        {
            Random RNG = new Random(seed);
            short[] output = new short[input.Length];
            bool[] cellMap = new bool[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                int Index; 
                while(output )
            }
            return output;
        }
        public static byte[] MixBytes(byte[] input, int seed)
        {
            Random RNG = new Random(seed);
            byte[] output = new byte[input.Length];
            bool[] cellMap = new bool[input.Length];        
            for (int i = 0; i < input.Length; i++)
                output[GenerateIndex(cellMap, RNG)] = input[i];
            return output;
        }

        public static byte[] InverseMixBytes(byte[] input, int seed)
        {
            Random RNG = new Random(seed);
            int[] row = GenerateRow(input.Length, RNG);            
            byte[] output = new byte[input.Length];
            for (int i = 0; i < input.Length; i++)
                output[i] = (input[row[i]]);
            return output;
        }
        private static int[] GenerateRow(int count, Random RNG)
        {
            HashSet<int> randomNumbers = new HashSet<int>();
            for (int i = 0; i < count; i++)
                while (!randomNumbers.Add(RNG.Next(count))) ;
            return randomNumbers.ToArray();
        } 

        private static int GenerateIndex(bool[] cellMap, Random RNG)
        {
            int location = RNG.Next(0, cellMap.Length);
            if (cellMap[location])
                return GenerateIndex(cellMap, RNG);
            else
            {
                cellMap[location] = true;
                return location;
            }
        }

        private static Stopwatch sw = new Stopwatch();
        private static Random baseRNG = new Random();
        private static int tests = 10000;

        private static void Main(string[] args)
        {
            DoTest();
            Main(null);
        }

        private static void DoTest()
        {
            int similarity = 0;
            Console.Write("COUNT: ");
            tests = Convert.ToInt32(Console.ReadLine());
            sw.Start();
            for (int i = 0; i < tests; i++)
            {              
                string str = GenerateGUID();            
                byte[] buffer = Encoding.UTF8.GetBytes(str);                
                byte[] mixed = MixBytes(buffer, 0);             
                byte[] unmixed = InverseMixBytes(mixed, 0);           
                //Console.ForegroundColor = ConsoleColor.DarkGray;
                //Console.WriteLine("MIXED:   " + Encoding.UTF8.GetString(mixed));              
                bool result = ByteEquals(buffer, unmixed);
                //if (result)
                  //  Console.ForegroundColor = ConsoleColor.Green;
                //else Console.ForegroundColor = ConsoleColor.Red;
                //Console.WriteLine("UNMIXED: " + Encoding.UTF8.GetString(unmixed));
               // Console.ForegroundColor = ConsoleColor.Gray;
                int sim = CalcSimilarity(mixed, unmixed);
                similarity += sim;
                //Console.WriteLine("SIMILARITY: " + sim);
                //Console.WriteLine();
            }
            sw.Stop();
            Console.WriteLine("TOTAL TIME: " + sw.ElapsedMilliseconds + "ms");
            Console.WriteLine("AVERAGE TIME: " + sw.ElapsedMilliseconds / tests + "ms");
            Console.WriteLine("AVERAGE SIM:" + similarity / tests);
            sw.Reset();
        }

        private static int CalcSimilarity(byte[] array1, byte[] array2)
        {
            int similarity = 0;
            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] == array2[i])
                    similarity++;
            }
            return similarity;
        }

        private static bool ByteEquals(byte[] array1, byte[] array2)
        {
            for (int i = 0; i < array1.Length; i++)
                if (array1[i] != array2[i])
                    return false;
            return true;
        }

        private static string GenerateGUID()
        {
            StringBuilder strb = new StringBuilder();
            strb.Append(Guid.NewGuid().ToString()+ Guid.NewGuid().ToString()+ Guid.NewGuid().ToString()+ Guid.NewGuid().ToString()+ Guid.NewGuid().ToString()+ Guid.NewGuid().ToString()+ Guid.NewGuid().ToString());
            return strb.ToString().Substring(0, baseRNG.Next(strb.Length / 4, strb.Length));
        }
    }
}