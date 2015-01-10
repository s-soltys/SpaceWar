using UnityEngine;
using System.Collections;

public class Spaceship : MonoBehaviour {

    public GridPosition currentPosition;
    public Direction direction;
    public float frequency;
    public SpaceshipColor color;

    public Sprite[] spriteReferences;

    public virtual GridPosition nextPosition
    {
        get
        {
            return currentPosition;
        }
    }

    public virtual void Deploy(GridPosition initialPosition, Direction direction)
    {
        this.direction = direction;
        SetPositionOnGrid(initialPosition, 0);
        StartCoroutine(MovementCoroutine(frequency));
        SetSprite();

        GetComponent<Collider2D>().enabled = true;
    }

    private void SetSprite()
    {
        GetComponent<SpriteRenderer>().sprite = GetSpriteForColor(color);
    }

    private Sprite GetSpriteForColor(SpaceshipColor color)
    {
        Sprite sprite;
        switch (color)
        {
            case SpaceshipColor.Blue:
                return spriteReferences[0];
            case SpaceshipColor.Red:
                return spriteReferences[1];
            case SpaceshipColor.Yellow:
            default:
                return spriteReferences[2];
        }
    }

    public IEnumerator MovementCoroutine(float frequency)
    {
        while (true)
        {
            yield return new WaitForSeconds(frequency);

            SetPositionOnGrid(nextPosition, frequency / 2);

            currentPosition = nextPosition;
        }
    }

    public void SetPositionOnGrid(GridPosition position, float movementTime)
    {
        var gridBlock = Grid.Instance.GridBlocks[position.X, position.Y];

        if(movementTime > 0)
        {
            iTween.MoveTo(this.gameObject, gridBlock.transform.position, movementTime);
        }
        else
        {
            this.gameObject.transform.position = gridBlock.transform.position;
        }
    }

    public int HorizontalChange
    {
        get { return direction == Direction.Right ? 1 : -1; }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var otherSpaceship = other.GetComponent<Spaceship>();

        if(otherSpaceship.direction != direction)
        {
            var loosingSpaceships = GetLoosingSpaceships(this, otherSpaceship);

            foreach(var loosingSpaceship in loosingSpaceships)
            {
                Debug.Log("COLLISION");
                loosingSpaceship.enabled = false;
                Destroy(loosingSpaceship.gameObject);
                iTween.ScaleBy(loosingSpaceship.gameObject, 2 * Vector3.one, 0.15f);
            }
        }
    }

    public static Spaceship[] GetLoosingSpaceships(Spaceship a, Spaceship b)
    {
        if(a.color == b.color)
        {
            return new[] { a, b };
        }
        
        if(a.color == SpaceshipColor.Red && b.color == SpaceshipColor.Blue
            || a.color == SpaceshipColor.Blue && b.color == SpaceshipColor.Yellow
            || a.color == SpaceshipColor.Yellow && b.color == SpaceshipColor.Red)
        {
            return new [] { b };
        }
        else
        {
            return new[] { a };
        }
    }

}

