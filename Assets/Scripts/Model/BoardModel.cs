using System.Collections.Generic;
using UnityEngine;

public class BoardModel : IBoardModel
{
	public List<IFieldModel> CurrentBoard {
		get
		{
			return currentBoard;
		}
		set
		{
			currentBoard = value;
		}
	}
	List<IFieldModel> currentBoard = new List<IFieldModel>();
}