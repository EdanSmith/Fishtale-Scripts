using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryWindow : MonoBehaviour {

    public InventorySlot[] baitSlots;
    public InventorySlot[] lureSlots;
    public InventorySlot[] reelSlots;
    public InventorySlot bagSlot;
    public InventorySlot rodSlot;

    void Start () {
        UIGameManager.instance.inventoryWindow = this;
	}

    public void refresh()
    {
        foreach (InventorySlot slot in baitSlots)
        {
            slot.equippedItemMark.gameObject.SetActive(slot.item.id == GameManager.instance.player.equippedItem[(int)Equipment_Slot.Bait]);
        }

        foreach (InventorySlot slot in lureSlots)
        {
            slot.equippedItemMark.gameObject.SetActive(slot.item.id == GameManager.instance.player.equippedItem[(int)Equipment_Slot.Lure]);
        }

        foreach (InventorySlot slot in reelSlots)
        {
            slot.equippedItemMark.gameObject.SetActive(slot.item.id == GameManager.instance.player.equippedItem[(int)Equipment_Slot.Reel]);
        }
    }
}
