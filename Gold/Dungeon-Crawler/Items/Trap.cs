using Dungeon_Crawler.Scenes;

namespace Dungeon_Crawler.Items
{
    public class Trap : AItem
    {
        public bool Activated { get; set; } = false;
        private string GroupName { get; }
        public Trap(int[] Position, string GroupName, int SceneWidth) : base(Position, SceneWidth)
        {
            this.GroupName = GroupName;
        }

        protected override void Interact()
        {
            foreach (var trap in Scene.CurrentScene.SceneTraps[GroupName])
            {
                trap.Activated = true;
            }
        }

        public static void CheckForPlayer(int x, int y)
        {
            foreach (var trapGroup in Scene.CurrentScene.SceneTraps.Values)
            {
                foreach (var trap in trapGroup)
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
}