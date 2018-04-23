using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class Item {

    public string itemId;
    public int quantity;
    public bool unlocked;

    [JsonIgnore]
    public ItemData itemData;

    public Item()
    {

    }

    public Item(ItemData itemData) // Used to generate the items
    {
        this.itemId = itemData.id;
        this.quantity = 0;
        this.unlocked = false;
    }
}
