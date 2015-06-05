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

    public void DestroyView(int index)
    {
        if (indexConverter.IndexToPosition(index) == (Vector2)transform.position)
        {
            view.Destroy();
        }
    }

    public void MoveChip(int from, int to)
    {
        if (indexConverter.IndexToPosition(from) == (Vector2)transform.position)
        {
            view.MoveToPosition(indexConverter.IndexToPosition(to));
        }
    }
}