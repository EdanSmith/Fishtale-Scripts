using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BodyPartsImage : MonoBehaviour {

    [Header("Direction")]
    public GameObject north;
    public GameObject south;
    public GameObject east;
    public GameObject west;

    [Header("North")]
    public Image northHead;
    public Image northHair;
    public Image northLeftLeg; // Talk with dean if all the left/right parts are going to be the same, then you can just flip them all (Good because unity can derp a bit on the slicing)
    public Image northLeftPants; // Also ask majicPanda about the slicing properties, if bilinear... etc, if it's the best
    public Image northLeftShoes;
    public Image northRightLeg;
    public Image northRightPants;
    public Image northRightShoes;
    public Image northChest;
    public Image northShirt;
    public Image northLeftArm;
    public Image northLeftSleeve;
    public Image northRightArm;
    public Image northRightSleeve;

    [Header("South")]
    public Image southHead;
    public Image southHair;
    public Image southLeftEye;
    public Image southRightEye;
    public Image southLeftEyebrow;
    public Image southRightEyebrow;
    public Image southMouth;
    public Image southLeftLeg;
    public Image southLeftPants;
    public Image southLeftShoes;
    public Image southRightLeg;
    public Image southRightPants;
    public Image southRightShoes;
    public Image southChest;
    public Image southShirt;
    public Image southLeftArm;
    public Image southLeftSleeve;
    public Image southRightArm;
    public Image southRightSleeve;

    [Header("East")]
    public Image eastHead;
    public Image eastHair;
    public Image eastEye;
    public Image eastEyebrow;
    public Image eastMouth;
    public Image eastLeftLeg;
    public Image eastLeftPants;
    public Image eastLeftShoes;
    public Image eastRightLeg;
    public Image eastRightPants;
    public Image eastRightShoes;
    public Image eastChest;
    public Image eastShirt;
    public Image eastLeftArm;
    public Image eastLeftSleeve;
    public Image eastRightArm;
    public Image eastRightSleeve;

    [Header("West")]
    public Image westHead;
    public Image westHair;
    public Image westEye;
    public Image westEyebrow;
    public Image westMouth;
    public Image westLeftLeg;
    public Image westLeftPants;
    public Image westLeftShoes;
    public Image westRightLeg;
    public Image westRightPants;
    public Image westRightShoes;
    public Image westChest;
    public Image westShirt;
    public Image westLeftArm;
    public Image westLeftSleeve;
    public Image westRightArm;
    public Image westRightSleeve;

    void Start()
    {
        CharCustomManager.instance.bodyPartsImage = this;
    }

    public void updateAllImagesToNativeSize()
    {
        northHead.SetNativeSize();
        northHair.SetNativeSize();
        northLeftLeg.SetNativeSize();
        northLeftPants.SetNativeSize();
        northLeftShoes.SetNativeSize();
        northRightLeg.SetNativeSize();
        northRightPants.SetNativeSize();
        northRightShoes.SetNativeSize();
        northChest.SetNativeSize();
        northShirt.SetNativeSize();
        northLeftArm.SetNativeSize();
        northLeftSleeve.SetNativeSize();
        northRightArm.SetNativeSize();
        northRightSleeve.SetNativeSize();

        southHead.SetNativeSize();
        southHair.SetNativeSize();
        southLeftEye.SetNativeSize();
        southRightEye.SetNativeSize();
        southLeftEyebrow.SetNativeSize();
        southRightEyebrow.SetNativeSize();
        southMouth.SetNativeSize();
        southLeftLeg.SetNativeSize();
        southLeftPants.SetNativeSize();
        southLeftShoes.SetNativeSize();
        southRightLeg.SetNativeSize();
        southRightPants.SetNativeSize();
        southRightShoes.SetNativeSize();
        southChest.SetNativeSize();
        southShirt.SetNativeSize();
        southLeftArm.SetNativeSize();
        southLeftSleeve.SetNativeSize();
        southRightArm.SetNativeSize();
        southRightSleeve.SetNativeSize();

        eastHead.SetNativeSize();
        eastHair.SetNativeSize();
        eastEye.SetNativeSize();
        eastEyebrow.SetNativeSize();
        eastMouth.SetNativeSize();
        eastLeftLeg.SetNativeSize();
        eastLeftPants.SetNativeSize();
        eastLeftShoes.SetNativeSize();
        eastRightLeg.SetNativeSize();
        eastRightPants.SetNativeSize();
        eastRightShoes.SetNativeSize();
        eastChest.SetNativeSize();
        eastShirt.SetNativeSize();
        eastLeftArm.SetNativeSize();
        eastLeftSleeve.SetNativeSize();
        eastRightArm.SetNativeSize();
        eastRightSleeve.SetNativeSize();

        westHead.SetNativeSize();
        westHair.SetNativeSize();
        westEye.SetNativeSize();
        westEyebrow.SetNativeSize();
        westMouth.SetNativeSize();
        westLeftLeg.SetNativeSize();
        westLeftPants.SetNativeSize();
        westLeftShoes.SetNativeSize();
        westRightLeg.SetNativeSize();
        westRightPants.SetNativeSize();
        westRightShoes.SetNativeSize();
        westChest.SetNativeSize();
        westShirt.SetNativeSize();
        westLeftArm.SetNativeSize();
        westLeftSleeve.SetNativeSize();
        westRightArm.SetNativeSize();
        westRightSleeve.SetNativeSize();
    }
}
