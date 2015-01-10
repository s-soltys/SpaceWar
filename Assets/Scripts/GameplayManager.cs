using UnityEngine;
using System.Collections;

public class GameplayManager : MonoBehaviour {
    public int leftPlayerLives = 5;
    public int rightPlayerLives = 5;
    public float frequency;
    public GUIText scoreLabel;

    public static GameplayManager Instance;

    public void Awake()
    {
        Instance = this;
    }
    public void Start()
    {
        StartCoroutine(MovementCoroutine(frequency));
    }

    public IEnumerator MovementCoroutine(float frequency)
    {
        while (true)
        {
            yield return new WaitForSeconds(frequency);

            foreach (var ss in GetComponentsInChildren<DiagonalSpaceship>()) ss.Move(frequency / 2);
            foreach (var ss in GetComponentsInChildren<StraightSpaceship>()) ss.Move(frequency / 2);
        }
    }


	void Update ()
    {
        scoreLabel.text = leftPlayerLives + " : " + rightPlayerLives;
	}

    public void DeleteLive(Direction direction)
    {
        if (direction == Direction.Left) leftPlayerLives -= 1;
        rightPlayerLives -= 1;

        if(leftPlayerLives == 0 || rightPlayerLives == 0)
        {
            enabled = false;

        }
    }

}
