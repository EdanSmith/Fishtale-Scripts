using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    public BodyPartsSprite bodyPartsSprite;

    public void northRodActive(int boolean)
    {
        if (boolean == 0)
            bodyPartsSprite.northRod.enabled = false;
        else
            bodyPartsSprite.northRod.enabled = true;
    }

    public void southRodActive(int boolean)
    {
        if (boolean == 0)
           bodyPartsSprite.southRod.enabled = false;
        else
           bodyPartsSprite.southRod.enabled = true;
    }

    public void eastRodActive(int boolean)
    {
        if (boolean == 0)
           bodyPartsSprite.eastRod.enabled = false;
        else
           bodyPartsSprite.eastRod.enabled = true;
    }

    public void westRodActive(int boolean)
    {
        if (boolean == 0)
           bodyPartsSprite.westRod.enabled = false;
        else
           bodyPartsSprite.westRod.enabled = true;
    }

    //public void northRodLayer(int layer)
    //{
    //   bodyPartsSprite.northRod.sortingOrder = layer;
    //}
    //public void southRodLayer(int layer)
    //{
    //   bodyPartsSprite.southRod.sortingOrder = layer;
    //}
    //public void eastRodLayer(int layer)
    //{
    //   bodyPartsSprite.eastRod.sortingOrder = layer;
    //}
    //public void westRodLayer(int layer)
    //{
    //   bodyPartsSprite.westRod.sortingOrder = layer;
    //}

    //public void northRightArm(int layer)
    //{
    //   bodyPartsSprite.northRightArm.sortingOrder = layer;
    //}

    //public void northLeftArm(int layer)
    //{
    //   bodyPartsSprite.northLeftArm.sortingOrder = layer;
    //}

    //public void northRightSleeve(int layer)
    //{
    //   bodyPartsSprite.northRightSleeve.sortingOrder = layer;
    //}

    //public void northLeftSleeve(int layer)
    //{
    //   bodyPartsSprite.northLeftSleeve.sortingOrder = layer;
    //}

    public void southRightArm(int layer)
    {
       bodyPartsSprite.southRightArm.sortingOrder = layer;
    }

    public void southLeftArm(int layer)
    {
       bodyPartsSprite.southLeftArm.sortingOrder = layer;
    }

    public void southRightSleeve(int layer)
    {
       bodyPartsSprite.southRightSleeve.sortingOrder = layer;
    }

    public void southLeftSleeve(int layer)
    {
       bodyPartsSprite.southLeftSleeve.sortingOrder = layer;
    }

    //public void eastRightArm(int layer)
    //{
    //   bodyPartsSprite.eastRightArm.sortingOrder = layer;
    //}

    //public void eastLeftArm(int layer)
    //{
    //   bodyPartsSprite.eastLeftArm.sortingOrder = layer;
    //}

    //public void eastRightSleeve(int layer)
    //{
    //   bodyPartsSprite.eastRightSleeve.sortingOrder = layer;
    //}

    //public void eastLeftSleeve(int layer)
    //{
    //   bodyPartsSprite.eastLeftSleeve.sortingOrder = layer;
    //}

    //public void westRightArm(int layer)
    //{
    //   bodyPartsSprite.westRightArm.sortingOrder = layer;
    //}

    //public void westLeftArm(int layer)
    //{
    //   bodyPartsSprite.westLeftArm.sortingOrder = layer;
    //}

    //public void westRightSleeve(int layer)
    //{
    //   bodyPartsSprite.westRightSleeve.sortingOrder = layer;
    //}

    //public void westLeftSleeve(int layer)
    //{
    //   bodyPartsSprite.westLeftSleeve.sortingOrder = layer;
    //}

    public void lureLayer(int layer)
    {
        GameManager.instance.hook.GetComponent<SpriteRenderer>().sortingOrder = layer;
    }
}
