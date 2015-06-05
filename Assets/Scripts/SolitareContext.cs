using UnityEngine;
using strange.extensions.context.impl;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.pool.api;
using strange.extensions.pool.impl;

public class SolitareContext : MVCSContext
{
    public SolitareContext(MonoBehaviour contextView)
        : base(contextView)
    {
    }

    public SolitareContext(MonoBehaviour view, ContextStartupFlags flags)
        : base(view, flags)
    {
    }

    protected override void addCoreComponents()
    {
        base.addCoreComponents();
        injectionBinder.Unbind<ICommandBinder>();
        injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
    }

    public override IContext Start()
    {
        base.Start();
        var startSignal = (StartSignal)injectionBinder.GetInstance<StartSignal>();
        startSignal.Dispatch();
        return this;
    }

    protected override void mapBindings()
    {
        base.mapBindings();
        injectionBinder.Bind<IPool<GameObject>>()
            .To<Pool<GameObject>>().ToSingleton().ToName(NamedInjections.FIELD_VIEW_POOL);
        injectionBinder.Bind<IPool<GameObject>>()
            .To<Pool<GameObject>>().ToSingleton().ToName(NamedInjections.CHIP_VIEW_POOL);

        injectionBinder.Bind<IBoardLayoutModel>().To<BoardLayoutModel>().ToSingleton();
        injectionBinder.Bind<IBoardModel>().To<BoardModel>().ToSingleton();
        injectionBinder.Bind<IUserSelectionModel>().To<UserSelectionModel>().ToSingleton();
        injectionBinder.Bind<IFieldModel>().To<FieldModel>();

        injectionBinder.Bind<IMovementRules>().To<MovementRules>();
        injectionBinder.Bind<IIndexConverter>().To<IndexConverter>();

        injectionBinder.Bind<FieldClickedSignal>().ToSingleton();
        injectionBinder.Bind<SelectedChipSignal>().ToSingleton();
        injectionBinder.Bind<DeselectedChipSignal>().ToSingleton();
        injectionBinder.Bind<MoveChipSignal>().ToSingleton();
        injectionBinder.Bind<DestroyChipViewSignal>().ToSingleton();
        injectionBinder.Bind<MoveChipViewSignal>().ToSingleton();

        commandBinder.Bind<StartSignal>().InSequence()
			.To<LoadFieldLayoutCommand>()
			.To<CreateViewRootCommand>()
			.To<CreateBoardFieldViewsCommand>()
			.To<CreateChipViewsCommand>();

        commandBinder.Bind<FieldClickedSignal>().To<PickClickReactionCommand>();
        commandBinder.Bind<MoveChipSignal>().InSequence()
            .To<SwapChipPositionCommand>()
            .To<DestroyChipInbetweenCommand>()
            .To<UpdateSelectedIndexCommand>();

        mediationBinder.Bind<ChipView>().To<ChipMediator>();
        mediationBinder.Bind<InputSurfaceView>().To<InputSurfaceMediator>();
    }

    protected override void postBindings()
    {
        IPool<GameObject> fieldPool = injectionBinder.GetInstance<IPool<GameObject>>(NamedInjections.FIELD_VIEW_POOL);
        fieldPool.instanceProvider = new PrefabInstanceProvider(ResourceNames.FIELD_VIEW_PREFAB_NAME);
        fieldPool.inflationType = PoolInflationType.INCREMENT;

        IPool<GameObject> chipPool = injectionBinder.GetInstance<IPool<GameObject>>(NamedInjections.CHIP_VIEW_POOL);
        chipPool.instanceProvider = new PrefabInstanceProvider(ResourceNames.CHIP_VIEW_PREFAB_NAME);
        chipPool.inflationType = PoolInflationType.INCREMENT;
    }
}

public enum NamedInjections
{
    GAME_ROOT,
    INPUT_SURFACE,
    FIELD_VIEW_POOL,
    CHIP_VIEW_POOL
}

public static class ResourceNames
{
    public const string FIELD_VIEW_PREFAB_NAME = "Prefabs/Field";
    public const string CHIP_VIEW_PREFAB_NAME = "Prefabs/Chip";
}
