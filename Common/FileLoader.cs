using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Common
{
    public static class FileLoader
    {
        public static List<T> LoadFile<T>(string path, Func<string, T> converter)
        {
            return File.ReadAllLines(path)
                        .Select(converter)
                        .ToList();
        }

        public static List<T> LoadFileInGroupsOfThree<T>(string path, Func<string[], T> converter)
        {
            return File.ReadAllLines(path)
                .Select((line, index) => new { Line = line, GroupId = index / 3 })
                .GroupBy(x => x.GroupId)
                .Select(group => group
                    .Select(x => x.Line)
                    .ToArray())
                    .Select(converter)
                    .ToList();
        }

        public static T LoadFileAsArray<T>(string path, Func<char[], T> converter)
        {
            return converter(File.ReadAllText(path).ToCharArray());
        }
    }
}

