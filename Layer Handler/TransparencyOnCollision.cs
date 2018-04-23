using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparencyOnCollision : MonoBehaviour {

    private Color32 color;
    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        color = spriteRenderer.color;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "Player")
        {
            color.a = 100; 
            spriteRenderer.color = color;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.name == "Player")
        {
            color.a = 255;
            spriteRenderer.color = color;
        }
    }
}
