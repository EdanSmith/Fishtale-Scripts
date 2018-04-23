using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPartsSprite : MonoBehaviour {

    [Header("Direction")]
    public GameObject north;
    public GameObject south;
    public GameObject east;
    public GameObject west;

    [Header("North")]
    public SpriteRenderer northHead;
    public SpriteRenderer northHair;
    public SpriteRenderer northLeftLeg; // Talk with dean if all the left/right parts are going to be the same, then you can just flip them all (Good because unity can derp a bit on the slicing)
    public SpriteRenderer northLeftPants; // Also ask majicPanda about the slicing properties, if bilinear... etc, if it's the best
    public SpriteRenderer northLeftShoes;
    public SpriteRenderer northRightLeg;
    public SpriteRenderer northRightPants;
    public SpriteRenderer northRightShoes;
    public SpriteRenderer northChest;
    public SpriteRenderer northShirt;
    public SpriteRenderer northLeftArm;
    public SpriteRenderer northLeftSleeve;
    public SpriteRenderer northRightArm;
    public SpriteRenderer northRightSleeve;
    public SpriteRenderer northRod;
    public Transform northRodTip;

    [Header("South")]
    public SpriteRenderer southHead;
    public SpriteRenderer southHair;
    public SpriteRenderer southLeftEye;
    public SpriteRenderer southRightEye;
    public SpriteRenderer southLeftEyebrow;
    public SpriteRenderer southRightEyebrow;
    public SpriteRenderer southMouth;
    public SpriteRenderer southLeftLeg;
    public SpriteRenderer southLeftPants;
    public SpriteRenderer southLeftShoes;
    public SpriteRenderer southRightLeg;
    public SpriteRenderer southRightPants;
    public SpriteRenderer southRightShoes;
    public SpriteRenderer southChest;
    public SpriteRenderer southShirt;
    public SpriteRenderer southLeftArm;
    public SpriteRenderer southLeftSleeve;
    public SpriteRenderer southRightArm;
    public SpriteRenderer southRightSleeve;
    public SpriteRenderer southRod;
    public Transform southRodTip;

    [Header("East")]
    public SpriteRenderer eastHead;
    public SpriteRenderer eastHair;
    public SpriteRenderer eastEye;
    public SpriteRenderer eastEyebrow;
    public SpriteRenderer eastMouth;
    public SpriteRenderer eastLeftLeg;
    public SpriteRenderer eastLeftPants;
    public SpriteRenderer eastLeftShoes;
    public SpriteRenderer eastRightLeg;
    public SpriteRenderer eastRightPants;
    public SpriteRenderer eastRightShoes;
    public SpriteRenderer eastChest;
    public SpriteRenderer eastShirt;
    public SpriteRenderer eastLeftArm;
    public SpriteRenderer eastLeftSleeve;
    public SpriteRenderer eastRightArm;
    public SpriteRenderer eastRightSleeve;
    public SpriteRenderer eastRod;
    public Transform eastRodTip;

    [Header("West")]
    public SpriteRenderer westHead;
    public SpriteRenderer westHair;
    public SpriteRenderer westEye;
    public SpriteRenderer westEyebrow;
    public SpriteRenderer westMouth;
    public SpriteRenderer westLeftLeg;
    public SpriteRenderer westLeftPants;
    public SpriteRenderer westLeftShoes;
    public SpriteRenderer westRightLeg;
    public SpriteRenderer westRightPants;
    public SpriteRenderer westRightShoes;
    public SpriteRenderer westChest;
    public SpriteRenderer westShirt;
    public SpriteRenderer westLeftArm;
    public SpriteRenderer westLeftSleeve;
    public SpriteRenderer westRightArm;
    public SpriteRenderer westRightSleeve;
    public SpriteRenderer westRod;
    public Transform westRodTip;

    void Start()
    {
        //CharCustomManager.instance.bodyPartsSprite = this;
    }

    public Vector3 getRodTipDirectionPos(int direction)
    {
        if (direction == (int)Direction.North)
        {
            return northRodTip.position;
        }
        else if (direction == (int)Direction.South)
        {
            return southRodTip.position;
        }
        else if (direction == (int)Direction.East)
        {
            return eastRodTip.position;
        }
        else
        {
            return westRodTip.position;
        }
    }
}
