using strange.extensions.command.impl;
using System.Linq;
using UnityEngine;

class ValidateChipSelectionCommand : Command
{
	[Inject]
	public ChipView chipView { get; set; }

	[Inject]
	public ChipSelectionValidationResultSignal chipValidationResultSignal { get; set; }

	[Inject]
	public IBoardModel boardModel { get; set; }

	public override void Execute ()
	{
		Debug.Log ("Clicked on Chip: " + chipView.transform.position);

		var hasEmptyNeighbour = CheckForEmptyFieldsNextTo (chipView.transform.position);

		chipValidationResultSignal.Dispatch (hasEmptyNeighbour);
	}

	bool CheckForEmptyFieldsNextTo (Vector2 position)
	{
		for (int x = -2; x <= 2; x += 2)
		{
			if (LookUpPosition (new Vector2 (position.x + x, position.y)))
				return true;
		}

		for (int y = -2; y <= 2; y += 2)
		{
			if (LookUpPosition (new Vector2 (position.x, position.y + y)))
				return true;
		}
		return false;
	}

	bool LookUpPosition (Vector2 searchPosition)
	{
		Debug.Log (searchPosition);
		var neighbour = boardModel.CurrentBoard.SingleOrDefault (f => f.Position == searchPosition);

		if (neighbour != null && !neighbour.HasChip)
		{
			return true;
		}
		return false;
	}
}





