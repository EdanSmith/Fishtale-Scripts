using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CharacterCustomButton : MonoBehaviour
{

    private int charCurrentRotation;
    public int currentHair;
    public int currentShirt;
    public int currentPants;
    public int currentBodyType;
    public int currentEyebrows;
    public int currentEyes;
    public int currentMouth;
    public int currentShoes;

    public CharCustomManager ccm;

    void Start()
    {
        CharCustomManager.instance.characterCustomButton = this;

        charCurrentRotation = 0;
        // 0 = south, 1 = west, 2 = north, 3 = east

        currentHair = 0;
        currentShirt = 0;
        currentPants = 0;
        currentBodyType = 0;
        currentEyebrows = 0;
        currentEyes = 0;
        currentMouth = 0;
        currentShoes = 0;
    }

    public void rotateRight()
    {
        if (charCurrentRotation >= 3)
        {
            charCurrentRotation = 0;
        }else
        {
            charCurrentRotation += 1;
        }
        updateCharacterDirection(charCurrentRotation);
    }

    private void updateCharacterDirection(int currentDirection)
    {
        if (currentDirection == 0) // South
        {
            ccm.bodyPartsImage.north.SetActive(false);
            ccm.bodyPartsImage.south.SetActive(true); // True
            ccm.bodyPartsImage.east.SetActive(false);
            ccm.bodyPartsImage.west.SetActive(false);
        }else if (currentDirection == 1) // West
        {
            ccm.bodyPartsImage.north.SetActive(false);
            ccm.bodyPartsImage.south.SetActive(false);
            ccm.bodyPartsImage.east.SetActive(false);
            ccm.bodyPartsImage.west.SetActive(true); // True
        }else if (currentDirection == 2) // North
        {
            ccm.bodyPartsImage.north.SetActive(true); // True
            ccm.bodyPartsImage.south.SetActive(false);
            ccm.bodyPartsImage.east.SetActive(false);
            ccm.bodyPartsImage.west.SetActive(false);
        }else if (currentDirection == 3) // East
        {
            ccm.bodyPartsImage.north.SetActive(false);
            ccm.bodyPartsImage.south.SetActive(false);
            ccm.bodyPartsImage.east.SetActive(true); // True
            ccm.bodyPartsImage.west.SetActive(false);
        }
    }

    public void nextShirt()
    {
        currentShirt = counterRuleNext(currentShirt, ccm.baseShirts.Count);

        ccm.bodyPartsImage.southShirt.sprite = ccm.baseShirts[currentShirt].frontShirt;
        ccm.bodyPartsImage.southLeftSleeve.sprite = ccm.baseShirts[currentShirt].frontSleeve;
        ccm.bodyPartsImage.southRightSleeve.sprite = ccm.baseShirts[currentShirt].frontSleeve;

        ccm.bodyPartsImage.northShirt.sprite = ccm.baseShirts[currentShirt].backShirt;
        ccm.bodyPartsImage.northLeftSleeve.sprite = ccm.baseShirts[currentShirt].frontSleeve;
        ccm.bodyPartsImage.northRightSleeve.sprite = ccm.baseShirts[currentShirt].frontSleeve;

        ccm.bodyPartsImage.eastShirt.sprite = ccm.baseShirts[currentShirt].sideShirt;
        ccm.bodyPartsImage.eastLeftSleeve.sprite = ccm.baseShirts[currentShirt].sideSleeve;
        ccm.bodyPartsImage.eastRightSleeve.sprite = ccm.baseShirts[currentShirt].sideSleeve;

        ccm.bodyPartsImage.westShirt.sprite = ccm.baseShirts[currentShirt].sideShirt;
        ccm.bodyPartsImage.westLeftSleeve.sprite = ccm.baseShirts[currentShirt].sideSleeve;
        ccm.bodyPartsImage.westRightSleeve.sprite = ccm.baseShirts[currentShirt].sideSleeve;



        emptyImageRule(ccm.baseShirts[currentShirt].frontSleeve, ccm.bodyPartsImage.southLeftSleeve);
        emptyImageRule(ccm.baseShirts[currentShirt].frontSleeve, ccm.bodyPartsImage.southRightSleeve);


        emptyImageRule(ccm.baseShirts[currentShirt].frontSleeve, ccm.bodyPartsImage.northLeftSleeve);
        emptyImageRule(ccm.baseShirts[currentShirt].frontSleeve, ccm.bodyPartsImage.northRightSleeve);


        emptyImageRule(ccm.baseShirts[currentShirt].sideSleeve, ccm.bodyPartsImage.eastLeftSleeve);
        emptyImageRule(ccm.baseShirts[currentShirt].sideSleeve, ccm.bodyPartsImage.eastRightSleeve);


        emptyImageRule(ccm.baseShirts[currentShirt].sideSleeve, ccm.bodyPartsImage.westLeftSleeve);
        emptyImageRule(ccm.baseShirts[currentShirt].sideSleeve, ccm.bodyPartsImage.westRightSleeve);


        ccm.bodyPartsImage.updateAllImagesToNativeSize();
    }

    public void nextPants()
    {
        currentPants = counterRuleNext(currentPants, ccm.basePants.Count);

        ccm.bodyPartsImage.southLeftPants.sprite = ccm.basePants[currentPants].pants;
        ccm.bodyPartsImage.southRightPants.sprite = ccm.basePants[currentPants].pants;

        ccm.bodyPartsImage.northLeftPants.sprite = ccm.basePants[currentPants].pants;
        ccm.bodyPartsImage.northRightPants.sprite = ccm.basePants[currentPants].pants;

        ccm.bodyPartsImage.eastLeftPants.sprite = ccm.basePants[currentPants].pants;
        ccm.bodyPartsImage.eastRightPants.sprite = ccm.basePants[currentPants].pants;

        ccm.bodyPartsImage.westLeftPants.sprite = ccm.basePants[currentPants].pants;
        ccm.bodyPartsImage.westRightPants.sprite = ccm.basePants[currentPants].pants;


        ccm.bodyPartsImage.updateAllImagesToNativeSize();
    }

    public void nextEyes()
    {
        currentEyes = counterRuleNext(currentEyes, ccm.baseEyes.Count);

        ccm.bodyPartsImage.southLeftEye.sprite = ccm.baseEyes[currentEyes].frontEye;
        ccm.bodyPartsImage.southRightEye.sprite = ccm.baseEyes[currentEyes].frontEye;

        ccm.bodyPartsImage.eastEye.sprite = ccm.baseEyes[currentEyes].sideEye;

        ccm.bodyPartsImage.westEye.sprite = ccm.baseEyes[currentEyes].sideEye;

        ccm.bodyPartsImage.updateAllImagesToNativeSize();
    }

    public void nextHair()
    {
        currentHair = counterRuleNext(currentHair, ccm.baseHairs.Count);

        ccm.bodyPartsImage.southHair.sprite = ccm.baseHairs[currentHair].frontHair;
        ccm.bodyPartsImage.northHair.sprite = ccm.baseHairs[currentHair].backHair;
        ccm.bodyPartsImage.eastHair.sprite = ccm.baseHairs[currentHair].sideHair;
        ccm.bodyPartsImage.westHair.sprite = ccm.baseHairs[currentHair].sideHair;


        ccm.bodyPartsImage.updateAllImagesToNativeSize();
    }

    public void nextBodytype()
    {
        currentBodyType = counterRuleNext(currentBodyType, ccm.baseBodyTypes.Count);

        ccm.bodyPartsImage.southChest.sprite = ccm.baseBodyTypes[currentBodyType].frontChest;
        ccm.bodyPartsImage.northChest.sprite = ccm.baseBodyTypes[currentBodyType].frontChest;
        ccm.bodyPartsImage.eastChest.sprite = ccm.baseBodyTypes[currentBodyType].sideChest;
        ccm.bodyPartsImage.westChest.sprite = ccm.baseBodyTypes[currentBodyType].sideChest;

        ccm.bodyPartsImage.northHead.sprite = ccm.baseBodyTypes[currentBodyType].frontHead;
        ccm.bodyPartsImage.southHead.sprite = ccm.baseBodyTypes[currentBodyType].frontHead;
        ccm.bodyPartsImage.eastHead.sprite = ccm.baseBodyTypes[currentBodyType].sideHead;
        ccm.bodyPartsImage.westHead.sprite = ccm.baseBodyTypes[currentBodyType].sideHead;

        ccm.bodyPartsImage.northLeftArm.sprite = ccm.baseBodyTypes[currentBodyType].arm;
        ccm.bodyPartsImage.southLeftArm.sprite = ccm.baseBodyTypes[currentBodyType].arm;
        ccm.bodyPartsImage.eastLeftArm.sprite = ccm.baseBodyTypes[currentBodyType].arm;
        ccm.bodyPartsImage.westLeftArm.sprite = ccm.baseBodyTypes[currentBodyType].arm;
        ccm.bodyPartsImage.northRightArm.sprite = ccm.baseBodyTypes[currentBodyType].arm;
        ccm.bodyPartsImage.southRightArm.sprite = ccm.baseBodyTypes[currentBodyType].arm;
        ccm.bodyPartsImage.eastRightArm.sprite = ccm.baseBodyTypes[currentBodyType].arm;
        ccm.bodyPartsImage.westRightArm.sprite = ccm.baseBodyTypes[currentBodyType].arm;

        ccm.bodyPartsImage.northLeftLeg.sprite = ccm.baseBodyTypes[currentBodyType].leg;
        ccm.bodyPartsImage.southLeftLeg.sprite = ccm.baseBodyTypes[currentBodyType].leg;
        ccm.bodyPartsImage.eastLeftLeg.sprite = ccm.baseBodyTypes[currentBodyType].leg;
        ccm.bodyPartsImage.westLeftLeg.sprite = ccm.baseBodyTypes[currentBodyType].leg;
        ccm.bodyPartsImage.northRightLeg.sprite = ccm.baseBodyTypes[currentBodyType].leg;
        ccm.bodyPartsImage.southRightLeg.sprite = ccm.baseBodyTypes[currentBodyType].leg;
        ccm.bodyPartsImage.eastRightLeg.sprite = ccm.baseBodyTypes[currentBodyType].leg;
        ccm.bodyPartsImage.westRightLeg.sprite = ccm.baseBodyTypes[currentBodyType].leg;

        ccm.bodyPartsImage.updateAllImagesToNativeSize();
    }

    public void nextMouth()
    {
        currentMouth = counterRuleNext(currentMouth, ccm.baseMouths.Count);

        ccm.bodyPartsImage.southMouth.sprite = ccm.baseMouths[currentMouth].frontMouth;
        ccm.bodyPartsImage.eastMouth.sprite = ccm.baseMouths[currentMouth].sideMouth;
        ccm.bodyPartsImage.westMouth.sprite = ccm.baseMouths[currentMouth].sideMouth;

        ccm.bodyPartsImage.updateAllImagesToNativeSize();
    }

    public void nextShoes()
    {
        currentShoes = counterRuleNext(currentShoes, ccm.baseShoes.Count);

        ccm.bodyPartsImage.southLeftShoes.sprite = ccm.baseShoes[currentShoes].frontShoes;
        ccm.bodyPartsImage.southRightShoes.sprite = ccm.baseShoes[currentShoes].frontShoes;

        ccm.bodyPartsImage.northLeftShoes.sprite = ccm.baseShoes[currentShoes].backShoes;
        ccm.bodyPartsImage.northRightShoes.sprite = ccm.baseShoes[currentShoes].backShoes;

        ccm.bodyPartsImage.eastLeftShoes.sprite = ccm.baseShoes[currentShoes].sideShoes;
        ccm.bodyPartsImage.eastRightShoes.sprite = ccm.baseShoes[currentShoes].sideShoes;

        ccm.bodyPartsImage.westLeftShoes.sprite = ccm.baseShoes[currentShoes].sideShoes;
        ccm.bodyPartsImage.westRightShoes.sprite = ccm.baseShoes[currentShoes].sideShoes;


        ccm.bodyPartsImage.updateAllImagesToNativeSize();
    }

    public void nextEyebrows()
    {
        currentEyebrows = counterRuleNext(currentEyebrows, ccm.baseEyebrows.Count);

        ccm.bodyPartsImage.southLeftEyebrow.sprite = ccm.baseEyebrows[currentEyebrows].eyebrow;
        ccm.bodyPartsImage.southRightEyebrow.sprite = ccm.baseEyebrows[currentEyebrows].eyebrow;

        ccm.bodyPartsImage.eastEyebrow.sprite = ccm.baseEyebrows[currentEyebrows].eyebrow;

        ccm.bodyPartsImage.westEyebrow.sprite = ccm.baseEyebrows[currentEyebrows].eyebrow;


        ccm.bodyPartsImage.updateAllImagesToNativeSize();
    }

    private int counterRuleNext(int currentPiece, int maxAmount)
    {
        if (currentPiece >= maxAmount - 1)
        {
            currentPiece = 0;
        }
        else
        {
            currentPiece++;
        }
        return currentPiece;
    }

    private void emptyImageRule(Sprite sprite, Image image)
    {
        if (sprite == null)
            image.color = new Vector4(image.color.r, image.color.g, image.color.b, 0); //if there's no sprite, the image become 100% transparent
        else
            image.color = new Vector4(image.color.r, image.color.g, image.color.b, 255);
    }
}
