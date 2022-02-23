using System;
using System.Threading;
using Dungeon_Crawler.Scenes;

namespace Dungeon_Crawler.Items
{
    public class Door : AItem
    {
        // new position the player gets placed to once he has gone through the door
        private int[] DestPosition { get; } = new int[2];
        // name of the new scene/level the player gets placed in once he has gone through the door
        private string DestName { get; }

        public Door(int[] Position, int[] DestPosition, string DestName, int SceneWidth) : base(Position, SceneWidth)
        {
            // set the new position and destination name
            this.DestPosition = DestPosition;
            this.DestName = DestName;
        }
        protected override void Interact()
        {
            // try to set the player in the new scene at the new position, at every possible error, let the player know
            bool failure = false;
            try
            {
                Scene.CurrentScene = Scene.AllScenes[DestName];
                Program.GamePlayer.MoveTo(DestPosition[0], DestPosition[1]);
            }
            catch (ArgumentNullException)
            {
                failure = true;
            }
            catch (System.Collections.Generic.KeyNotFoundException)
            {
                failure = true;
            }
            catch (NullReferenceException)
            {
                failure = true;
            }
            if (failure)
            {
                Console.WriteLine("Deze deur leidt nergens naar");
                Thread.Sleep(Program.SleepTime);
            }
        }
        // static method for checking which door the player encountered
        public static void CheckForPlayer(int x, int y)
        {
            // loop through all doors in the current scene
            foreach (var door in Scene.CurrentScene.SceneDoors)
            {
                // check if the positions are equl
                if (Program.GamePlayer.Position[0] + x == door.Position[0] && Program.GamePlayer.Position[1] + y == door.Position[1])
                {
                    // interact with the corresponding door
                    door.Interact();
                    // break the loop after interaction by a return, so that if it was succesful; the method wouldn't continue
                    return;
                }
            }
            // if the door is not in the curren scene, but ís displayed, tell the player that the door is not working
            Console.WriteLine("Deze deur leidt nergens naar");
            Thread.Sleep(Program.SleepTime);
        }
    }
}