using UnityEngine;
using System.Collections;

public class DiagonalSpaceship : Spaceship {

    public int verticalDirection = 1;

    public override GridPosition nextPosition
    {
        get
        {
            var next = new GridPosition(currentPosition.X + HorizontalChange, currentPosition.Y + verticalDirection);
            if (!next.IsValidY)
            {
                verticalDirection = -verticalDirection;
                next = new GridPosition(currentPosition.X + HorizontalChange, currentPosition.Y + verticalDirection);
            }
            return next;
        }
    }
}
