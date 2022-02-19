using System;
using Dungeon_Crawler.Structure;
using Dungeon_Crawler.JsonOpener;
using Dungeon_Crawler.Player;

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
                Console.WriteLine(include.LevelPath);
                Console.WriteLine(include.LevelData);
                Console.WriteLine();
            }

            Console.WriteLine();
            // open the player path
            PLayerRootObject playerJson = Opener.OpenPlayer(PlayerDataPath);
            Console.WriteLine(playerJson.HP);
            Console.WriteLine($"{playerJson.Damage[0]}, {playerJson.Damage[1]}");
            Console.WriteLine(playerJson.Xp_needed_next);
            Console.WriteLine(playerJson.Xp_needed_multiplier);
            Console.WriteLine();
            // initialize the global player
            GamePlayer = new PlayerClass(playerJson.HP, new int[2] { 1, 2 }, playerJson.Damage, playerJson.Xp_needed_next, playerJson.Xp_needed_multiplier);
            Console.WriteLine($"{GamePlayer.CurrentHP} / {GamePlayer.MaxHP}");
            Console.WriteLine($"{GamePlayer.Position[0]}, {GamePlayer.Position[1]}");
            Console.WriteLine($"{GamePlayer.Damage[0]} | {GamePlayer.Damage[1]}");
            Console.WriteLine($"{GamePlayer.XpNecUp}");
            Console.WriteLine($"{GamePlayer.XpNecUpMult}");
            Console.WriteLine($"{GamePlayer.CurrentXP}");
            Console.WriteLine($"{GamePlayer.CurrentLvl}");
        }
    }
}
