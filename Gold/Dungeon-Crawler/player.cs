using System;
using Dungeon_Crawler.Scenes;

namespace Dungeon_Crawler.Player
{
    public class PlayerClass
    {
        public int[] Position { get; set; }
        public int InSceneIndex { get; set; }
        public int CurrentHP { get; set; }
        public int MaxHP { get; set; }
        public int[] Damage { get; set; } = { 5, 10 };
        public int XpNecUp { get; } = 10;
        public float XpNecUpMult { get; } = 1.2f;
        public int CurrentXP { get; set; } = 0;
        public int CurrentLvl { get; set; } = 1;
        public PlayerClass(int MaxHP, int[] Position, int[] Damage, int XpNecUp, float XpNecUpMult)
        {
            // set the hp
            this.MaxHP = MaxHP;
            CurrentHP = MaxHP;

            // set the correct start-position
            this.Position = Position;

            // set the damage
            this.Damage = Damage;

            // set the xp data
            this.XpNecUp = XpNecUp;
            this.XpNecUpMult = XpNecUpMult;
        }
        public void Move(int x, int y)
        {
            Position[0] += x;
            Position[1] += y;
            InSceneIndex = Position[1] * Scene.CurrentScene.SceneWidth + Position[1] + Position[0];
        }

        public void CheckMove(int x, int y, string level)
        {
            int nextPosIndex = (Position[1] + y) * Scene.CurrentScene.SceneWidth + Position[1] + y + Position[0] + x;
            Console.WriteLine(InSceneIndex);
            Console.WriteLine(nextPosIndex);
        }
    }
}