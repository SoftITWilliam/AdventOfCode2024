using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024
{
    internal class Day1 : IAdventOfCode
    {
        public object Part1(string[] input)
        {
            (List<int> left, List<int> right) = ParseColumns(input);
            left.Sort();
            right.Sort();

            int result = 0;

            foreach (var (Left, Right) in left.Zip(right))
            {
                result += Math.Abs(Left - Right);
            }

            return result;
        }

        public object Part2(string[] input)
        {
            (List<int> left, List<int> right) = ParseColumns(input);

            var map = new Dictionary<int, int>();

            foreach (int value in right.Distinct())
            {
                map.Add(value, right.Count(v => v == value));
            }

            int result = 0;

            foreach (int value in left)
            {
                if (map.TryGetValue(value, out int count))
                {
                    result += value * count;
                }
            }

            return result;
        }


        private (List<int> left, List<int> right) ParseColumns(string[] input)
        {
            var left = input.Select(line => int.Parse(line.Substring(0, 5))).ToList();
            var right = input.Select(line => int.Parse(line.Substring(8, 5))).ToList();
            return (left, right);
        }
    }
}
