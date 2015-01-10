using UnityEngine;
using System.Collections;

public class DiagonalSpaceship : Spaceship {

    public int verticalDirection = 1;

    public override GridPosition GetNextPosition(GridPosition p)
    {
        var next = new GridPosition(p.X + HorizontalChange, p.Y + verticalDirection);
        if (!next.IsValidY)
        {
            verticalDirection = -verticalDirection;
            next = new GridPosition(p.X + HorizontalChange, p.Y + verticalDirection);
        }
        return next;
    }

}
