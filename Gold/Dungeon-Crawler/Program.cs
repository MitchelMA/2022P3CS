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
            // open the include path
            IncludesRootobject Includes = Opener.OpenInclude(IncludePath);
            foreach (var include in Includes.Includes)
            {
                Scene temp = new Scene(include.LevelData);
            }
            // open the player path
            PLayerRootObject playerJson = Opener.OpenPlayer(PlayerDataPath);
            // initialize the global player
            GamePlayer = new PlayerClass(playerJson.HP, Scene.AllScenes.First().Value.BeginPosition, playerJson.Damage, playerJson.Xp_needed_next, playerJson.Xp_needed_multiplier);
            Console.WriteLine($"{GamePlayer.Position[0]}, {GamePlayer.Position[1]}");
            foreach (var scene in Scene.AllScenes)
            {
                Console.WriteLine(scene.Value.SceneName);
            }
        }
    }
}
