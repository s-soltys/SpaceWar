using UnityEngine;
using System.Collections;

public static class GameParameters
{
    public static GameMode Mode = GameMode.SinglePlayer;
    public static int GridSizeX = 10;
    public static int GridSizeY = 7;
    public static float TickPeriod = 1.5f;
    public static float TickMovementTime = 1.0f;

}

public enum GameMode
{
    SinglePlayer,
    SplitScreen
}