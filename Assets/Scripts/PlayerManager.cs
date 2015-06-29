using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PlayerManager : MonoBehaviour
{
    const float shootingRate = 1f;
    const float flickThreshold = 0.1f;

    private bool canAttack = true;
    private Vector2 selectPosition;

    public bool tryAttachAI;
    public int startingGridPosition;
    public Direction launchDirection;
    public SpaceshipColor ChoosenColor;
    public SpaceshipSpawn Spawn;
    public Transform[] uiContainers;
    public UnityEngine.UI.Image colorIndicator;
    public Color[] colors;

    void Start()
    {
        if (GameParameters.Mode == GameMode.SinglePlayer && tryAttachAI)
        {
            gameObject.AddComponent<AIPlayer>();
        }

        ChoosenRed();
    }

    public void ChooseColor(SpaceshipColor color)
    {
        switch(color)
        {
            case SpaceshipColor.Blue:
                ChoosenBlue();
                break;
            case SpaceshipColor.Red:
                ChoosenRed();
                break;
            case SpaceshipColor.Yellow:
                ChoosenYellow();
                break;
        }
    }

    public void ChoosenBlue()
    {
        ChoosenColor = SpaceshipColor.Blue;
        colorIndicator.color = colors[2];
    }

    public void ChoosenRed()
    {
        ChoosenColor = SpaceshipColor.Red;
        colorIndicator.color = colors[1];
    }

    public void ChoosenYellow()
    {
        ChoosenColor = SpaceshipColor.Yellow;
        colorIndicator.color = colors[0];
    }

    public void SelectPosition(BaseEventData eventData)
    {
        var e = eventData as PointerEventData;
        selectPosition = e.position;
    }

    public void Launch(BaseEventData eventData)
    {
        var e = eventData as PointerEventData;

        var yPositionIndex = int.Parse(((GameObject)e.pointerDrag).name);

        var totalDelta = (e.position - selectPosition) / Screen.width;
        var choosenPattern = MovementPattern.STRAIGHT;
        if (totalDelta.y > flickThreshold) choosenPattern = MovementPattern.DIAGONALUP;
        else if (totalDelta.y < -flickThreshold) choosenPattern = MovementPattern.DIAGONALDOWN;
        else if (Mathf.Abs(totalDelta.x) > flickThreshold) choosenPattern = MovementPattern.STRAIGHT;
        else return;

        if (canAttack)
        {
            Spawn.Spawn(ChoosenColor, choosenPattern, launchDirection, startingGridPosition, yPositionIndex);
            StartCoroutine(Cooldown());
        }
    }

    public void Launch(SpaceshipColor color, int planetIndex,  MovementPattern pattern)
    {
        if (canAttack)
        {
            Spawn.Spawn(color, pattern, launchDirection, startingGridPosition, planetIndex);
            StartCoroutine(Cooldown());
        }
    }

    private IEnumerator Cooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(shootingRate);
        canAttack = true;
    }

}
