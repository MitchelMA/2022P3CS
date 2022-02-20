using System;
using System.Collections.Generic;

namespace Dungeon_Crawler.Scenes
{
    public class Scene
    {
        private string FilePath { get; }
        public string SceneName { get; set; }
        public int SceneWidth;
        public int[] BeginPosition { get; }
        public static Dictionary<string, Scene> AllScenes { get; set; } = new Dictionary<string, Scene>();
        public static Scene CurrentScene { get; set; }

        public Scene(string FilePath)
        {
            this.FilePath = FilePath;

            Structure.LevelRootObject levelRoot = Dungeon_Crawler.JsonOpener.Opener.OpenLevelData(this.FilePath);

            this.SceneName = levelRoot.Name;
            this.SceneWidth = levelRoot.Width;
            this.BeginPosition = levelRoot.BeginPosition;
            Scene.AllScenes.Add(this.SceneName, this);
        }
    }
}