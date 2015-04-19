using UnityEngine;
using System.Collections;

public class GameMenu : MonoBehaviour
{
    public void StartSinglePlayer()
    {
        GameParameters.Mode = GameMode.Single;
        Application.LoadLevel("Game");
    }

    public void StartSplitScreen()
    {
        GameParameters.Mode = GameMode.SplitScreen;
        Application.LoadLevel("Game");
    }

}
