using UnityEngine;
using System.Collections;
using System;

public struct GridPosition
{
    public int X;
    public int Y;


    public GridPosition(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

    public bool IsValidX
    {
        get { return X >= 0 && X < GameParameters.GridSizeX; }
    }

    public bool IsValidY
    {
        get { return Y >= 0 && Y < GameParameters.GridSizeY; }
    }

    public bool IsValid
    {
        get { return IsValidX && IsValidY; }
    }
}
