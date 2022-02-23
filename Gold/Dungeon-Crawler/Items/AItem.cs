// abstract item template, every item has to use this template
namespace Dungeon_Crawler.Items
{
    public abstract class AItem
    {
        protected int[] Position { get; } = new int[2];
        public int PositionIndex { get; }
        // protected method that will get called if the player interacts with the item
        protected abstract void Interact();

        public AItem(int[] Position, int SceneWidth)
        {
            this.Position = Position;
            PositionIndex = Position[1] * SceneWidth + Position[1] + Position[0];
        }
    }
}