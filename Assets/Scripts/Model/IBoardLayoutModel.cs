using UnityEngine;
using strange.extensions.context.impl;

public interface IBoardLayoutModel
{
    int[] BoardLayout { get; }

    int BoardDimension { get; }
}
