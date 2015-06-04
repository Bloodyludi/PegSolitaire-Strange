using strange.extensions.command.impl;

class LoadFieldLayoutCommand : Command
{
    [Inject]
    public IBoardLayoutModel BoardLayoutModel { get; set; }

    [Inject]
    public IBoardModel BoardModel { get; set; }

    public override void Execute()
    {
        BoardModel.CurrentBoard = new IFieldModel[BoardLayoutModel.BoardLayout.Length];

        for (int index = 0; index < BoardModel.CurrentBoard.Length; index++)
        {
            var fieldType = BoardLayoutModel.BoardLayout[index];

            if (fieldType > 0 && fieldType <= 2)
            {
                CreateField(index, fieldType != 1);
            }
        }
    }

    void CreateField(int index, bool hasChip)
    {
        var field = injectionBinder.GetInstance<IFieldModel>();

        field.Index = index;
        field.HasChip = hasChip;
        BoardModel.CurrentBoard[index] = field;
    }
}