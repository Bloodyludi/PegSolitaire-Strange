using strange.extensions.command.impl;
using UnityEngine;
using strange.extensions.pool.api;

class HighlightSelectedChipViewCommand : Command
{
    [Inject]
    public int index { get; set; }

    [Inject(NamedInjections.CHIP_VIEW_POOL)]
    public IPool<GameObject> pool { get; set; }

    [Inject]
    public IIndexConverter indexConverter { get; set; }

    public override void Execute()
    {
    }
}





