using System;
using System.Threading;
using System.Collections.Generic;
using Dungeon_Crawler.Items;

namespace Dungeon_Crawler.Scenes
{
    public class Scene
    {
        // Path to the file with the data of the scene
        private string DataPath { get; }
        // path to the file with the layout of the scene
        private string FilePath { get; }
        public string SceneName { get; }
        public int SceneWidth { get; }
        public int[] BeginPosition { get; }

        // items in the scene
        public List<Door> SceneDoors { get; } = new List<Door>();
        public List<Monster> SceneMonsters { get; } = new List<Monster>();
        public List<HealingBottle> SceneHeals { get; } = new List<HealingBottle>();
        public List<ExperienceBottle> SceneXPs { get; } = new List<ExperienceBottle>();
        public Dictionary<string, Trap[]> SceneTraps { get; } = new Dictionary<string, Trap[]>();

        // static fields
        public static Dictionary<string, Scene> AllScenes { get; set; } = new Dictionary<string, Scene>();
        public static Scene CurrentScene { get; set; }
        public Scene(string DataPath, string FilePath)
        {
            // set the DataPath and the FilePath
            this.DataPath = DataPath;
            this.FilePath = FilePath;

            // open the the file with the data of the scene
            Structure.LevelRootObject levelRoot = Dungeon_Crawler.JsonOpener.Opener.OpenLevelData(this.DataPath);

            // set the scenename, width and beginposition
            this.SceneName = levelRoot.Name;
            this.SceneWidth = levelRoot.Width;
            this.BeginPosition = levelRoot.BeginPosition;

            // boolean that determines if the program has to wait after showing failures
            bool showFailure = false;
            // set the items of the scene
            // Door
            if (levelRoot.Doors != null)
            {
                foreach (var door in levelRoot.Doors)
                {
                    this.SceneDoors.Add(new Door(door.Position, door.DestPosition, door.DestName, this.SceneWidth));
                }
            }
            else
            {
                Console.WriteLine($"Scene {this.SceneName} mist deuren!");
                showFailure = true;
            }

            // Monster
            if (levelRoot.Monsters != null)
            {
                foreach (var monster in levelRoot.Monsters)
                {
                    this.SceneMonsters.Add(new Monster(monster.Position, monster.Difficulty, this.SceneWidth));
                }
            }
            else
            {
                Console.WriteLine($"Scene {this.SceneName} mist monsters!");
                showFailure = true;
            }

            // Healing Bottles
            if (levelRoot.HealingBottles != null)
            {
                foreach (var heal in levelRoot.HealingBottles)
                {
                    this.SceneHeals.Add(new HealingBottle(heal.Position, heal.Size, this.SceneWidth));
                }
            }
            else
            {
                Console.WriteLine($"Scene {this.SceneName} mist healing bottles");
                showFailure = true;
            }

            // experience bottles
            if (levelRoot.ExperienceBottles != null)
            {
                foreach (var xp in levelRoot.ExperienceBottles)
                {
                    this.SceneXPs.Add(new ExperienceBottle(xp.Position, xp.Size, this.SceneWidth));
                }
            }
            else
            {
                Console.WriteLine($"Scene {this.SceneName} mist Experience bottles");
                showFailure = true;
            }

            // traps
            if (levelRoot.Traps != null)
            {
                foreach (var trapGroup in levelRoot.Traps)
                {
                    int groupSize = trapGroup.Value.Length;
                    Trap[] trapArr = new Trap[groupSize];

                    for (int i = 0; i < groupSize; i++)
                    {
                        trapArr[i] = new Trap(trapGroup.Value[i], trapGroup.Key, this.SceneWidth);
                    }
                    this.SceneTraps.Add(trapGroup.Key, trapArr);
                }
            }
            else
            {
                Console.WriteLine($"Scene {this.SceneName} mist Traps");
                showFailure = true;
            }

            if (showFailure)
                Thread.Sleep(Program.SleepTime * 2);

            Scene.AllScenes.Add(this.SceneName, this);
        }

        // public static lambda method to read the contents of the layout
        public static string GetSceneContent => JsonOpener.Opener.OpenSceneContent(Scene.CurrentScene.FilePath);

    }
}