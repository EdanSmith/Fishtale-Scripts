using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipItem : MonoBehaviour
{

    InventorySlot inventorySlot;
    ItemData itemData;
    private int slotId;

    private bool equippedMarkWasActive;

    public void equipItem()
    {
        inventorySlot = GetComponent<InventorySlot>();
        itemData = ItemManager.instance.GetItemDataById(inventorySlot.item.id);
        equippedMarkWasActive = GetComponent<InventorySlot>().equippedItemMark.gameObject.activeSelf;

        if (itemData.equipmentSlot == Equipment_Slot.Bait)
        {
            UIGameManager.instance.inventoryWindow.baitSlots[getSlotId(Equipment_Slot.Bait)].GetComponent<InventorySlot>().equippedItemMark.SetActive(false);

            if (equippedMarkWasActive)
                GameManager.instance.player.equippedItem[(int)Equipment_Slot.Bait] = null;
            else
                GameManager.instance.player.equippedItem[(int)Equipment_Slot.Bait] = itemData.id;

        }
        else if (itemData.equipmentSlot == Equipment_Slot.Lure)
        {
            getSlotId(Equipment_Slot.Lure);

            UIGameManager.instance.inventoryWindow.lureSlots[getSlotId(Equipment_Slot.Lure)].GetComponent<InventorySlot>().equippedItemMark.SetActive(false);

            if (equippedMarkWasActive)
                GameManager.instance.player.equippedItem[(int)Equipment_Slot.Lure] = null;
            else
                GameManager.instance.player.equippedItem[(int)Equipment_Slot.Lure] = itemData.id;
        }
        else if (itemData.equipmentSlot == Equipment_Slot.Reel)
        {
            getSlotId(Equipment_Slot.Reel);

            UIGameManager.instance.inventoryWindow.reelSlots[getSlotId(Equipment_Slot.Reel)].GetComponent<InventorySlot>().equippedItemMark.SetActive(false);

            if (equippedMarkWasActive)
                GameManager.instance.player.equippedItem[(int)Equipment_Slot.Reel] = null;
            else
                GameManager.instance.player.equippedItem[(int)Equipment_Slot.Reel] = itemData.id;
        }

        if (equippedMarkWasActive)
        {
            GetComponent<InventorySlot>().equippedItemMark.SetActive(false);
        }
        else
        {
            GetComponent<InventorySlot>().equippedItemMark.SetActive(true);
        }

        UIGameManager.instance.equippedItemsWindow.updateEquippedItems();
    }

    private int getSlotId(Equipment_Slot equipmentSlot)
    {
        if (GameManager.instance.player.equippedItem[(int)equipmentSlot] == null)// If player clicked on an equipment that has been unequipped
        {
            slotId = GetComponent<InventorySlot>().item.slotId;
        }
        else
        {
            slotId = ItemManager.instance.GetItemDataById(GameManager.instance.player.equippedItem[(int)equipmentSlot]).slotId; // slotId of the current equipped item
        }
        return slotId;
    }
}
