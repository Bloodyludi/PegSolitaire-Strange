using System;

interface IMovementRules
{
    bool IsValidMove(int from, int to);
}

class MovementRules : IMovementRules
{
    [Inject]
    public IBoardLayoutModel layoutModel { get; set; }

    const int swapDistance = 2;

    public bool IsValidMove(int from, int to)
    {
        var validHorizontalMove = Math.Abs(from - to) == swapDistance;

        var validVerticalMoveUp = (from + layoutModel.BoardDimension * swapDistance) == to;
        var validVerticalMoveDown = (from - layoutModel.BoardDimension * swapDistance) == to;

        return validHorizontalMove || validVerticalMoveUp || validVerticalMoveDown;
    }
}