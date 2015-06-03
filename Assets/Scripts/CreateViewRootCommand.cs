using strange.extensions.command.impl;
using strange.extensions.context.api;
using UnityEngine;

class CreateViewRootCommand : Command
{
    [Inject(ContextKeys.CONTEXT_VIEW)]
    public GameObject contextView{ get; set; }

    public override void Execute()
    {
        if (injectionBinder.GetBinding<GameObject>(NamedInjections.GAME_ROOT) == null)
        {
            GameObject rootGameObject = new GameObject(NamedInjections.GAME_ROOT.ToString());
            rootGameObject.transform.parent = contextView.transform;

            injectionBinder.Bind<GameObject>().ToValue(rootGameObject).ToName(NamedInjections.GAME_ROOT);
        }

        if (injectionBinder.GetBinding<GameObject>(NamedInjections.INPUT_SURFACE) == null)
        {
            GameObject inputSurfaceGameObject = new GameObject(NamedInjections.INPUT_SURFACE.ToString());
            inputSurfaceGameObject.AddComponent<InputSurfaceView>();
            inputSurfaceGameObject.transform.parent = contextView.transform;

            injectionBinder.Bind<GameObject>().ToValue(inputSurfaceGameObject).ToName(NamedInjections.INPUT_SURFACE);
        }
    }
}





