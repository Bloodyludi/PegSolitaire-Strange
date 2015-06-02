using UnityEngine;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

public class ChipMediator : Mediator
{
	[Inject]
	public ChipView view { get; set; }

	[Inject]
	public ValidateChipSelectionSignal selectedChipSignal{ get; set; }

	[Inject]
	public ChipSelectionValidationResultSignal chipValidationResultSignal { get; set; }

	public override void OnRegister ()
	{
		view.clickSignal.AddListener (OnClick);
	}

	//OnRemove() is like a destructor/OnDestroy. Use it to clean up.
	public override void OnRemove ()
	{
		view.clickSignal.RemoveListener (OnClick);
	}

	void OnClick()
	{
		chipValidationResultSignal.AddListener (HandleSelectionValidationResult);
		selectedChipSignal.Dispatch (view);
	}

	void HandleSelectionValidationResult(bool outcome)
	{
		chipValidationResultSignal.RemoveListener (HandleSelectionValidationResult);

		view.Highlight(outcome);

		if (!outcome)
			view.TriggerRestrictedAnimation ();
	}
}