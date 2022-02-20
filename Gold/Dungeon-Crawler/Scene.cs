using System;
using System.Collections.Generic;

namespace Dungeon_Crawler.Scenes
{
    public class Scene
    {
        private string DataPath { get; }
        private string FilePath { get; }
        public string SceneName { get; set; }
        public int SceneWidth;
        public int[] BeginPosition { get; }
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
            Scene.AllScenes.Add(this.SceneName, this);
        }
        public static string GetSceneContent()
        {
            return JsonOpener.Opener.OpenSceneContent(Scene.CurrentScene.FilePath);
        }
    }
}