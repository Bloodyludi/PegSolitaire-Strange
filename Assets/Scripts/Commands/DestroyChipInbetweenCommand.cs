using strange.extensions.command.impl;

class DestroyChipInbetweenCommand : Command
{
    [Inject]
    public int index { get; set; }

    [Inject]
    public IUserSelectionModel selectionModel { get; set; }

    [Inject]
    public IBoardModel boardModel { get; set; }

    [Inject]
    public DestroyChipViewSignal destroyChipViewSignal { get; set; }

    public override void Execute()
    {
        var indexInbetween = selectionModel.SelectedField.Index + ((index - selectionModel.SelectedField.Index) / 2);
        var fieldInbetween = boardModel.CurrentBoard[indexInbetween];
        fieldInbetween.HasChip = false;
        destroyChipViewSignal.Dispatch(fieldInbetween.ViewID);
    }
}





