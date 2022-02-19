using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;

namespace Dungeon_Crawler.Structure
{
    // Incluce json class
    #region Include;
    public class IncludesRootobject
    {
        public Include[] Includes { get; set; }
    }

    public class Include
    {
        public string LevelPath { get; set; }
        public string LevelData { get; set; }
    }
    #endregion;

    // player json class
    #region Player
    public class PLayerRootObject
    {
        public int HP { get; set; }
        public int[] Damage { get; set; }
        public int Xp_needed_next { get; set; }
        public float Xp_needed_multiplier { get; set; }
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