using System;
using System.Collections.Generic;
using System.Threading;
using Dungeon_Crawler.JsonOpener;
using Dungeon_Crawler.Scenes;

namespace Dungeon_Crawler.Items
{
    public class HealingBottle : AItem
    {
        // open the data table of the healing-bottles from the "Healing.json" 
        private static Dictionary<string, int> DataTable { get; } = Opener.OpenHealingData();
        private string Type { get; }
        private int HealingUp { get; }

        public HealingBottle(int[] Position, string Type, int SceneWidth) : base(Position, SceneWidth)
        {
            this.Type = Type;
            HealingUp = DataTable[this.Type];
        }

        protected override void Interact()
        {
            // log the type and the health gained
            Console.WriteLine($"{Type}: {HealingUp}");
            // check if the player's health is not full
            if (!(Program.GamePlayer.CurrentHP < Program.GamePlayer.MaxHP))
            {
                Thread.Sleep(Program.SleepTime / 2);
                return;
            }

            // give the hp to the player
            Program.GamePlayer.CurrentHP += HealingUp;
            // if the hp of the player goes beyond the max, cap it
            if (Program.GamePlayer.CurrentHP > Program.GamePlayer.MaxHP)
                Program.GamePlayer.CurrentHP = Program.GamePlayer.MaxHP;

            // get the index of the healing-bottle in the current scene
            int PotIndex = Scene.CurrentScene.SceneHeals.IndexOf(this);
            // remove the bottle from the scene
            Scene.CurrentScene.SceneHeals.RemoveAt(PotIndex);

            Thread.Sleep(Program.SleepTime);
        }
        // static method for checking which healing-bottle the player encountered
        public static void CheckForPlayer(int x, int y)
        {
            // loop through all healing-bottles in the current scene
            foreach (var heal in Scene.CurrentScene.SceneHeals)
            {
                // check if the positions are equal
                if (Program.GamePlayer.Position[0] + x == heal.Position[0] && Program.GamePlayer.Position[1] + y == heal.Position[1])
                {
                    // interact with the corresponding helaing-bottle
                    heal.Interact();
                    // break the loop after interacting
                    break;
                }
            }
        }
    }
}