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
            IEnumerable<Tuple<string, int, int, int>> data = null;
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

        static IEnumerable<Tuple<string, int, int, int>> LoadData(IEnumerable<string> input)
        {
            foreach (var item in input)
            {
                var row = getBSP(item.Substring(0, 7), 127);
                var seat = getBSP(item.Substring(7, 3), 7);
                yield return new Tuple<string, int, int, int>(item, row, seat, row * 8 + seat);
            }
        }

        static int getBSP(string input, int size)
        {
            int rowMin = 0, rowMax = size;

            foreach (var item in input)
            {
                int inc = (rowMax - rowMin + 1) / 2;
                if (item == 'F' || item == 'L')
                {
                    rowMax -= inc;
                }
                if (item == 'B' || item == 'R')
                {
                    rowMin += inc;
                }
            }
            if (rowMin == rowMax)
            {
                return rowMin;
            }
            Console.WriteLine($"Error not found {input}|{rowMin}|{rowMax}");
            return -1;
        }

        static int DoMagic(IEnumerable<Tuple<string, int, int, int>> input)
        {
            return input.OrderByDescending(t => t.Item4).First().Item4;
        }

        static double DoMagic2(IEnumerable<Tuple<string, int, int, int>> input)
        {
            bool lastRowComplete = false;
            bool candidateRow = false;
            int res = -1;
            var array = input.ToArray();

            for (int i = 0; i < 128; i++)
            {
                int numberOfSeats = input.Where(t => t.Item2 == i).Count();

                if (numberOfSeats == 7 && lastRowComplete)
                {
                    candidateRow = true;
                    lastRowComplete = false;
                    res = i;
                    continue;
                }

                if (candidateRow && numberOfSeats == 8)
                {
                    break;
                }

                if (numberOfSeats == 8)
                {
                    lastRowComplete = true;
                }
                else
                {
                    lastRowComplete = false;
                }
                candidateRow = false;
                res = -1;
            }
            for (int i = 0; i < 8; i++)
            {
                var tempId = res * 8 + i;
                if (!input.Any(t => t.Item2 == res && t.Item4 == tempId))
                {
                    return tempId;
                }
            }
            return -1;
        }

    }
}
