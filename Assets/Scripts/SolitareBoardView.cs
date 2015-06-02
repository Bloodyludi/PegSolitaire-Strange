using UnityEngine;
using strange.extensions.mediation.impl;

public class SolitareBoardView : View
{
	
}

public class SolitareBoardMediator : Mediator
{
	[Inject]
	public SolitareBoardView view { get; set; }


}