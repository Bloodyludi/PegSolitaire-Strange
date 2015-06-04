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
        boardModel.CurrentBoard[selectionModel.SelectedField.Index].HasChip = false;
        boardModel.CurrentBoard[index].HasChip = true;
    }
}





