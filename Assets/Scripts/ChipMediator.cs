using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;

public class ChipMediator : Mediator
{
    [Inject]
    public ChipView view { get; set; }

    [Inject]
    public SelectChipSignal selectedChipSignal { get; set; }

    [Inject]
    public DeselectChipSignal deselectedChipSignal { get; set; }

    [Inject]
    public IIndexConverter indexConverter { get; set; }

    public override void OnRegister()
    {
        selectedChipSignal.AddListener(HighlightView);
        deselectedChipSignal.AddListener(DeselectView);
    }

    public override void OnRemove()
    {
        selectedChipSignal.RemoveListener(HighlightView);
        deselectedChipSignal.RemoveListener(DeselectView);
    }

    public void HighlightView(int index)
    {
        if (indexConverter.IndexToPosition(index) == (Vector2)transform.position)
            view.Highlight(true);
    }

    public void DeselectView(int index)
    {
        if (indexConverter.IndexToPosition(index) == (Vector2)transform.position)
        {
            view.Highlight(false);
            view.TriggerRestrictedAnimation();
        }
    }
}