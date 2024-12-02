using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024
{
    internal class Day2 : IAdventOfCode
    {
        public object Part1(string[] input)
        {
            List<int[]> rows = GetRows(input);
            int result = 0;

            foreach (int[] row in rows)
            {
                var diffs = GetDiffs(row);

                if (IsAscending(diffs) || IsDescending(diffs))
                {
                    result++;
                }
            }

            return result;
        }

        public object Part2(string[] input)
        {
            List<int[]> rows = GetRows(input);
            int result = 0;

            foreach (int[] row in rows)
            {
                var diffs = GetDiffs(row).ToList();

                if (IsAscending(diffs) || IsDescending(diffs))
                {
                    result++;
                    continue;
                }

                for(int i = 0; i < row.Length; i++)
                {
                    var row_butOneFuckingDied = new List<int>(row);
                    row_butOneFuckingDied.RemoveAt(i); // That number fucking dies, haha

                    var diffs2 = GetDiffs(row_butOneFuckingDied.ToArray());

                    if (IsAscending(diffs2) || IsDescending(diffs2))
                    {
                        result++;
                        break;
                    }
                }
            }

            return result;
        }

        private static List<int[]> GetRows(string[] input)
        {
            return input
                .Select(line => line.Split(' ') 
                    .Select(str => int.Parse(str)) 
                    .ToArray() 
                )
                .ToList();  
        }

        private static bool IsAscending(IEnumerable<int> diffs)
            => diffs.All(d => (d >= 1 && d <= 3));

        private static bool IsDescending(IEnumerable<int> diffs)
            => diffs.All(d => (d <= -1 && d >= -3));

        private static int[] GetDiffs(int[] values)
        {
            int[] diffs = new int[values.Length - 1];
            for (int i = 0; i < values.Length - 1; i++)
            {
                diffs[i] = values[i + 1] - values[i];
            }
            return diffs;
        }
    }
}
