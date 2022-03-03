using System;
using System.Linq;
using System.Collections.Generic;
using Dungeon_Crawler.Structure;
using Dungeon_Crawler.JsonOpener;
using Dungeon_Crawler.Player;
using Dungeon_Crawler.Scenes;

namespace Dungeon_Crawler
{
    class Program
    {
        // Path to the "include.json" file
        private static string IncludePath = "./level-data/include.json";
        // Path to the "player.json" file
        private static string PlayerDataPath = "./item-data/player.json";
        // public static integer for the sleeptime after interactions with items
        public static int SleepTime { get; } = 500;
        public static PlayerClass GamePlayer { get; set; }
        static void Main(string[] args)
        {
            Setup();
        }
        // method that listens to keyinputs
        public static int[] KeyListen()
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.UpArrow:
                    return new int[] { 0, -1 };
                case ConsoleKey.RightArrow:
                    return new int[] { 1, 0 };
                case ConsoleKey.DownArrow:
                    return new int[] { 0, 1 };
                case ConsoleKey.LeftArrow:
                    return new int[] { -1, 0 };
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    return new int[] { 0, 0 };
                default:
                    return new int[] { 0, 0 };
            }
        }
        // setup method for starting the game
        private static void Setup()
        {
            // reset everything
            Scene.AllScenes = new Dictionary<string, Scene>();
            GamePlayer = null;
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
            GamePlayer = new PlayerClass(playerJson.HP, Scene.AllScenes.First().Value.BeginPosition, playerJson.Damage, playerJson.Xp_needed_next);
            // set the right index of the player
            GamePlayer.Move(0, 0);
            // start the gameloop
            GameLoop();
        }

        // loop method for running the gaem
        private static void GameLoop()
        {
            do
            {
                // clear the console
                Console.Clear();
                // print out data to the player
                Console.WriteLine($"Position: {GamePlayer.Position[0]}, {GamePlayer.Position[1]}");
                Console.WriteLine($"Scene: {Scene.CurrentScene.SceneName}");
                Console.WriteLine($"Level: {GamePlayer.CurrentLvl}");
                Console.WriteLine($"Damage: {GamePlayer.Damage[0]} - {GamePlayer.Damage[1]}");
                Console.WriteLine($"HP: {GamePlayer.CurrentHP} / {GamePlayer.MaxHP}");
                Console.WriteLine($"XP: {GamePlayer.CurrentXP} / {GamePlayer.XpNecUp * GamePlayer.CurrentLvl}");
                // get the current scene
                string inScene = Scene.GetSceneContent;
                // draw doors
                foreach (var door in Scene.CurrentScene.SceneDoors)
                {
                    inScene = inScene.ReplaceAt(door.PositionIndex, 1, "$");
                }
                // draw monsters
                foreach (var monster in Scene.CurrentScene.SceneMonsters)
                {
                    inScene = inScene.ReplaceAt(monster.PositionIndex, 1, "@");
                }
                // draw healing bottles
                foreach (var heal in Scene.CurrentScene.SceneHeals)
                {
                    inScene = inScene.ReplaceAt(heal.PositionIndex, 1, "+");
                }
                // draw the experience bottles
                foreach (var xp in Scene.CurrentScene.SceneXPs)
                {
                    inScene = inScene.ReplaceAt(xp.PositionIndex, 1, "&");
                }
                // draw the traps
                foreach (var trapGroup in Scene.CurrentScene.SceneTraps)
                {
                    foreach (var trap in trapGroup.Value)
                    {
                        if (trap.Activated)
                            inScene = inScene.ReplaceAt(trap.PositionIndex, 1, "#");
                        else
                            inScene = inScene.ReplaceAt(trap.PositionIndex, 1, "*");
                    }
                }

                // draw the player
                inScene = inScene.ReplaceAt(GamePlayer.InSceneIndex, 1, "¶");
                // display the scene
                Console.WriteLine(inScene);
                // listen to key-input;
                int[] Listen = KeyListen();
                GamePlayer.CheckMove(Listen[0], Listen[1], inScene);

                // check the player's status
                if (GamePlayer.CheckHP)
                {
                    Console.Clear();
                    Console.WriteLine("Helaas, je bent dood gegaan");
                    break;
                }

            } while (true);

            Console.WriteLine("Wil je nog een keer spelen?");
            string inp = Console.ReadLine();
            if (inp.ToLower() != "n")
            {
                Setup();
                return;
            }
            Environment.Exit(0);

        }
        public static void Win()
        {
            Console.Clear();
            Console.WriteLine("Je hebt gewonnen!");
            Console.WriteLine("Wil je nog een keer spelen?");
            string inp = Console.ReadLine();
            if (inp.ToLower() != "n")
            {
                Setup();
                return;
            }
            Environment.Exit(0);
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
