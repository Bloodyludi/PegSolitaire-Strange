using strange.extensions.command.impl;
using UnityEngine;

class PickClickReactionCommand : Command
{
    [Inject]
    public int index { get; set; }

    [Inject]
    public IBoardModel boardModel { get; set; }

    [Inject]
    public IUserSelectionModel selectionModel { get; set; }

    [Inject]
    public IMovementRules rules { get; set; }

    [Inject]
    public MoveChipSignal moveChipSignal { get; set; }

    public override void Execute()
    {
        if (selectionModel.IsEmpty())
        {
            if (boardModel.HasChipAtIndex(index))
            {
                selectionModel.SelectedField = boardModel.CurrentBoard[index];
            }
        }
        else
        {
            if (boardModel.HasChipAtIndex(index))
            {
                if (selectionModel.SelectedField != boardModel.CurrentBoard[index])
                    selectionModel.SelectedField = boardModel.CurrentBoard[index];
                else
                    selectionModel.SelectedField = null;
            }
            else
            {
                if (rules.IsValidMove(selectionModel.SelectedField.Index, index))
                {
                    moveChipSignal.Dispatch(index);
                }
            }
        }
    }
}