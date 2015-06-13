using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;

public class ChipMediator : Mediator
{
    [Inject]
    public ChipView view { get; set; }

    [Inject]
    public SelectedChipSignal selectedChipSignal { get; set; }

    [Inject]
    public DeselectedChipSignal deselectedChipSignal { get; set; }

    [Inject]
    public IIndexConverter indexConverter { get; set; }

    [Inject]
    public DestroyChipViewSignal destroyChipViewSignal { get; set; }

    [Inject]
    public MoveChipViewSignal moveChipViewSignal { get; set; }

    public override void OnRegister()
    {
        selectedChipSignal.AddListener(HighlightView);
        deselectedChipSignal.AddListener(DeselectView);
        destroyChipViewSignal.AddListener(DestroyView);
        moveChipViewSignal.AddListener(MoveChip);
    }

    public override void OnRemove()
    {
        selectedChipSignal.RemoveListener(HighlightView);
        deselectedChipSignal.RemoveListener(DeselectView);
        destroyChipViewSignal.RemoveListener(DestroyView);
        moveChipViewSignal.RemoveListener(MoveChip);
    }

    public void HighlightView(int viewID)
    {
        if (viewID == gameObject.GetInstanceID())
            view.Highlight(true);
    }

    public void DeselectView(int viewID)
    {
        if (viewID == gameObject.GetInstanceID())
        {
            view.Highlight(false);
            view.TriggerRestrictedAnimation();
        }
    }

    public void DestroyView(int viewID)
    {
        if (viewID == gameObject.GetInstanceID())
            view.Destroy();
    }

    public void MoveChip(int viewID, int destination)
    {
        if (viewID == gameObject.GetInstanceID())
            view.MoveToPosition(indexConverter.IndexToPosition(destination));
    }
}