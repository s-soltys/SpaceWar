using UnityEngine;
using System.Collections;

public class GameplayManager : MonoBehaviour {
    public int leftPlayerLives = 5;
    public int rightPlayerLives = 5;
    public float frequency;
    public GUIText scoreLabel;
    public GameObject explosionPrefab;

    public static GameplayManager Instance;

    public void Awake()
    {
        Instance = this;
    }
    public void Start()
    {
        StartCoroutine(MovementCoroutine());
    }

    public IEnumerator MovementCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(GameParameters.TickPeriod);

            foreach (var ss in GetComponentsInChildren<DiagonalSpaceship>()) ss.Move(GameParameters.TickMovementTime);
            foreach (var ss in GetComponentsInChildren<StraightSpaceship>()) ss.Move(GameParameters.TickMovementTime);
        }
    }


	void Update ()
    {
        scoreLabel.text = leftPlayerLives + " : " + rightPlayerLives;
	}

    public void DeleteLive(Direction direction)
    {
        if (direction == Direction.Left) leftPlayerLives -= 1;
        else rightPlayerLives -= 1;

        if(leftPlayerLives == 0 || rightPlayerLives == 0)
        {
            enabled = false;

        }
    }

}
