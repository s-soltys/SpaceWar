using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PlayerManager : MonoBehaviour
{
    const float flickThreshold = 0.1f;

    private Vector2 selectPosition;

    public bool tryAttachAI;
    public int startingGridPosition;
    public Direction launchDirection;
    public SpaceshipColor ChoosenColor;
    public SpaceshipSpawn Spawn;
    public float shootCooldown;
    public float shootingRate = 1f;
    public Transform[] uiContainers;

    public bool CanAttack
    {
        get
        {
            return shootCooldown <= 0f;
        }
    }

    void Start()
    {
        shootCooldown = 0f;

        if (GameParameters.Mode == GameMode.SinglePlayer && tryAttachAI)
        {
            gameObject.AddComponent<AIPlayer>();
        }
    }

    public void Update()
    {
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }
    }

    public void ChoosenBlue()
    {
        ChoosenColor = SpaceshipColor.Blue;
    }

    public void ChoosenRed()
    {
        ChoosenColor = SpaceshipColor.Red;
    }

    public void ChoosenYellow()
    {
        ChoosenColor = SpaceshipColor.Yellow;
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

        if (CanAttack)
        {
            shootCooldown = shootingRate;
            Spawn.Spawn(ChoosenColor, choosenPattern, launchDirection, startingGridPosition, yPositionIndex);
        }
    }

    public void Launch(SpaceshipColor color, int planetIndex,  MovementPattern pattern)
    {
        if (CanAttack)
        {
            shootCooldown = shootingRate;
            Spawn.Spawn(color, pattern, launchDirection, startingGridPosition, planetIndex);
        }
    }

}
