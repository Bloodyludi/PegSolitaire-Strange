using strange.extensions.context.impl;

public class SolitareBootstrap : ContextView
{
    void Start()
    {
        context = new SolitareContext(this);
    }
}
