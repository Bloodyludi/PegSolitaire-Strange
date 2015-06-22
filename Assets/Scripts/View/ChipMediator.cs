using strange.extensions.mediation.impl;
using UnityEngine;
using strange.extensions.pool.api;

public class ChipMediator : Mediator
{
    [Inject]
    public ChipView view { get; set; }

    [Inject]
    public SelectedChipSignal selectedChipSignal { get; set; }

    [Inject]
    public DeselectedChipSignal deselectedChipSignal { get; set; }

    [Inject]
    public DestroyChipViewSignal destroyChipViewSignal { get; set; }

    [Inject]
    public MoveChipViewSignal moveChipViewSignal { get; set; }

    [Inject(NamedInjections.CHIP_VIEW_POOL)]
    public IPool<GameObject> pool { get; set; }

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
        {
            view.Destroy(() => {
                pool.ReturnInstance(gameObject);
                gameObject.SetActive(false);
            });

        }
    }

    public void MoveChip(int viewID, Vector2 destination)
    {
        if (viewID == gameObject.GetInstanceID())
            view.MoveToPosition(destination);
    }
}