using strange.extensions.command.impl;
using UnityEngine;

class DestroyChipInbetweenCommand : Command
{
    [Inject]
    public int index { get; set; }

    [Inject]
    public IUserSelectionModel selectionModel { get; set; }

    [Inject]
    public IBoardModel boardModel { get; set; }


    public override void Execute()
    {
        int indexInbetween = selectionModel.SelectedField.Index + ((index - selectionModel.SelectedField.Index) / 2);
        Debug.Log("inbetween: " + indexInbetween);
        boardModel.CurrentBoard[indexInbetween].HasChip = false;
    }
}





