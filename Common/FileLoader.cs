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
    }
}

