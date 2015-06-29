using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerManager))]
public class AIPlayer : MonoBehaviour {
    private PlayerManager manager;

    private float minDelay = 1.5f;
    private float maxDelay = 3.0f;
    private MovementPattern[] movementPatterns = new MovementPattern[] { MovementPattern.DIAGONALDOWN, MovementPattern.DIAGONALUP, MovementPattern.STRAIGHT };
    private SpaceshipColor[] colors = new SpaceshipColor[] { SpaceshipColor.Blue, SpaceshipColor.Red, SpaceshipColor.Yellow };
    private int numberOfPositions = 7;

	void Start () 
    {
        manager = GetComponent<PlayerManager>();

        foreach (var ui in manager.uiContainers)
        {
            ui.gameObject.SetActive(false);
        }

        StartCoroutine(AiRoutine());

	}
	
	IEnumerator AiRoutine()
    {
        yield return new WaitForSeconds(1);

        do
        {
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));

            var pattern = movementPatterns[Random.Range(0, movementPatterns.Length)];
            var color = colors[Random.Range(0, colors.Length)];
            var index = Random.Range(0, 7);

            manager.ChooseColor(color);
            manager.Launch(color, index, pattern);
        } while (true);
	}
}
