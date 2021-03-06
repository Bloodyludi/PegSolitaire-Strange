using strange.extensions.command.impl;
using UnityEngine;
using strange.extensions.pool.api;

class CreateBoardFieldViewsCommand : Command
{
    [Inject(NamedInjections.FIELD_VIEW_POOL)]
    public IPool<GameObject> Pool { get; set; }

    [Inject(NamedInjections.GAME_ROOT)]
    public GameObject RootGameObject { get; set; }

    [Inject]
    public IBoardModel BoardModel { get; set; }

    [Inject]
    public IIndexConverter IndexConverter { get; set; }

    public override void Execute()
    {
        foreach (var fieldModel in BoardModel.CurrentBoard)
        {
            if (fieldModel != null)
            {
                var fieldView = Pool.GetInstance();
                fieldView.transform.position = IndexConverter.IndexToPosition(fieldModel.Index);
                fieldView.transform.parent = RootGameObject.transform;
            }
        }
    }
}