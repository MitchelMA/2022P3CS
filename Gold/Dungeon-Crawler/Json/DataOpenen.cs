using System;
using System.IO;
using System.Reflection;
using Dungeon_Crawler.Structure;

namespace Dungeon_Crawler.JsonOpener
{
    public static class Opener
    {
        private static string ExecutableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        private static string PathToBase = @"..\..\..\";
        public static IncludesRootobject OpenInclude(string path)
        {

            Directory.SetCurrentDirectory(ExecutableLocation);
            Directory.SetCurrentDirectory(PathToBase);

            return Serializer.Deserialize<IncludesRootobject>(path);
        }
        public static PLayerRootObject OpenPlayer(string path)
        {
            Directory.SetCurrentDirectory(ExecutableLocation);
            Directory.SetCurrentDirectory(PathToBase);

            return Serializer.Deserialize<PLayerRootObject>(path);
        }
    }
}