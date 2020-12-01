using System;
using Tools;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Day 1 of AoC");
            IEnumerable<int> data = null;
            Tools.Tools.MeasureActionTime("Load", () => {
                string input = args[0];
                Console.WriteLine($"Loading data from " + input + "...");
                var raw = Tools.Tools.ReadAllLines(input);
                data = LoadData(raw).OrderBy(i => i);
                Console.WriteLine($"Length -> {data.Count()}");
            });
            Tools.Tools.MeasureActionTime("Part 1", () => {
                var res = DoMagic(data);
                Console.WriteLine($"Result -> {res}");
            });
            Tools.Tools.MeasureActionTime("Part 2", () => {
                var res = DoMagic2(data);
                Console.WriteLine($"Result -> {res}");
            });
            Console.WriteLine("END");
        }

        static IEnumerable<int> LoadData(IEnumerable<string> input)
        {
            foreach (var item in input)
            {
                yield return Int32.Parse(item);
            }
        }

        static int DoMagic(IEnumerable<int> input)
        {
            var array = input.ToArray();

            for (int i = 0; i < array.Count(); i++)
            {
                for (int j = array.Count() - 1; j > i; j--)
                {
                    if (array[i] + array[j] == 2020)
                    {
                        Console.WriteLine($"Chosen ->{array[i]}|{array[j]}");
                        return array[i] * array[j];
                    }

                    if (array[i] > 2020 / 2)
                    {
                        return -2;
                    }
                }
            }
            return -1;
        }

        static int DoMagic2(IEnumerable<int> input)
        {
            var array = input.ToArray();

            for (int i = 0; i < array.Count(); i++)
            {
                for (int j = array.Count() - 1; j > i; j--)
                {
                    for (int z = i+1; z<j; z++)
                    if (array[i] + array[j] + array[z] == 2020)
                    {
                        Console.WriteLine($"Chosen ->{array[i]}|{array[j]}|{array[z]}");
                        return array[i] * array[j] * array[z];
                    }

                    if (array[i] > 2020 / 2)
                    {
                        return -2;
                    }
                }
            }
            return -1;
        }
  
    }
}

