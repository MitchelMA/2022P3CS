using System;
using System.Threading;
using Dungeon_Crawler.Scenes;

namespace Dungeon_Crawler.Items
{
    public class Door : AItem
    {
        private int[] DestPosition { get; } = new int[2];
        private string DestName { get; }

        public Door(int[] Position, int[] DestPosition, string DestName, int SceneWidth) : base(Position, SceneWidth)
        {
            this.DestPosition = DestPosition;
            this.DestName = DestName;
        }
        public override void Interact()
        {
            try
            {
                Scene.CurrentScene = Scene.AllScenes[DestName];
                Program.GamePlayer.MoveTo(DestPosition[0], DestPosition[1]);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Deze deur leidt nergens naar");
                Thread.Sleep(800);
            }
            catch (System.Collections.Generic.KeyNotFoundException)
            {
                Console.WriteLine("Deze deur leidt nergens naar");
                Thread.Sleep(800);
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Deze duer leidt nergens naar");
                Thread.Sleep(800);
            }
        }
        public static void CheckForPlayer(int x, int y)
        {
            foreach (var door in Scene.CurrentScene.SceneDoors)
            {
                if (Program.GamePlayer.Position[0] + x == door.Position[0] && Program.GamePlayer.Position[1] + y == door.Position[1])
                {
                    door.Interact();
                    break;
                }
            }
        }
    }
}