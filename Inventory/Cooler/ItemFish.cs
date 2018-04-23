using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using LitJson;

public class ItemFish {

    public string id;
    public string baseId; // = FishData ID
    public double length;
    public double weight;
    public int star;

    [JsonIgnore]
    public string displayName { get { return fishItemData.fishName; } }
    //[JsonIgnore]
    //public Sprite fishSprite { get { return fishItemData.fishItemImage; } }

    //data to save
    [JsonIgnore]
    public FishItemData fishItemData; // Note: JSON ignores private attributes

    private float randomRange;

    public ItemFish() { }

    public ItemFish(FishItemData fishItemData)
    {
        this.fishItemData = fishItemData;
        this.baseId = fishItemData.id;
        this.randomRange = Random.Range(0.5f, 2f);
        this.length = System.Math.Round(fishItemData.length * randomRange, 2); // rounding the values to have a maximum of 2 decimal numbers
        this.weight = System.Math.Round(fishItemData.weight * randomRange, 2); // rounding the values to have a maximum of 2 decimal numbers
        this.star = starLevel(randomRange);
        this.id = System.Guid.NewGuid().ToString();
    }

    public ItemFish(string id, FishItemData fishItemData)// Used when first saving data from JSON to the UI
    {
        this.fishItemData = fishItemData;
        this.baseId = fishItemData.id;
        this.randomRange = Random.Range(0.5f, 2f);
        this.length = System.Math.Round(fishItemData.length * randomRange, 2); // rounding the values to have a maximum of 2 decimal numbers
        this.weight = System.Math.Round(fishItemData.weight * randomRange, 2); // rounding the values to have a maximum of 2 decimal numbers
        this.star = starLevel(randomRange);
        this.id = id;
    }

    public ItemFish(string id, string baseId, double length, double weight, int star)
    {
        this.baseId = baseId;
        this.length = length;
        this.weight = weight;
        this.star = star;
        this.id = id;
        fishItemData = ItemManager.instance.GetItemFishDataById(baseId);
    }// Used when first saving data from JSON to the GameManager List

    private int starLevel(float randomRange)
    {
        if (randomRange <= 0.95f)
            return 1;
        else if (randomRange <= 1.4f)
            return 2;
        else if (randomRange <= 1.85f)
            return 3;
        else
            return 4;
    }

}