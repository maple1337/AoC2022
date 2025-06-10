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
        var input = FileLoader.LoadFile<Rucksack>(InputFile, Converter);

        var inputP2 = FileLoader.LoadFileInGroupsOfThree<ElfGroup>(InputFile, Converter2);
        
        var part1 = input.Select(DataProcessor.CalculatePriority).Sum();
        Console.WriteLine("Result Part1: " + part1);
        var part2 = inputP2.Select(DataProcessor.CalculateBadgePriority).Sum();
        Console.WriteLine("Result Part2: " + part2);
    }
    public static Rucksack Converter(string line)
    {
        var firstCompartment = line.Substring(0, line.Length / 2);
        var secondCompartment = line.Substring(line.Length / 2);
        return new Rucksack(firstCompartment, secondCompartment);
    }

    public static ElfGroup Converter2(string[] rucksaecke)
    {
        var firstElf = rucksaecke[0];
        var secondElf = rucksaecke[1];
        var thirdElf = rucksaecke[2];
        return new ElfGroup(firstElf, secondElf, thirdElf);       
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

public readonly record struct ElfGroup
{
    public ElfGroup(string firstElf, string secondElf, string thirdElf)
    {
        String[] elf = { firstElf, secondElf, thirdElf };
        Elf = elf;       
    }
    
    public readonly string[] Elf { get; init; }  
    
}


public static class DataProcessor
{
    public static int CalculatePriority(Rucksack rucksack)
    {
        var firstComp = rucksack.FirstCompartment;
        var secondComp = rucksack.SecondCompartment;
        var allMatches = firstComp.Intersect(secondComp).ToList();
        
        return allMatches.Select(GetPriority).Sum();       
    }

    public static int CalculateBadgePriority(ElfGroup elfGroup)
    {
        var firstBackpack = elfGroup.Elf[0];
        var secondBackpack = elfGroup.Elf[1];
        var thirdBackpack = elfGroup.Elf[2];
        
        var commonChars = firstBackpack.Intersect(secondBackpack).Intersect(thirdBackpack);

        return commonChars.Select(GetPriority).Sum();
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

