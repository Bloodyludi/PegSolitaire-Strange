using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

public class ChipMediator : Mediator
{
    [Inject]
    public ChipView view { get; set; }


//    [Inject]
//    public ChipSelectionValidationResultSignal chipValidationResultSignal { get; set; }
//
//
//    void HandleSelectionValidationResult(bool outcome)
//    {
//        chipValidationResultSignal.RemoveListener(HandleSelectionValidationResult);
//
//        view.Highlight(outcome);
//
//        if (!outcome)
//            view.TriggerRestrictedAnimation();
//    }
}