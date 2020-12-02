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
            IEnumerable<Tuple<int,int,char,string>> data = null;
            Tools.Tools.MeasureActionTime("Load", () => {
                string input = args[0];
                Console.WriteLine($"Loading data from " + input + "...");
                var raw = Tools.Tools.ReadAllLines(input);
                data = LoadData(raw);
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

        static IEnumerable<Tuple<int,int,char,string>> LoadData(IEnumerable<string> input)
        {
            foreach (var item in input)
            {
                var policy = item.Split(':')[0];
                var password = item.Split(':')[1].Trim();
                var i = Int32.Parse(policy.Split('-')[0]);
                var j = Int32.Parse(policy.Split('-')[1].Split(' ')[0]);
                var charP = policy.Split(' ')[1].ToCharArray().First();
                yield return new Tuple<int, int, char, string>(i, j, charP, password);
            }
        }

        static int DoMagic(IEnumerable<Tuple<int,int,char,string>> input)
        {
            int res = 0;

            foreach (var item in input)
            {
                var count = item.Item4.ToCharArray().Where(c => c == item.Item3).Count();
                if(count >= item.Item1 && count <= item.Item2){
                    res++;
                }
            }
            return res;
        }

        static int DoMagic2(IEnumerable<Tuple<int,int,char,string>> input)
        {
            int res = 0;

            foreach (var item in input)
            {
                var p1 = item.Item4[item.Item1-1];
                var p2 = item.Item4[item.Item2-1];
                if((p1 == item.Item3 || p2 == item.Item3) && p1 != p2 ){
                    res++;
                }
            }
            return res;        
        }
  
    }
}
