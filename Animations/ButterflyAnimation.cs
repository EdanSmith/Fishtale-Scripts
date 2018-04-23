using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyAnimation : MonoBehaviour {

    public ButterflyData butterflyData;

    public void changeSprite(int sprite)
    {
        GetComponent<SpriteRenderer>().sprite = butterflyData.butterflySprite[sprite];
    }
}
