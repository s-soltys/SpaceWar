using UnityEngine;
using System.Collections;

public class GameMenu : MonoBehaviour
{
    public void StartSinglePlayer()
    {
        GameParameters.Mode = GameMode.SinglePlayer;
        Application.LoadLevel("Game");
    }

    public void StartSplitScreen()
    {
        GameParameters.Mode = GameMode.SplitScreen;
        Application.LoadLevel("Game");
    }

}
