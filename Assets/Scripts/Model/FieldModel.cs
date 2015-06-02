using System.Collections.Generic;
using UnityEngine;

public class FieldModel : IFieldModel
{
	public Vector2 Position {
		get;
		set;
	}

	public bool HasChip {
		get;
		set;
	}

}
