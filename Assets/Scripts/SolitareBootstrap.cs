using UnityEngine;
using strange.extensions.context.impl;

public class SolitareBootstrap : ContextView {

	// Use this for initialization
	void Start () {
		context = new SolitareContext (this);
	}
}
