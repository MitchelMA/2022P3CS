using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;

namespace Dungeon_Crawler.Structure
{
    public class IncludesRootobject
    {
        public Include[] Includes { get; set; }
    }

    public class Include
    {
        public string LevelName { get; set; }
        public string LevelPath { get; set; }
        public string LevelData { get; set; }
    }

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
}