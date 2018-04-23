using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSpecificationWindow : MonoBehaviour
{

    private UIItemFish selectedFish;
    private FishItemData selectedFishData;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemLength;
    public TextMeshProUGUI itemWeight;
    public TextMeshProUGUI itemRarity;
    public Image itemImage;
    public TMP_FontAsset gameFont;
    public List<Image> starIcon;

    private float imageHeight;
    private TranslatorManager tm;

    // Use this for initialization
    void Start()
    {
        selectedFish = UIGameManager.instance.selectedFish;
        selectedFishData = ItemManager.instance.GetItemFishDataById(selectedFish.itemFish.baseId);
        tm = TranslatorManager.instance;
        itemName.text = tm.GetTranslationById("fish_name_" + selectedFishData.id); //selectedFishData.fishName;
        itemLength.text = selectedFish.itemFish.length.ToString() + " " + tm.GetTranslationById("measurement_inches");
        itemWeight.text = selectedFish.itemFish.weight.ToString() + " " + tm.GetTranslationById("measurement_pounds");
        itemRarity.text = tm.GetTranslationById("rarity_" + selectedFishData.rarity);
        itemImage.sprite = selectedFishData.fishPortraitImage;
        itemImage.preserveAspect = true;
        imageHeight = selectedFish.transform.parent.gameObject.GetComponent<RectTransform>().rect.height;
        transform.position = new Vector3(selectedFish.transform.position.x, selectedFish.transform.position.y + (Screen.height / 100) * 5, 0);
    }

    void Update()
    {
        imageHeight = selectedFish.transform.parent.gameObject.GetComponent<RectTransform>().rect.height;
        this.transform.position = new Vector3(selectedFish.transform.position.x, selectedFish.transform.position.y + (Screen.height / 100) * 5, 0);
    }

    public void refresh()
    {
        for (int i = 0; i < starIcon.Count; i++)
        {
            starIcon[i].gameObject.SetActive(false);
        }
        Start();
        for (int i = 0; i < selectedFish.itemFish.star; i++) {
            starIcon[i].gameObject.SetActive(true);
        }
    }

    public TMP_FontAsset getFont()
    {
        return this.gameFont;
    }
}
