using System.Collections.Generic;
using UnityEngine;

public class FieldModel : IFieldModel
{
    public int ViewID { get; set; }

    public int Index
    {
        get;
        set;
    }

    public bool HasChip
    {
        get;
        set;
    }

}
