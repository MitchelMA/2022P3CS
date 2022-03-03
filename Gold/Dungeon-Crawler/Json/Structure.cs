using System.IO;
using System.Collections.Generic;
using System.Text.Json;

namespace Dungeon_Crawler.Structure
{
    // Json class of the "include.json" file
    #region Include;
    public class IncludesRootobject
    {
        public Include[] Includes { get; set; }
    }
    // class for every include entry in the "Includes" array of the RootObject
    public class Include
    {
        public string LevelPath { get; set; }
        public string LevelData { get; set; }
    }
    #endregion;

    // Json class of the player "player.json" file
    #region Player
    public class PLayerRootObject
    {
        public int HP { get; set; }
        public int[] Damage { get; set; }
        public int Xp_needed_next { get; set; }
    }
    #endregion;

    // Json class of every level in the "include.json"
    #region level
    public class LevelRootObject
    {
        public string Name { get; set; }
        public int[] BeginPosition { get; set; }
        public int Width { get; set; }
        // doors in the level
        public DoorLevelObject[] Doors { get; set; }
        // monsters in the level
        public MonsterLevelObject[] Monsters { get; set; }
        // healing-bottles in the level
        public HealingLevelObject[] HealingBottles { get; set; }
        // experience-bottles in the level
        public ExperienceLevelObject[] ExperienceBottles { get; set; }
        // traps in the level (gets read as a nested integer-array, so no extra class for traps)
        public Dictionary<string, int[][]> Traps { get; set; }
    }
    // door class of the LevelRootObject
    public class DoorLevelObject
    {
        public int[] Position { get; set; }
        public int[] DestPosition { get; set; }
        public string DestName { get; set; }
    }
    // monster class of the LevelRootObject
    public class MonsterLevelObject
    {
        public string Difficulty { get; set; }
        public int[] Position { get; set; }
    }
    // healing-bottle class of the LevelRootObject
    public class HealingLevelObject
    {
        public string Size { get; set; }
        public int[] Position { get; set; }
    }
    // Experience-bottle class of the LevelRootObject
    public class ExperienceLevelObject
    {
        public string Size { get; set; }
        public int[] Position { get; set; }
    }
    #endregion;

    // Json clsas for monster difficulty data from the "Monster.json" file
    #region MonsterData;
    // Monstertype class, this determines the HP and Damage of the monster
    public class Monstertype
    {
        public int HP { get; set; }
        public int[] Damage { get; set; }
    }
    #endregion;

    // Serializer
    #region Serializer
    public static class Serializer
    {
        public static T Deserialize<T>(string inFile)
        {
            // read all the text of the inFile
            string jsonString = File.ReadAllText(inFile);

            // Deserialize the string
            T Deser = JsonSerializer.Deserialize<T>(jsonString);

            // return the Deserialized jsonstring
            return Deser;
        }
        public static void Serialize<T>(this T ToSer, string inFile)
        {
            // parse ToSer from class to string
            string parsed = JsonSerializer.Serialize(ToSer, new JsonSerializerOptions { WriteIndented = true });

            // create a streamwriter of the inFile
            TextWriter writer = new StreamWriter(inFile);

            // write the parsed text to the file
            writer.Write(parsed);

            // close the file
            writer.Close();
        }
    }
    #endregion;
}