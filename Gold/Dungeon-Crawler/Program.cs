using System;
using System.Linq;
using Dungeon_Crawler.Structure;
using Dungeon_Crawler.JsonOpener;
using Dungeon_Crawler.Player;
using Dungeon_Crawler.Scenes;

namespace Dungeon_Crawler
{
    class Program
    {
        private static string IncludePath = "./level-data/include.json";
        private static string PlayerDataPath = "./level-data/player.json";
        public static PlayerClass GamePlayer { get; set; }
        static void Main(string[] args)
        {
            Setup();
        }
        public static void Setup()
        {
            // open the include path
            IncludesRootobject Includes = Opener.OpenInclude(IncludePath);
            foreach (var include in Includes.Includes)
            {
                Scene temp = new Scene(include.LevelData, include.LevelPath);
            }
            // set the current scene to the first scene
            Scene.CurrentScene = Scene.AllScenes.First().Value;

            // open the player Path
            PLayerRootObject playerJson = Opener.OpenPlayer(PlayerDataPath);
            // initialize the global player
            GamePlayer = new PlayerClass(playerJson.HP, Scene.AllScenes.First().Value.BeginPosition, playerJson.Damage, playerJson.Xp_needed_next, playerJson.Xp_needed_multiplier);
            // set the right index of the player
            GamePlayer.Move(0, 0);
            // start the gameloop
            GameLoop();
        }
        public static void GameLoop()
        {
            // draw the items
            string inScene = Scene.GetSceneContent();
            inScene = inScene.ReplaceAt(GamePlayer.InSceneIndex, 1, "¶");
            Console.WriteLine(inScene);
            GamePlayer.CheckMove(0, 1, inScene);
        }
    }
    public static class StringModifier
    {
        public static string ReplaceAt(this string str, int index, int length, string replace)
        {
            return str.Remove(index, Math.Min(length, str.Length - index))
                    .Insert(index, replace);
        }
    }
}
