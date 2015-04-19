using UnityEngine;
using System.Collections;

public class SpaceshipSpawn : MonoBehaviour
{
    public static SpaceshipSpawn Instance;

    public GameObject diagonal;
    public GameObject straight;

    public void Awake()
    {
        Instance = this;
    }
    public void Start()
    {

    }

    public void Spawn(SpaceshipColor color, MovementPattern pattern, Direction direction, int x, int y)
    {
        GameObject inst = null;
        if(pattern == MovementPattern.STRAIGHT)
        {
            inst = Instantiate(straight) as GameObject;
        }
        else if(pattern == MovementPattern.DIAGONALUP)
        {
            inst = Instantiate(diagonal) as GameObject;
            inst.GetComponent<DiagonalSpaceship>().verticalDirection = -1;
        }
        else if(pattern == MovementPattern.DIAGONALDOWN)
        {
            inst = Instantiate(diagonal) as GameObject;
            inst.GetComponent<DiagonalSpaceship>().verticalDirection = 1;
        }

        inst.transform.parent = this.transform;
        var ss = inst.GetComponent<Spaceship>();
        
        ss.Deploy(new GridPosition(x, y), direction, color);
    }




}
