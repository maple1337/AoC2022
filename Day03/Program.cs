using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Common;
using System.Runtime.ExceptionServices;

namespace Day03;

public static class Program
{
    private const string InputFile = "..//..//..//input.txt";
    static void Main(string[] args)
    {
        var input = FileLoader.LoadFile<Rucksack>(InputFile, line =>
        {
            var firstCompartment = line.Substring(0, line.Length / 2);
            var secondCompartment = line.Substring(line.Length / 2);
            return new Rucksack(firstCompartment, secondCompartment);       
        });

        var inputP2 = FileLoader.LoadFileInGroupsOfThree<String>(InputFile);
        
        var part1 = input.Select(r => DataProcessor.CalculatePriority(r)).Sum();
        Console.WriteLine("Result Part1: " + part1);
        var part2 = DataProcessor.CalculateBadgePriority(inputP2);
        Console.WriteLine("Result Part2: " + part2);
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
        var firstComp = rucksack.FirstCompartment;
        var secondComp = rucksack.SecondCompartment;
        var allMatches = firstComp.Intersect(secondComp).ToList();
        
        return allMatches.Select(s => GetPriority(s)).Sum();       
    }

    public static int CalculateBadgePriority(List<List<String>> elfgroups)
    {
        var commonChars = elfgroups.Select(group =>
        {
            var common = group[0].Intersect(group[1]).Intersect(group[2]);
            return common.FirstOrDefault();
        }).ToList();

        return commonChars.Select(s => GetPriority(s)).Sum();
    }

    private static int GetPriority(char c)
    {
        if (Char.IsLower(c))
        {
            return c - 'a' + 1;
        } 
        else if (Char.IsUpper(c))
        {
            return c - 'A' + 27;
        }
        return 0;
    }
}

