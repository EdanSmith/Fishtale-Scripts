using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butterfly : MonoBehaviour
{

    private float counter;
    private Vector2 destination;
    public SpriteRenderer spriteRenderer;
    public float moveSpeed = 5;

    // Use this for initialization
    void Start()
    {
        counter = 3;
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if (counter >= 3f)
        {
            destination = new Vector2(transform.position.x + Random.Range(-10, 10), transform.position.y + Random.Range(-10, 10));
            counter = 0;
            StartCoroutine(flyToDestination(3f));
        }
    }

    private IEnumerator flyToDestination(float seconds)
    {
        updateButterflyDirection(destination);

        float startTime = Time.time;
        while (Time.time < startTime + seconds)
        {
            transform.position = Vector2.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);
            yield return null;
        }
        yield return null;

    }

    private void updateButterflyDirection(Vector2 destination)
    {
        // Get Angle in Radians
        float AngleRad = Mathf.Atan2(transform.position.y - destination.y, transform.position.x - destination.x);
        // Get Angle in Degrees
        float angle = (180 / Mathf.PI) * AngleRad;

        if (angle < -90f || angle > 90f)
            spriteRenderer.flipX = false;
        else
            spriteRenderer.flipX = true;
    }

}
