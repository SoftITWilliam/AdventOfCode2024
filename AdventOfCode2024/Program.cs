// See https://aka.ms/new-console-template for more information
using AdventOfCode2024;

const int day = 2;

IAdventOfCode adventOfCode = day switch
{
    1 => new Day1(),
    2 => new Day2(),
    //3 => new Day3(),
    //4 => new Day4(),
    //5 => new Day5(),
    //6 => new Day6(),
    //7 => new Day7(),
    //8 => new Day8(),
    //9 => new Day9(),
    //10 => new Day10(),
    //There is no way I make it past day 10, so I will not continue preparing these
    _ => throw new Exception("No")
};

string[] input = File.ReadAllLines($"C:\\Users\\salad\\source\\repos\\AdventOfCode2024\\AdventOfCode2024\\Input{day}.txt");

try
{
    Console.WriteLine(adventOfCode.Part1(input));
}
catch (Exception ex)
{
    Console.WriteLine($"Day {day} Part 1 Error: \n" + ex);
}

Console.WriteLine("");
Console.WriteLine("~~~~~~~~~~~~~~~~"); // haha, penis?
Console.WriteLine("");

try
{
    Console.WriteLine(adventOfCode.Part2(input));
}
catch (Exception ex)
{
    Console.WriteLine($"Day {day} Part 2 Error: \n" + ex);
}

interface IAdventOfCode
{
    object Part1(string[] input);
    object Part2(string[] input);
}