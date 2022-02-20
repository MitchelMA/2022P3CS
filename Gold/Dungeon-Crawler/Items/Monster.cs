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
        private static Dictionary<string, Monstertype> DifficultyTable { get; } = Opener.OpenMonsterData().Data;
        private string Type { get; }
        private int[] Damage { get; }
        private int MaxHP { get; }
        private int CurrentHP { get; set; }
        private int XpUp { get; } = 10;

        public Monster(int[] Position, string Type, int SceneWidth) : base(Position, SceneWidth)
        {
            this.Type = Type;

            MaxHP = DifficultyTable[this.Type].HP;
            CurrentHP = MaxHP;
            Damage = DifficultyTable[this.Type].Damage;

            XpUp = (int)(0.2 * (MaxHP + Damage[0] + Damage[1]));
        }
        public override void Interact()
        {
            // get a random with a new seed everytime
            Random rnd = new Random(DateTime.Now.Millisecond);
            int dmgToPlayer = rnd.Next(Damage[0], Damage[1]);
            int dmgRecieve = rnd.Next(Program.GamePlayer.Damage[0], Program.GamePlayer.Damage[1]);
            CurrentHP -= dmgRecieve;
            Program.GamePlayer.CurrentHP -= dmgToPlayer;

            Console.WriteLine($"Monster niveau: {Type}");
            Console.WriteLine($"Damage genomen van het monster: {dmgToPlayer}");
            Console.WriteLine($"Damage gegeven aan monster: {dmgRecieve}");
            Console.WriteLine($"Monster HP: {CurrentHP}");

            // monster dead
            if (CurrentHP <= 0)
            {
                int monsterIndex = Scene.CurrentScene.SceneMonsters.IndexOf(this);
                Scene.CurrentScene.SceneMonsters.RemoveAt(monsterIndex);
                Console.WriteLine($"Verkregen XP: {XpUp}");
            }

            Thread.Sleep(800);
        }
        public static void CheckForPlayer(int x, int y)
        {
            foreach (var monster in Scene.CurrentScene.SceneMonsters)
            {
                if (Program.GamePlayer.Position[0] + x == monster.Position[0] && Program.GamePlayer.Position[1] + y == monster.Position[1])
                {
                    monster.Interact();
                    break;
                }
            }
        }
    }
}