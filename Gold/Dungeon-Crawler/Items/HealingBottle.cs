using System;
using System.Collections.Generic;
using System.Threading;
using Dungeon_Crawler.JsonOpener;
using Dungeon_Crawler.Scenes;

namespace Dungeon_Crawler.Items
{
    public class HealingBottle : AItem
    {
        private static Dictionary<string, int> DataTable { get; } = Opener.OpenHealingData().Data;
        private string Type { get; }
        private int HealingUp { get; }

        public HealingBottle(int[] Position, string Type, int SceneWidth) : base(Position, SceneWidth)
        {
            this.Type = Type;

            HealingUp = DataTable[this.Type];
        }

        public override void Interact()
        {
            Console.WriteLine($"{Type}: {HealingUp}");
            if (!(Program.GamePlayer.CurrentHP < Program.GamePlayer.MaxHP))
            {
                Thread.Sleep(200);
                return;
            }

            Program.GamePlayer.CurrentHP += HealingUp;
            if (Program.GamePlayer.CurrentHP > Program.GamePlayer.MaxHP)
                Program.GamePlayer.CurrentHP = Program.GamePlayer.MaxHP;

            int PotIndex = Scene.CurrentScene.SceneHeals.IndexOf(this);
            Scene.CurrentScene.SceneHeals.RemoveAt(PotIndex);

            Thread.Sleep(400);
        }

        public static void CheckForPlayer(int x, int y)
        {
            foreach (var heal in Scene.CurrentScene.SceneHeals)
            {
                if (Program.GamePlayer.Position[0] + x == heal.Position[0] && Program.GamePlayer.Position[1] + y == heal.Position[1])
                {
                    heal.Interact();
                    break;
                }
            }
        }
    }
}