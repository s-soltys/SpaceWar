using UnityEngine;
using System.Collections;

public class Spaceship : MonoBehaviour {

    private GridPosition currentPosition;
    private Direction direction;
    private SpaceshipColor color;
    public Sprite[] spriteReferences;

    public virtual GridPosition GetNextPosition(GridPosition p)
    {
        return p;
    }

    public virtual void Deploy(GridPosition initialPosition, Direction direction, SpaceshipColor color)
    {
        this.direction = direction;
        this.currentPosition = initialPosition;
        this.color = color;

        SetPositionOnGrid(initialPosition, 0);

        this.gameObject.transform.Rotate(0, 0, (direction == Direction.Left) ? 0 : 180);

        GetComponent<SpriteRenderer>().sprite = GetSpriteForColor(color, direction);
        GetComponent<Collider2D>().enabled = true;
    }


    private Sprite GetSpriteForColor(SpaceshipColor color, Direction direction)
    {
        int index = 0;
        Sprite sprite;
        switch (color)
        {
            case SpaceshipColor.Blue:
                index = 0;
                break;
            case SpaceshipColor.Red:
                index = 1;
                break;
            case SpaceshipColor.Yellow:
                index = 2;
                break;
        }

        //if (direction == Direction.Right) index += 3;

        return spriteReferences[index];
    }

    public IEnumerator MovementCoroutine(float frequency)
    {
        while (true)
        {
            yield return new WaitForSeconds(frequency);
            Move(frequency);
        }
    }

    public void Move(float frequency)
    {
        var nextPosition = GetNextPosition(currentPosition);

        if (nextPosition.IsValidX)
        {
            SetPositionOnGrid(nextPosition, frequency);
            currentPosition = nextPosition;
        }

        if (enabled && !GetNextPosition(currentPosition).IsValidX)
        {
            GetComponent<Collider2D>().enabled = false;
            enabled = false;

            GameplayManager.Instance.DeleteLive(direction);
            iTween.MoveBy(gameObject, 2 * Vector3.up, 1.0f);
            iTween.ScaleBy(gameObject, Vector3.zero, 1.0f);
            Destroy(this.gameObject, 2);

            transform.GetComponentInChildren<ParticleRenderer>().enabled = false;

            audio.Play();
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
                loosingSpaceship.enabled = false;
                Destroy(loosingSpaceship.gameObject);
                iTween.ScaleBy(loosingSpaceship.gameObject, 2 * Vector3.one, 0.15f);
            }

            if (loosingSpaceships.Length > 0)
            {
                var item = Instantiate(GameplayManager.Instance.explosionPrefab, this.transform.position, Quaternion.identity);
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

