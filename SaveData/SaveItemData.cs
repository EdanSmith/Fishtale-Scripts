using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveItemData
{
    //this class should be serialized in it's entire state from game manager etc
    public List<ItemFish> savedFish = new List<ItemFish>();
    public List<Item> savedItem = new List<Item>();
    public List<FishRecord> savedFishRecord = new List<FishRecord>();
}
