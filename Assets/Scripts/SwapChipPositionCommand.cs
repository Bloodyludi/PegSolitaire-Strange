using strange.extensions.command.impl;
using UnityEngine;

class SwapChipPositionCommand : Command
{
    [Inject]
    public int index { get; set; }

    [Inject]
    public IUserSelectionModel selectionModel { get; set; }

    [Inject]
    public IBoardModel boardModel { get; set; }

    public override void Execute()
    {
        var fromField = boardModel.CurrentBoard[selectionModel.SelectedField.Index];
        var toField = boardModel.CurrentBoard[index];

        toField.ViewID = fromField.ViewID;
        fromField.ViewID = 0;
        
        fromField.HasChip = false;
        toField.HasChip = true;
    }
}