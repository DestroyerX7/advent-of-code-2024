namespace day_fifteen;

public class GridNode
{
    public ItemType ItemType { get; private set; }

    public GridNode(ItemType itemType)
    {
        ItemType = itemType;
    }
}

public enum ItemType
{
    Box,
    LeftBoxPart,
    RightBoxPart,
    Robot,
    Wall,
}