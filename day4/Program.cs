using System;
using Tools;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace adventofcode2020
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Day 1 of AoC");
            IEnumerable<string> data = null;
            Tools.Tools.MeasureActionTime("Load", () =>
            {
                string input = args[0];
                Console.WriteLine($"Loading data from " + input + "...");
                var raw = Tools.Tools.ReadAllLines(input);
                data = raw;
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


        static int DoMagic(IEnumerable<string> input)
        {

            int res = 0;
            bool byr = false;
            bool iyr = false;
            bool eyr = false;
            bool hgt = false;
            bool hcl = false;
            bool ecl = false;
            bool pid = false;
            bool cid = false;
            foreach (var item in input)
            {
                if (string.IsNullOrEmpty(item))
                {
                    byr = false;
                    iyr = false;
                    eyr = false;
                    hgt = false;
                    hcl = false;
                    ecl = false;
                    pid = false;
                    cid = false;
                }


                if (item.Contains("byr:"))
                {
                    byr = true;

                }
                if (item.Contains("iyr:"))
                {
                    iyr = true;

                }
                if (item.Contains("eyr:"))
                {
                    eyr = true;

                }
                if (item.Contains("hgt:"))
                {
                    hgt = true;

                }
                if (item.Contains("hcl:"))
                {
                    hcl = true;

                }
                if (item.Contains("ecl:"))
                {
                    ecl = true;
                }
                if (item.Contains("pid:"))
                {
                    pid = true;
                }

                if (item.Contains("cid:"))
                {
                    cid = true;
                }

                if (byr && iyr && eyr && hgt && hcl && ecl && pid)
                {
                    res++;
                    byr = false;
                    iyr = false;
                    eyr = false;
                    hgt = false;
                    hcl = false;
                    ecl = false;
                    pid = false;
                    cid = false;
                }

            }

            return res;
        }

        static int DoMagic2(IEnumerable<string> input)
        {

            int res = 0;
            bool byr = false;
            bool iyr = false;
            bool eyr = false;
            bool hgt = false;
            bool hcl = false;
            bool ecl = false;
            bool pid = false;
            bool cid = false;
            foreach (var item in input)
            {
                if (string.IsNullOrEmpty(item))
                {
                    byr = false;
                    iyr = false;
                    eyr = false;
                    hgt = false;
                    hcl = false;
                    ecl = false;
                    pid = false;
                    cid = false;
                }

                if (item.Contains("byr:"))
                {
                    var value = item.Split(' ').Where(s => s.Contains("byr:")).Single().Split(':')[1];
                    if (value.Length == 4)
                    {
                        var year = Int32.Parse(value);
                        if (year >= 1920 && year <= 2002)
                        {
                            byr = true;
                        }
                    }
                }
                if (item.Contains("iyr:"))
                {
                    var value = item.Split(' ').Where(s => s.Contains("iyr:")).Single().Split(':')[1];
                    if (value.Length == 4)
                    {
                        var year = Int32.Parse(value);
                        if (year >= 2010 && year <= 2020)
                        {
                            iyr = true;
                        }
                    }
                }
                if (item.Contains("eyr:"))
                {
                    var value = item.Split(' ').Where(s => s.Contains("eyr:")).Single().Split(':')[1];
                    if (value.Length == 4)
                    {
                        var year = Int32.Parse(value);
                        if (year >= 2020 && year <= 2030)
                        {
                            eyr = true;
                        }
                    }
                }
                if (item.Contains("hgt:"))
                {
                    var value = item.Split(' ').Where(s => s.Contains("hgt:")).Single().Split(':')[1];
                    var impORmet = value.Substring(value.Length - 2);
                    if (impORmet == "cm" || impORmet == "in")
                    {
                        var vNumber = Int32.Parse(value.Substring(0, value.Length - 2));
                        if (impORmet == "cm")
                        {
                            if (vNumber >= 150 && vNumber <= 193)
                            {
                                hgt = true;
                            }
                        }
                        if (impORmet == "in")
                        {
                            if (vNumber >= 59 && vNumber <= 76)
                            {
                                hgt = true;
                            }
                        }
                    }
                }
                if (item.Contains("hcl:"))
                {
                    var value = item.Split(' ').Where(s => s.Contains("hcl:")).Single().Split(':')[1];
                    var regex = "#([0-9a-fA-F]{6})";
                    var match = Regex.Match(value, regex, RegexOptions.IgnoreCase);

                    if (match.Success)
                    {
                        hcl = true;
                    }
                }
                if (item.Contains("ecl:"))
                {
                    var array = new string[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
                    var value = item.Split(' ').Where(s => s.Contains("ecl:")).Single().Split(':')[1];
                    if (array.Contains(value))
                    {
                        ecl = true;
                    }
                }
                if (item.Contains("pid:"))
                {
                    var value = item.Split(' ').Where(s => s.Contains("pid:")).Single().Split(':')[1];
                    var regex = "^[0-9]{9}$";
                    var match = Regex.Match(value, regex, RegexOptions.IgnoreCase);

                    if (match.Success)
                    {
                        pid = true;
                    }
                }
                if (item.Contains("cid:"))
                {
                    cid = true;
                }

                if (byr && iyr && eyr && hgt && hcl && ecl && pid)
                {
                    res++;
                    byr = false;
                    iyr = false;
                    eyr = false;
                    hgt = false;
                    hcl = false;
                    ecl = false;
                    pid = false;
                    cid = false;
                }
            }
            return res;
        }
    }
}
