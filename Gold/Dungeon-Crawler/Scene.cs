using System;
using System.Linq;
using System.Threading;
using System.Collections.Generic;
using Dungeon_Crawler.Items;

namespace Dungeon_Crawler.Scenes
{
    public class Scene
    {
        private string DataPath { get; }
        private string FilePath { get; }
        public string SceneName { get; set; }
        public int SceneWidth;
        public int[] BeginPosition { get; }

        // items in the scene
        public List<Door> SceneDoors { get; } = new List<Door>();
        public List<Monster> SceneMonsters { get; } = new List<Monster>();
        public List<HealingBottle> SceneHeals { get; } = new List<HealingBottle>();
        public List<ExperienceBottle> SceneXPs { get; } = new List<ExperienceBottle>();
        public List<Trap> SceneTraps { get; } = new List<Trap>();
        public static Dictionary<string, Scene> AllScenes { get; set; } = new Dictionary<string, Scene>();
        public static Scene CurrentScene { get; set; }
        public Scene(string DataPath, string FilePath)
        {
            this.DataPath = DataPath;
            this.FilePath = FilePath;

            Structure.LevelRootObject levelRoot = Dungeon_Crawler.JsonOpener.Opener.OpenLevelData(this.DataPath);

            this.SceneName = levelRoot.Name;
            this.SceneWidth = levelRoot.Width;
            this.BeginPosition = levelRoot.BeginPosition;

            // set the items
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
                Thread.Sleep(500);
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
            }

            // traps
            if (levelRoot.Traps != null)
            {
                foreach (var trap in levelRoot.Traps)
                {
                    this.SceneTraps.Add(new Trap(trap.Position, this.SceneWidth));
                }
            }
            else
            {
                Console.WriteLine($"Scene {this.SceneName} mist Traps");
                Thread.Sleep(500);
            }

            Scene.AllScenes.Add(this.SceneName, this);
        }
        public static string GetSceneContent()
        {
            return JsonOpener.Opener.OpenSceneContent(Scene.CurrentScene.FilePath);
        }
    }
}