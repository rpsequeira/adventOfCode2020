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
            Console.WriteLine("Day 1 of AoC");
            IEnumerable<char[]> data = null;
            Tools.Tools.MeasureActionTime("Load", () => {
                string input = args[0];
                Console.WriteLine($"Loading data from " + input + "...");
                var raw = Tools.Tools.ReadAllLines(input);
                data = LoadData(raw);
                Console.WriteLine($"Length -> {data.Count()}");
            });
            Tools.Tools.MeasureActionTime("Part 1", () => {
                var res = DoMagic(data.ToArray());
                Console.WriteLine($"Result -> {res}");
            });
            Tools.Tools.MeasureActionTime("Part 2", () => {
                var res = DoMagic2(data.ToArray());
                Console.WriteLine($"Result -> {res}");
            });
            Console.WriteLine("END");
        }

        static IEnumerable<char[]> LoadData(IEnumerable<string> input)
        {
            foreach (var item in input)
            {
                yield return item.ToCharArray();
            }
        }

        static int DoMagic(char[][] input, int xStep = 3, int yStep = 1)
        {
                        
            int x = 0, y = 0, res = 0;
            while(true)
            {
                x = x + xStep;
                y = y + yStep;                

                if(y >= input.Count()) {
                    break;
                } 

                if(x >= input[y].Count()){
                    x = x - input[y].Count();
                }

                if(input[y][x] == '#'){
                    res++;
                }
            }
            return res;
        }

        static double DoMagic2(char[][] input)
        {
            var test1 = DoMagic(input, 1, 1);
            var test2 = DoMagic(input, 3, 1);
            var test3 = DoMagic(input, 5, 1);
            var test4 = DoMagic(input, 7, 1);
            var test5 = DoMagic(input, 1, 2);
            return (double)test1 * test2 * test3 * test4 * test5;
        }
  
    }
}
