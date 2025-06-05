using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Common;

namespace Day03;

public static class Program
{
    private const string InputFile = "input.txt";
    static void Main(string[] args)
    {
        var input = FileLoader.LoadFile<Rucksack>(InputFile, line =>
        {
            var firstCompartment = line.Substring(0, line.Length / 2);
            var secondCompartment = line.Substring(line.Length / 2);
            return new Rucksack(firstCompartment, secondCompartment);       
        });
        
        var result = input.Select(r => DataProcessor.CalculatePriority(r)).Sum();
        Console.WriteLine("Result: " + result);
    }
}

public readonly record struct Rucksack
{
    public Rucksack(string firstCompartment, string secondCompartment)
    {   
        FirstCompartment = firstCompartment;
        SecondCompartment = secondCompartment;       
    }
    public readonly string FirstCompartment { get; init; }    
    public readonly string SecondCompartment { get; init; }   
}

public static class DataProcessor
{
    public static int CalculatePriority(Rucksack rucksack)
    {
        var firstComp = rucksack.FirstCompartment.ToList();
        var secondComp = rucksack.SecondCompartment.ToList();
        var allMatches = firstComp.Intersect(secondComp).ToList();
        
        return allMatches.Select(s => GetPriority(s)).Sum();       
    }
    
    private static int GetPriority(char c)
    {
        if (Char.IsLower(c))
        {
            return c - 'a' + 1;
        } else if (Char.IsUpper(c))
        {
            return c - 'A' + 27;
        }
        return 0;
    }
}
