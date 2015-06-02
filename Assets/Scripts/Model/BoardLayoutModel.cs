public class BoardLayoutModel : IBoardLayoutModel
{
	public int[] BoardLayout {
		get { return boardLayout; }
	}

	public int BoardDimension {
		get { return boardDimension; }
	}

	const int boardDimension = 7;

	readonly int[] boardLayout = new int[boardDimension * boardDimension] {
		0,0,2,2,2,0,0,
		0,0,2,2,2,0,0,
		2,2,2,2,2,2,2,
		2,2,2,1,2,2,2,
		2,2,2,2,2,2,2,
		0,0,2,2,2,0,0,
		0,0,2,2,2,0,0 
	};
}