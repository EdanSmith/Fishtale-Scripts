using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAnimation : MonoBehaviour
{

    public BirdData birdData;

    public void changeSprite(BirdSprite sprite)
    {
        GetComponent<SpriteRenderer>().sprite = birdData.birdSprite[(int)sprite];
    }
}
