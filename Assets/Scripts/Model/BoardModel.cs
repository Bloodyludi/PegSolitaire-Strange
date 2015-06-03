public class BoardModel : IBoardModel
{
    public IFieldModel[] CurrentBoard
    {
        get;
        set;
    }

    public bool HasChipAtIndex(int index)
    {
        return CurrentBoard[index].HasChip;
    }
}