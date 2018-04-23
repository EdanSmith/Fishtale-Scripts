using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{

    public static ItemManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
                                                            //Awake is always called before any Start functions
    public List<FishItemData> baseFishItems = new List<FishItemData>();
    public List<ItemData> baseItems = new List<ItemData>();

    public UIItemFish fishPrefab;
    public ItemFish obtainedFish;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        baseFishItems.AddRange(Resources.LoadAll<FishItemData>("Fish Items Data"));
        baseItems.AddRange(Resources.LoadAll<ItemData>("Item Data"));
        generateAllItems();
    }

    // ====================== Fish Item =============================
    public FishItemData GetItemFishDataById(string id)
    {
        return baseFishItems.Find(x => x.id == id);
    }

    public void CreateRandomFish()
    {
        //FishItemData randFish = baseItems[Random.Range(0, baseItems.Count)];
        //ItemFish itemFish = new ItemFish(randFish);
        //UIItemFish newFish = Instantiate(fishPrefab);
        //newFish.Init(itemFish);
        //GameManager.instance.saveItemData.savedFish.Add(itemFish);
    }

    public ItemFish createItemFish(string baseId)
    {
        FishItemData fishItemData = this.GetItemFishDataById(baseId);
        ItemFish itemFish = new ItemFish(fishItemData);
        GameManager.instance.saveItemData.savedFish.Add(itemFish);
        return itemFish;
    }

    public ItemFish getItemFishByBaseId(string baseId) // creates temporary a new fish based on the baseId
    {
        FishItemData fishItemData = this.GetItemFishDataById(baseId);
        ItemFish itemFish = new ItemFish(fishItemData);
        return itemFish;
    }

    public void saveFishToDatabase(ItemFish itemFish)
    {
        GameManager.instance.saveItemData.savedFish.Add(itemFish);
    }

    public ItemFish getItemFishById(string id)
    {
        for (int i = 0; i < GameManager.instance.saveItemData.savedFish.Count; i++)
        {
            if (GameManager.instance.saveItemData.savedFish[i].id.Equals(id))
                return GameManager.instance.saveItemData.savedFish[i];
        }
        return null;
    }

    public void deleteItemFish(string id)
    {
        Debug.Log("Fish " + getItemFishById(id).id + " has been removed " + GameManager.instance.saveItemData.savedFish.Count);
        GameManager.instance.saveItemData.savedFish.Remove(this.getItemFishById(id));
    }

    public int sellItemFish(UIItemFish itemFish)
    {
        int value;
        value = (int)(itemFish.itemFish.weight * itemFish.itemFish.fishItemData.valuePerLb);
        deleteItemFish(itemFish.itemFish.id);
        Destroy(itemFish.gameObject);
        return value;
    }

    public FishRecord getFishRecordById(string baseId)
    {
        for (int i = 0; i < GameManager.instance.saveItemData.savedFishRecord.Count; i++)
        {
            if (GameManager.instance.saveItemData.savedFishRecord[i].baseId.Equals(baseId))
                return GameManager.instance.saveItemData.savedFishRecord[i];
        }
        return null;
    }

    public int getFishRecordIndexById(string baseId)
    {
        for (int i = 0; i < GameManager.instance.saveItemData.savedFishRecord.Count; i++)
        {
            if (GameManager.instance.saveItemData.savedFishRecord[i].baseId.Equals(baseId))
                return i;
        }
        return -1;
    }

    public bool saveFishRecordToDatabase(ItemFish itemFish)
    {
        FishRecord fishRecord = new FishRecord();
        FishRecord oldRecord = getFishRecordById(itemFish.baseId);
        bool newRecord = false;
        fishRecord.baseId = itemFish.baseId;
        if (oldRecord != null)
        {
            fishRecord.totalCaught = oldRecord.totalCaught + 1;

            if (oldRecord.smallestCaught > itemFish.length)
                fishRecord.smallestCaught = itemFish.length;
            else
                fishRecord.smallestCaught = oldRecord.smallestCaught;

            if (oldRecord.biggestCaught < itemFish.length)
            {
                fishRecord.biggestCaught = itemFish.length;
                newRecord = true;
            }
            else
                fishRecord.biggestCaught = oldRecord.biggestCaught;

            if (oldRecord.highestStar < itemFish.star)
                fishRecord.highestStar = itemFish.star;
            else
                fishRecord.highestStar = oldRecord.highestStar;

            GameManager.instance.saveItemData.savedFishRecord[getFishRecordIndexById(itemFish.baseId)] = fishRecord;
            return newRecord;
        }
        else
        {
            fishRecord.totalCaught = 1;
            fishRecord.smallestCaught = itemFish.length;
            fishRecord.biggestCaught = itemFish.length;
            fishRecord.highestStar = itemFish.star;
            GameManager.instance.saveItemData.savedFishRecord.Add(fishRecord);
            return true;
        }
    }


    // ===================== Equipable/Upgradable Item ========================

    public ItemData GetItemDataById(string id)
    {
        return baseItems.Find(x => x.id == id);
    }

    public Item getItemById(string id)
    {
        for (int i = 0; i < GameManager.instance.saveItemData.savedItem.Count; i++)
        {
            if (GameManager.instance.saveItemData.savedItem[i].itemId.Equals(id))
                return GameManager.instance.saveItemData.savedItem[i];
        }
        return null;
    }

    public void generateAllItems()
    {
        for (int i = 0; i < baseItems.Count; i++)
        {
            Item item = new Item(GetItemDataById(baseItems[i].id));
            GameManager.instance.saveItemData.savedItem.Add(item);
        }
    }

    public void unlockItem(string id)
    {
        //GameManager.instance.saveItemData.savedItem[0].unlocked = true;
        Item item = getItemById(id);
        item.unlocked = true;
        UIGameManager.instance.unlockItem(GetItemDataById(item.itemId));
    }
}
