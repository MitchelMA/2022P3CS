using System;
using Dungeon_Crawler.Scenes;
using Dungeon_Crawler.Items;

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
        public int CurrentXP { get; set; } = 0;
        public int CurrentLvl { get; set; } = 1;
        public PlayerClass(int MaxHP, int[] Position, int[] Damage, int XpNecUp)
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
        }

        public void XpUp(int XpAmount)
        {
            CurrentXP += XpAmount;
            if (CurrentXP < XpNecUp * CurrentLvl)
                return;
            LvlUp();
        }
        private void LvlUp()
        {
            while (CurrentXP >= XpNecUp * CurrentLvl)
            {
                Damage[0] += 5;
                Damage[1] += 5;

                CurrentHP = (int)(CurrentHP / (double)MaxHP * (MaxHP + 10));
                MaxHP += 10;
                CurrentXP -= XpNecUp * CurrentLvl;
                CurrentLvl++;
            }
        }
        public void Move(int x, int y)
        {
            Position[0] += x;
            Position[1] += y;
            InSceneIndex = Position[1] * Scene.CurrentScene.SceneWidth + Position[1] + Position[0];
        }
        public void MoveTo(int x, int y)
        {
            Position[0] = x;
            Position[1] = y;
            InSceneIndex = Position[1] * Scene.CurrentScene.SceneWidth + Position[1] + Position[0];
        }

        public bool CheckHP()
        {
            return CurrentHP <= 0;
        }

        public void CheckMove(int x, int y, string level)
        {
            int nextPosIndex = (Position[1] + y) * Scene.CurrentScene.SceneWidth + Position[1] + y + Position[0] + x;
            int[] Listen;
            switch (level[nextPosIndex])
            {

                case '─':
                    Listen = Program.KeyListen();
                    CheckMove(Listen[0], Listen[1], level);
                    return;
                case '│':
                    Listen = Program.KeyListen();
                    CheckMove(Listen[0], Listen[1], level);
                    return;
                case '┌':
                    Listen = Program.KeyListen();
                    CheckMove(Listen[0], Listen[1], level);
                    return;
                case '┐':
                    Listen = Program.KeyListen();
                    CheckMove(Listen[0], Listen[1], level);
                    return;
                case '┘':
                    Listen = Program.KeyListen();
                    CheckMove(Listen[0], Listen[1], level);
                    return;
                case '└':
                    Listen = Program.KeyListen();
                    CheckMove(Listen[0], Listen[1], level);
                    return;

                // items
                case '$':
                    Door.CheckForPlayer(x, y);
                    break;
                case '@':
                    Monster.CheckForPlayer(x, y);
                    break;
                case '+':
                    HealingBottle.CheckForPlayer(x, y);
                    break;
                case '&':
                    ExperienceBottle.CheckForPlayer(x, y);
                    break;

                // default case
                default:
                    Move(x, y);
                    break;

            }
        }
    }
}