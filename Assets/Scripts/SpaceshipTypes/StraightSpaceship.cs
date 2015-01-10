using UnityEngine;
using System.Collections;

public class StraightSpaceship : Spaceship
{


    public override GridPosition nextPosition
    {
        get
        {
            return new GridPosition(currentPosition.X + HorizontalChange, currentPosition.Y);
        }
    }
}
