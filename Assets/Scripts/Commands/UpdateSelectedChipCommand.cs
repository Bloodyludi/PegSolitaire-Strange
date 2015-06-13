using strange.extensions.command.impl;

class UpdateSelectedChipCommand : Command
{
    [Inject]
    public int index { get; set; }

    [Inject]
    public IUserSelectionModel selectionModel { get; set; }

    [Inject]
    public IBoardModel boardModel { get; set; }

    [Inject]
    public MoveChipViewSignal moveChipViewSignal { get; set; }

    [Inject]
    public IIndexConverter indexConverter { get; set; }

    public override void Execute()
    {
        selectionModel.SelectedField = boardModel.CurrentBoard[index];

        moveChipViewSignal.Dispatch(selectionModel.SelectedField.ViewID, indexConverter.IndexToPosition(index));
    }
}





