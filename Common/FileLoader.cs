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

        public static List<List<String>> LoadFileInGroupsOfThree<T>(string path) 
        {
            var groupsOfThree = (File.ReadAllLines(path)
                .Select((line, index) => new { Line = line, GroupId = index / 3 })
                .GroupBy(x => x.GroupId)
                .Select(group => group.Select(x => x.Line).ToList())
                .ToList());
            return groupsOfThree;
        }
    }
}

