using System.Collections.Generic;

public interface IBoardModel
{
    IFieldModel[] CurrentBoard
    {
        get;
        set;
    }

    bool HasChipAtIndex(int index);
}



