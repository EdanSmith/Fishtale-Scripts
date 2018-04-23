using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{

    private BoxCollider2D bc;
    private float minX;
    private float minY;
    private float maxX;
    private float maxY;
    private float counter;

    public float spawnSpeed;

    // Use this for initialization
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {

        counter += Time.deltaTime;

        if (counter >= spawnSpeed)
        {
            //minX = transform.position.x - (bc.size.x / 2);
            //minY = transform.position.y - (bc.size.y / 2);
            //maxX = transform.position.x + (bc.size.x / 2);
            //maxY = transform.position.y + (bc.size.y / 2);
            minX = 0 - bc.size.x / 2;
            minY = 0 - bc.size.y / 2;
            maxX = 0 + bc.size.x / 2;
            maxY = 0 + bc.size.y / 2;
            GameObject bubble = (GameObject)Instantiate(Resources.Load("Prefabs/Animation/Bubble Animation"), new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY)), Quaternion.identity);
            bubble.transform.SetParent(transform, false);
            counter = 0;
        }
    }
}
