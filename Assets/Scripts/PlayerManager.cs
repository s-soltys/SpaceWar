using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PlayerManager : MonoBehaviour
{
    const float flickThreshold = 0.1f;

    private Vector2 selectPosition;

    public int startingGridPosition;
    public Direction launchDirection;
    public SpaceshipColor ChoosenColor;
    public SpaceshipSpawn Spawn;
    public float shootCooldown;
    public float shootingRate = 1f;

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

        var totalDelta = (e.position - selectPosition) / Screen.width;
        Debug.Log(Time.deltaTime + " " + totalDelta);
        
        var choosenPattern = string.Empty;
        if (totalDelta.y > flickThreshold) choosenPattern = "DIAGONALUP";
        else if (totalDelta.y < -flickThreshold) choosenPattern = "DIAGONALDOWN";
        else if (Mathf.Abs(totalDelta.x) > flickThreshold) choosenPattern = "STRAIGHT";
        else return;

        var yPositionIndex = int.Parse(((GameObject)e.pointerDrag).name);

        if (CanAttack)
        {
            shootCooldown = shootingRate;
            Spawn.Spawn(ChoosenColor, choosenPattern, launchDirection, startingGridPosition, yPositionIndex);
        }
    }

}
