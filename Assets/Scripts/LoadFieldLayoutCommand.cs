using strange.extensions.command.impl;
using strange.extensions.context.api;
using UnityEngine;
using strange.extensions.pool.api;

class LoadFieldLayoutCommand : Command
{
    [Inject]
    public IBoardLayoutModel BoardLayoutModel { get; set; }

    [Inject]
    public IBoardModel BoardModel { get; set; }

    public override void Execute()
    {
        int index = 0;
        for (int y = 0; y < BoardLayoutModel.BoardDimension; y++)
        {
            for (int x = 0; x < BoardLayoutModel.BoardDimension; x++)
            {
                var fieldType = BoardLayoutModel.BoardLayout[index];

                if (fieldType > 0 && fieldType <= 2)
                {
                    CreateField(x, y, fieldType != 1);
                }
                index++;
            }
        }
    }

    void CreateField(int x, int y, bool hasChip)
    {
        var field = injectionBinder.GetInstance<IFieldModel>();

        field.Position = new Vector2(x, y);
        field.HasChip = hasChip;
        BoardModel.CurrentBoard.Add(field);
    }
}