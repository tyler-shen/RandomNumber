using System;
using System.Collections.Generic;

namespace RandomNumber
{
    class Program
    {
        public static List<int> CreateRandomNumberList(int length)
        {
            // validation
            if (length < 1)
            {
                return new List<int>();
            }

            // triple the space to reduce collision
            var nums = new int[length*3];
            var occupied = new bool[length*3];

            var random = new Random();
            for (var i = 1; i <= length; ++i)
            {
                var pos = random.Next(0, length*3);
                while (true)
                {
                    // if this position is occupied, move to next position
                    if (!occupied[pos])
                    {
                        break;
                    }
                    pos = (pos + 1) % length;
                }
                occupied[pos] = true;
                nums[pos] = i;
            }

            // clear the list
            var retValue = new List<int>();
            for (var j = 0; j < length*3; ++j)
            {
                if (nums[j] != 0)
                {
                    retValue.Add(nums[j]);
                }
            }
            return retValue;
        }

        static void Main()
        {
            var length = 10000;
            var numList = CreateRandomNumberList(length);
            numList.ForEach(x => Console.Write(string.Concat(x, " ")));
            Console.ReadLine();
        }
    }
}
