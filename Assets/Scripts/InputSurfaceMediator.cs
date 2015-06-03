using UnityEngine;
using strange.extensions.mediation.impl;

public class InputSurfaceMediator : Mediator
{
    [Inject]
    public InputSurfaceView surface { get; set; }

    [Inject]
    public IBoardLayoutModel layout { get; set; }

    [Inject]
    public FieldClickedSignal clickSignal { get; set; }

    public override void OnRegister()
    {
        surface.clickSignal.AddListener(OnClick);
    }

    public override void OnRemove()
    {
        surface.clickSignal.RemoveListener(OnClick);
    }

    void OnClick(Vector2 clickPosition)
    {
        var index = ClickPositionToBoardIndex(clickPosition);

        clickSignal.Dispatch(index);
    }

    int ClickPositionToBoardIndex(Vector2 clickPosition)
    {
        return (int)clickPosition.y * layout.BoardDimension + (int)clickPosition.x;
    }
}