using System;
using System.Collections.Generic;
using System.Threading;
using Dungeon_Crawler.JsonOpener;
using Dungeon_Crawler.Scenes;

namespace Dungeon_Crawler.Items
{
    public class ExperienceBottle : AItem
    {
        private static Dictionary<string, int> DataTable { get; } = Opener.OpenExperienceData().Data;

        private string Type { get; }
        private int ExpUp { get; }

        public ExperienceBottle(int[] Position, string Type, int SceneWidth) : base(Position, SceneWidth)
        {
            this.Type = Type;
            ExpUp = DataTable[this.Type];
        }

        public override void Interact()
        {
            Console.WriteLine($"{Type}: {ExpUp}");
            Program.GamePlayer.XpUp(ExpUp);

            int btlIndex = Scene.CurrentScene.SceneXPs.IndexOf(this);
            Scene.CurrentScene.SceneXPs.RemoveAt(btlIndex);
            Thread.Sleep(400);
        }

        public static void CheckForPlayer(int x, int y)
        {
            foreach (var xp in Scene.CurrentScene.SceneXPs)
            {
                if (Program.GamePlayer.Position[0] + x == xp.Position[0] && Program.GamePlayer.Position[1] + y == xp.Position[1])
                {
                    xp.Interact();
                    break;
                }
            }
        }
    }
}