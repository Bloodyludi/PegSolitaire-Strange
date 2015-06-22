using strange.extensions.context.impl;

public class SolitareBootstrap : ContextView
{
    void Awake()
    {
        context = new SolitareContext(this);
    }
}
