using System.IO;
using System.Reflection;
using Dungeon_Crawler.Structure;

namespace Dungeon_Crawler.JsonOpener
{
    public static class Opener
    {
        // Private paths from the Executable to the base
        private static string ExecutableLocation { get; } = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        private static string PathToBase { get; } = @"..\..\..\";

        // Method to open the include file
        public static IncludesRootobject OpenInclude(string path)
        {

            Directory.SetCurrentDirectory(ExecutableLocation);
            Directory.SetCurrentDirectory(PathToBase);

            return Serializer.Deserialize<IncludesRootobject>(path);
        }
        // Method to open the "player.json" file
        public static PLayerRootObject OpenPlayer(string path)
        {
            Directory.SetCurrentDirectory(ExecutableLocation);
            Directory.SetCurrentDirectory(PathToBase);

            return Serializer.Deserialize<PLayerRootObject>(path);
        }
        // Method to open the Data of a scene/level
        public static LevelRootObject OpenLevelData(string path)
        {
            Directory.SetCurrentDirectory(ExecutableLocation);
            Directory.SetCurrentDirectory(PathToBase);

            return Serializer.Deserialize<LevelRootObject>(path);
        }
        // Method to open the text-layout of a scene/level
        public static string OpenSceneContent(string path)
        {
            Directory.SetCurrentDirectory(ExecutableLocation);
            Directory.SetCurrentDirectory(PathToBase);

            return File.ReadAllText(path);
        }
        // Method to open the data from "Monster.json" (Path is pre-determined)
        public static MonsterDataJson OpenMonsterData()
        {
            Directory.SetCurrentDirectory(ExecutableLocation);
            Directory.SetCurrentDirectory(PathToBase);

            return Serializer.Deserialize<MonsterDataJson>(@"./item-data/Monster.json");
        }
        // Method to open the data from "Healing.json" (Path is pre-determined)
        public static HealingDataObject OpenHealingData()
        {
            Directory.SetCurrentDirectory(ExecutableLocation);
            Directory.SetCurrentDirectory(PathToBase);

            return Serializer.Deserialize<HealingDataObject>(@"./item-data/Healing.json");
        }
        // Method to open the data from "Experience.json" (Path is pre-determined)
        public static ExperienceDataObject OpenExperienceData()
        {
            Directory.SetCurrentDirectory(ExecutableLocation);
            Directory.SetCurrentDirectory(PathToBase);

            return Serializer.Deserialize<ExperienceDataObject>(@"./item-data/Experience.json");
        }
    }
}