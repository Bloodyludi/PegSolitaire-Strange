using strange.extensions.command.impl;
using UnityEngine;
using strange.extensions.pool.api;
using strange.extensions.mediation.impl;

class CreateChipViewsCommand : Command
{
    [Inject(NamedInjections.GAME_ROOT)]
    public GameObject RootGameObject { get; set; }

    [Inject(NamedInjections.CHIP_VIEW_POOL)]
    public IPool<GameObject> Pool { get; set; }

    [Inject]
    public IBoardModel BoardModel { get; set; }

    [Inject]
    public IIndexConverter IndexConverter { get; set; }

    public override void Execute()
    {
        foreach (var fieldModel in BoardModel.CurrentBoard)
        {
            if (fieldModel != null && fieldModel.HasChip)
            {
                var chipView = Pool.GetInstance();

                chipView.transform.position = IndexConverter.IndexToPosition(fieldModel.Index);
                chipView.transform.parent = RootGameObject.transform;
                fieldModel.ViewID = chipView.GetInstanceID();
            }
        }
    }
}