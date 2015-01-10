using UnityEngine;
using System.Collections;

public class StraightSpaceship : Spaceship
{
    public override GridPosition GetNextPosition(GridPosition p)
    {
        return new GridPosition(p.X + HorizontalChange, p.Y);
    }
}
