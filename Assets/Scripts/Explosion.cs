using UnityEngine;
using System.Collections;
using System.Linq;

public class Explosion : MonoBehaviour
{
    public float limit;
    public float timeout;
    public float scaleFactor;
    public float rotationFactor;

	void Start ()
    {
        StartCoroutine(Explode());
	}

    private IEnumerator Explode()
    {
        var items = GetComponentsInChildren<SpriteRenderer>().ToArray();

        int i = 0;
        while(limit-- >= 0)
        {
            yield return new WaitForSeconds(timeout);

            if (++i == items.Length) i = 0;
            foreach (var item in items) item.enabled = false;
            items[i].enabled = true;

            gameObject.transform.Rotate(0, 0, rotationFactor);
            gameObject.transform.localScale = gameObject.transform.localScale * scaleFactor;
        }

        Destroy(gameObject);
    }
}
