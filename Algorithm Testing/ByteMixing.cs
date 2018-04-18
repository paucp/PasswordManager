using System;
using System.Collections.Generic;
using System.Linq;

namespace PasswordManager.Engine.Crypto
{
    public class ByteMixing
    {
        public static byte[] MixBytes(byte[] input, int seed, int rounds)
        {
            Random RNG = new Random(seed);
            byte[] output = input;
            for (int i = 0; i < rounds; i++)
                output = MixRound(output, RNG, i);
            return output;
        }

        public static byte[] InverseMixBytes(byte[] input, int seed, int rounds)
        {
            Random RNG = new Random(seed);
            int[][] rows = new int[rounds][];
            for (int i = 0; i < rounds; i++)
                rows[i] = GenerateRow(input.Length, RNG);
            byte[] output = input;
            for (int i = rounds; i > 0; i--)
                output = InverseMixRound(output, rows[i - 1], rounds - i);
            return output;
        }

        private static int[] GenerateRow(int count, Random RNG)
        {
            HashSet<int> randomNumbers = new HashSet<int>();
            for (int i = 0; i < count; i++)
                while (!randomNumbers.Add(RNG.Next(count))) ;
            return randomNumbers.ToArray();
        }

        private static byte[] MixRound(byte[] input, Random RNG, int round)
        {
            unchecked
            {
                bool[] cellMap = new bool[input.Length];
                byte[] output = new byte[input.Length];
                for (int i = 0; i < input.Length; i++)
                    output[GenerateIndex(cellMap, RNG)] = (byte)(input[i] ^ round & (round + 1));
                return output;
            }
        }

        private static byte[] InverseMixRound(byte[] input, int[] row, int round)
        {
            unchecked
            {
                byte[] output = new byte[input.Length];
                for (int i = 0; i < input.Length; i++)
                    output[i] = (byte)(input[row[i]] ^ round & (round + 1));
                return output;
            }
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
    }
}