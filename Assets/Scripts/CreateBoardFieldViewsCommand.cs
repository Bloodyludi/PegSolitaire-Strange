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

    public override void Execute()
    {
        foreach (var fieldModel in BoardModel.CurrentBoard)
        {
            var fieldView = Pool.GetInstance();
            fieldView.transform.position = fieldModel.Position;
            fieldView.transform.parent = RootGameObject.transform;
        }
    }
}