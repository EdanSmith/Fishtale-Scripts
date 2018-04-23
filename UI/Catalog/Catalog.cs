using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Catalog : MonoBehaviour {

    public int currentPageGroup;
    //public int currentLeftPage;
    public List<CatalogPageGroup> catalogPageGroup;

    private FishItemData fishItemData;
    private FishRecord fishRecord;
    private int recordIndex;
    private string unknown;

    [Header("Left Page")]
    public TextMeshProUGUI leftFishName;
    public TextMeshProUGUI leftTotalCaught;
    public TextMeshProUGUI leftSmallestCaught;
    public TextMeshProUGUI leftBiggestCaught;
    public TextMeshProUGUI leftRarity;
    public TextMeshProUGUI leftDescription;
    public Image leftFishPortrait;
    public List<Image> leftStarIcon;

    [Header("Right Page")]
    public TextMeshProUGUI rightFishName;
    public TextMeshProUGUI rightTotalCaught;
    public TextMeshProUGUI rightSmallestCaught;
    public TextMeshProUGUI rightBiggestCaught;
    public TextMeshProUGUI rightRarity;
    public TextMeshProUGUI rightDescription;
    public Image rightFishPortrait;
    public List<Image> rightStarIcon;

    void Start()
    {
        UIGameManager.instance.catalog = this;
        unknown = "?????";
    }

    public void refresh()
    {
        refreshLeftPage();
        refreshRightPage();
    }

    private void refreshLeftPage()
    {
        fishItemData = catalogPageGroup[currentPageGroup].leftPage.fishItemInfo;
        recordIndex = ItemManager.instance.getFishRecordIndexById(fishItemData.id);
        for (int i = 0; i < leftStarIcon.Count; i++)
        {
            leftStarIcon[i].gameObject.SetActive(false);
        }
        if (recordIndex != -1)
        {
            leftFishName.text = TranslatorManager.instance.GetTranslationById("fish_name_" + fishItemData.id);
            leftTotalCaught.text = GameManager.instance.saveItemData.savedFishRecord[recordIndex].totalCaught.ToString();
            leftSmallestCaught.text = GameManager.instance.saveItemData.savedFishRecord[recordIndex].smallestCaught.ToString() + " " + TranslatorManager.instance.GetTranslationById("measurement_inches");
            leftBiggestCaught.text = GameManager.instance.saveItemData.savedFishRecord[recordIndex].biggestCaught.ToString() + " " + TranslatorManager.instance.GetTranslationById("measurement_inches");
            leftRarity.text = TranslatorManager.instance.GetTranslationById("rarity_" + fishItemData.rarity);
            leftDescription.text = TranslatorManager.instance.GetTranslationById("fish_description_" + fishItemData.id);
            leftFishPortrait.sprite = fishItemData.fishPortraitImage;
            leftFishPortrait.preserveAspect = true;

            for (int i = 0; i < GameManager.instance.saveItemData.savedFishRecord[recordIndex].highestStar; i++)
            {
                leftStarIcon[i].gameObject.SetActive(true);
            }
        }else
        {
            leftFishName.text = unknown;
            leftTotalCaught.text = unknown;
            leftSmallestCaught.text = unknown;
            leftBiggestCaught.text = unknown;
            leftRarity.text = unknown;
            leftDescription.text = unknown;
            leftFishPortrait.sprite = fishItemData.fishHiddenPortraitImage;
            leftFishPortrait.preserveAspect = true;
        }
    }

    private void refreshRightPage()
    {
        fishItemData = catalogPageGroup[currentPageGroup].rightPage.fishItemInfo;
        recordIndex = ItemManager.instance.getFishRecordIndexById(fishItemData.id);
        for (int i = 0; i < rightStarIcon.Count; i++)
        {
            rightStarIcon[i].gameObject.SetActive(false);
        }
        if (recordIndex != -1)
        {
            rightFishName.text = TranslatorManager.instance.GetTranslationById("fish_name_" + fishItemData.id);
            rightTotalCaught.text = GameManager.instance.saveItemData.savedFishRecord[recordIndex].totalCaught.ToString();
            rightSmallestCaught.text = GameManager.instance.saveItemData.savedFishRecord[recordIndex].smallestCaught.ToString() + " " + TranslatorManager.instance.GetTranslationById("measurement_inches");
            rightBiggestCaught.text = GameManager.instance.saveItemData.savedFishRecord[recordIndex].biggestCaught.ToString() + " " + TranslatorManager.instance.GetTranslationById("measurement_inches");
            rightRarity.text = TranslatorManager.instance.GetTranslationById("rarity_" + fishItemData.rarity);
            rightDescription.text = TranslatorManager.instance.GetTranslationById("fish_description_" + fishItemData.id);
            rightFishPortrait.sprite = fishItemData.fishPortraitImage;
            rightFishPortrait.preserveAspect = true;
            for (int i = 0; i < GameManager.instance.saveItemData.savedFishRecord[recordIndex].highestStar; i++)
            {
                rightStarIcon[i].gameObject.SetActive(true);
            }
        }
        else
        {
            rightFishName.text = unknown;
            rightTotalCaught.text = unknown;
            rightSmallestCaught.text = unknown;
            rightBiggestCaught.text = unknown;
            rightRarity.text = unknown;
            rightDescription.text = unknown;
            rightFishPortrait.sprite = fishItemData.fishHiddenPortraitImage;
            rightFishPortrait.preserveAspect = true;
        }
    }
}
