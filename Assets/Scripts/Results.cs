using UnityEngine;
using System.Collections;

public class Results : MonoBehaviour {
    public UnityEngine.UI.Text resultText;
    private static int winningPlayerIndex;

    public static void Show(int winningPlayer)
    {
        winningPlayerIndex = winningPlayer;
        Application.LoadLevel("Results");
    }

    void Start()
    {
        resultText.text = string.Format("Player {0} won!", winningPlayerIndex);
    }

    public void PlayAgain()
    {
        Application.LoadLevel("Menu");
    }
}
