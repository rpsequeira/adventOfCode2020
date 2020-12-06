using System;
using Tools;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode2020
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Day 5 of AoC");
            IEnumerable<char[]> data = null;
            Tools.Tools.MeasureActionTime("Load", () =>
            {
                string input = args[0];
                Console.WriteLine($"Loading data from " + input + "...");
                var raw = Tools.Tools.ReadAllLines(input);
                data = LoadData(raw);
                Console.WriteLine($"Length -> {data.Count()}");
            });
            Tools.Tools.MeasureActionTime("Part 1", () =>
            {
                var res = DoMagic(data);
                Console.WriteLine($"Result -> {res}");
            });
            Tools.Tools.MeasureActionTime("Part 2", () =>
            {
                var res = DoMagic2(data);
                Console.WriteLine($"Result -> {res}");
            });
            Console.WriteLine("END");
        }

        static IEnumerable<char[]> LoadData(IEnumerable<string> input)
        {
            foreach (var item in input)
            {
                yield return item.ToArray();
            }
        }

        static int DoMagic(IEnumerable<char[]> input)
        {
            int res = 0;
            HashSet<char> group = new HashSet<char>();
            foreach (var item in input)
            {
                foreach (var answer in item)
                {
                    group.Add(answer);
                }
                if (item.Count() == 0)
                {
                    res += group.Count();
                    group.Clear();
                    continue;
                }
            }
            return res + group.Count();
        }

        static double DoMagic2(IEnumerable<char[]> input)
        {
            int res = 0;
            List<char[]> group = new List<char[]>();
            foreach (var item in input)
            {
                if (item.Count() == 0)
                {
                    res += getCommon(group);
                    group.Clear();
                    continue;
                }
                group.Add(item);
            }
            return res + getCommon(group);
        }

        static int getCommon(List<char[]> input)
        {
            var intersect = input.Aggregate<char[]>((p, n) => p.Intersect(n).ToArray());
            return intersect.Count();
        }
    }
}
