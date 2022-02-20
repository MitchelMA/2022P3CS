using System;

namespace Dungeon_Crawler.Items
{
    public abstract class AItem
    {
        public int[] Position { get; set; } = new int[2];
        public int PositionIndex { get; set; }

        public abstract void Interact();

        public AItem(int[] Position, int SceneWidth)
        {
            this.Position = Position;
            PositionIndex = Position[1] * SceneWidth + Position[1] + Position[0];
        }
    }
}