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

    public override void Execute()
    {
        Debug.Log(boardModel.HasChipAtIndex(index));
    }
}





