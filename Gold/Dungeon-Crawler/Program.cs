using System;
using System.IO;
using System.Reflection;
using Dungeon_Crawler.Structure;

namespace Dungeon_Crawler
{
    class Program
    {
        private static string IncludePath = "./level-data/";
        private static string ExecutableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        private static string PathToBase = @"..\..\..\";
        static void Main(string[] args)
        {
            Directory.SetCurrentDirectory(ExecutableLocation);
            Directory.SetCurrentDirectory(PathToBase);
            Directory.SetCurrentDirectory(IncludePath);
            Console.WriteLine(Directory.GetFiles(".")[0]);
        }
    }
}
