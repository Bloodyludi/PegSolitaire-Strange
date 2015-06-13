using UnityEngine;

public interface IIndexConverter
{
    int PositionToIndex(Vector2 clickPosition);
    Vector2 IndexToPosition(int index);
}

class IndexConverter : IIndexConverter
{
    [Inject]
    public IBoardLayoutModel layout { get; set; }

    public int PositionToIndex(Vector2 clickPosition)
    {
        return (int)clickPosition.y * layout.BoardDimension + (int)clickPosition.x;
    }

    public Vector2 IndexToPosition(int index)
    {
        var position = new Vector2();
        position.x = index % layout.BoardDimension;
        position.y = (int) (index / layout.BoardDimension);
        return position;
    }
}
