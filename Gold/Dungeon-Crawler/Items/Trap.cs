using System;
using Dungeon_Crawler.Scenes;

namespace Dungeon_Crawler.Items
{
    public class Trap : AItem
    {
        public bool Activated { get; set; } = false;
        public Trap(int[] Position, int SceneWidth) : base(Position, SceneWidth) { }

        public override void Interact()
        {
            Activated = true;
        }

        public static void CheckForPlayer(int x, int y)
        {
            foreach (var trap in Scene.CurrentScene.SceneTraps)
            {
                if (Program.GamePlayer.Position[0] + x == trap.Position[0] && Program.GamePlayer.Position[1] + y == trap.Position[1])
                {
                    trap.Interact();
                    break;
                }
            }
        }
    }
}