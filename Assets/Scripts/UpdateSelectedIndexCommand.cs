using strange.extensions.command.impl;

class UpdateSelectedIndexCommand : Command
{
    [Inject]
    public int index { get; set; }

    [Inject]
    public IUserSelectionModel selectionModel { get; set; }

    [Inject]
    public IBoardModel boardModel { get; set; }

    [Inject]
    public MoveChipViewSignal moveChipViewSignal { get; set; }

    public override void Execute()
    {
        selectionModel.SelectedField = boardModel.CurrentBoard[index];

        moveChipViewSignal.Dispatch(selectionModel.SelectedField.ViewID, index);
    }
}





