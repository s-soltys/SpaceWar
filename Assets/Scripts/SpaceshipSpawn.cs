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
        Spawn(SpaceshipColor.Yellow, "STRAIGHT", Direction.Right, 0, 1);
        Spawn(SpaceshipColor.Blue, "STRAIGHT", Direction.Right, 0, 2);
        Spawn(SpaceshipColor.Red, "STRAIGHT", Direction.Right, 0, 3);

        Spawn(SpaceshipColor.Yellow, "STRAIGHT", Direction.Left, 9, 4);
        Spawn(SpaceshipColor.Red, "STRAIGHT", Direction.Left, 9, 5);
        Spawn(SpaceshipColor.Blue, "STRAIGHT", Direction.Left, 9, 6);
    }

    public void Spawn(SpaceshipColor color, string pattern, Direction direction, int x, int y)
    {
        GameObject inst = null;
        if(pattern == "STRAIGHT")
        {
            inst = Instantiate(straight) as GameObject;
        }
        else if(pattern == "DIAGONALUP")
        {
            inst = Instantiate(diagonal) as GameObject;
            diagonal.GetComponent<DiagonalSpaceship>().verticalDirection = 1;
        }
        else if(pattern == "DIAGONALDOWN")
        {
            inst = Instantiate(diagonal) as GameObject;
            diagonal.GetComponent<DiagonalSpaceship>().verticalDirection = -1;
        }

        inst.transform.parent = this.transform;
        var ss = inst.GetComponent<Spaceship>();

        ss.Deploy(new GridPosition(x, y), direction, color);
    }

}
