using UnityEngine;
using System.Collections;
using System.Linq;

public class Grid : MonoBehaviour
{
    public static Grid Instance;
    public GridBlock[,] GridBlocks;
    public bool removeSprites;

    public void Awake()
    {
        Instance = this;

        GridBlocks = CreateGrid();
    }

    private GridBlock[,] CreateGrid()
    {
        var positions = new GridBlock[GameParameters.GridSizeX, GameParameters.GridSizeY];
        var sprites = gameObject.transform.GetComponentsInChildren<GridBlock>().ToArray();

        for (var x = 0; x < GameParameters.GridSizeX; x++)
        {
            for (var y = 0; y < GameParameters.GridSizeY; y++)
            {
                var sprite = sprites[x + (y * GameParameters.GridSizeX)];
                positions[x, y] = sprite;

                if(removeSprites)
                {
                    Destroy(sprite.gameObject.GetComponent<SpriteRenderer>());
                }
            }
        }

        return positions;
    }

}
