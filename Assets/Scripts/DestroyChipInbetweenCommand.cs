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

    [Inject]
    public DestroyChipViewSignal destroyChipViewSignal { get; set; }

    public override void Execute()
    {
        int indexInbetween = selectionModel.SelectedField.Index + ((index - selectionModel.SelectedField.Index) / 2);
        Debug.Log("inbetween: " + indexInbetween);
        var fieldInbetween = boardModel.CurrentBoard[indexInbetween];
        fieldInbetween.HasChip = false;
        destroyChipViewSignal.Dispatch(fieldInbetween.ViewID);
    }
}





