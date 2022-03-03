using System;
using System.Collections.Generic;
using System.Threading;
using Dungeon_Crawler.JsonOpener;
using Dungeon_Crawler.Scenes;

namespace Dungeon_Crawler.Items
{
    public class ExperienceBottle : AItem
    {
        // open the data table of the experience bottles from the "Experience.json" file
        private static Dictionary<string, int> DataTable { get; } = Opener.OpenExperienceData();
        private string Type { get; }
        private int ExpUp { get; }

        public ExperienceBottle(int[] Position, string Type, int SceneWidth) : base(Position, SceneWidth)
        {
            this.Type = Type;
            ExpUp = DataTable[this.Type];
        }

        protected override void Interact()
        {
            // log the type and experience gained
            Console.WriteLine($"{Type}: {ExpUp}");
            // give the experience to the player
            Program.GamePlayer.XpUp(ExpUp);

            // get the index of the experience-bottle in the list of the current scene
            int btlIndex = Scene.CurrentScene.SceneXPs.IndexOf(this);
            // remove the bottle from the scene
            Scene.CurrentScene.SceneXPs.RemoveAt(btlIndex);

            Thread.Sleep(Program.SleepTime);
        }
        // static method for checking which experience-bottle the player encountered
        public static void CheckForPlayer(int x, int y)
        {
            // loop through the experience-bottles in the current scene
            foreach (var xp in Scene.CurrentScene.SceneXPs)
            {
                // check if the positions are equal
                if (Program.GamePlayer.Position[0] + x == xp.Position[0] && Program.GamePlayer.Position[1] + y == xp.Position[1])
                {
                    // interact with the corresponding experience-bottle
                    xp.Interact();
                    // break the loop after interacting
                    break;
                }
            }
        }
    }
}