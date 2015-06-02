using strange.extensions.command.impl;
using strange.extensions.pool.api;
using UnityEngine;

class ClearSelectionCommand : Command
{
	[Inject(NamedInjections.GAME_ROOT)]
	public GameObject rootGameObject{ get; set; }

	public override void Execute()
	{
		var chipViews = rootGameObject.GetComponentsInChildren<ChipView> ();
		foreach (var chipView in chipViews)
		{
			chipView.Highlight (false);
		}
	}
}





