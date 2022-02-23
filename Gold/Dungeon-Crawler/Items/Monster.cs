using System;
using System.Threading;
using System.Collections.Generic;
using Dungeon_Crawler.JsonOpener;
using Dungeon_Crawler.Structure;
using Dungeon_Crawler.Scenes;

namespace Dungeon_Crawler.Items
{
    public class Monster : AItem
    {
        // the difficulty table that gets initialized statically; this has all the data per difficulty
        private static Dictionary<string, Monstertype> DifficultyTable { get; } = Opener.OpenMonsterData().Data;
        private string Type { get; }
        private int[] Damage { get; }
        private int MaxHP { get; }
        private int CurrentHP { get; set; }
        // amount of xp the player gets after killing the monster
        private int XpUp { get; }

        public Monster(int[] Position, string Type, int SceneWidth) : base(Position, SceneWidth)
        {
            this.Type = Type;

            MaxHP = DifficultyTable[this.Type].HP;
            CurrentHP = MaxHP;
            Damage = DifficultyTable[this.Type].Damage;

            // how the xp amount gets calculated:
            XpUp = (int)(0.2 * (MaxHP + Damage[0] + Damage[1]));
        }
        protected override void Interact()
        {
            // get a random with a new seed everytime
            Random rnd = new Random(DateTime.Now.Millisecond);
            int dmgToPlayer = rnd.Next(Damage[0], Damage[1]);
            int dmgRecieve = rnd.Next(Program.GamePlayer.Damage[0], Program.GamePlayer.Damage[1]);
            CurrentHP -= dmgRecieve;

            // log out the type of the monster, the damage given to the monster and the current hp of the monster after getting damage
            Console.WriteLine($"Monster niveau: {Type}");
            Console.WriteLine($"Damage gegeven aan monster: {dmgRecieve}");
            Console.WriteLine($"Monster HP: {CurrentHP}");

            // monster dead
            if (CurrentHP <= 0)
            {
                // get the current index of the monster
                int monsterIndex = Scene.CurrentScene.SceneMonsters.IndexOf(this);
                // remove the monster from the current scene
                Scene.CurrentScene.SceneMonsters.RemoveAt(monsterIndex);
                // log out the xp the player got from killing the monster
                Console.WriteLine($"Verkregen XP: {XpUp}");

                // give the player the xp
                Program.GamePlayer.XpUp(XpUp);

                // let the program sleep
                Thread.Sleep(Program.SleepTime);

                // don't let this method continue
                return;
            }

            // this will only happen if the monster didn't die in the turn of the player
            // give the player damage
            Program.GamePlayer.CurrentHP -= dmgToPlayer;
            // log out the damage given to the player
            Console.WriteLine($"Damage genomen van het monster: {dmgToPlayer}");

            // let the program sleep
            Thread.Sleep(Program.SleepTime);
        }
        // static method for checking which monster the player encountered
        public static void CheckForPlayer(int x, int y)
        {
            // loop through the monsters in the current scene
            foreach (var monster in Scene.CurrentScene.SceneMonsters)
            {
                // check if the positions are equal
                if (Program.GamePlayer.Position[0] + x == monster.Position[0] && Program.GamePlayer.Position[1] + y == monster.Position[1])
                {
                    // interact with the corresponding monster
                    monster.Interact();
                    // don't let the loop continue, if you do and the monster gets killed; an error will occur
                    break;
                }
            }
        }
    }
}