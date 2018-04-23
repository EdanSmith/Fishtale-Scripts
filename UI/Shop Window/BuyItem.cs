using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuyItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public ItemData itemData;
    public Image soldOutIcon;
    private Item item;

    void Awake()
    {
        item = ItemManager.instance.getItemById(itemData.id);
        if (item.unlocked && itemData.equipmentSlot != Equipment_Slot.Bait)
        {
            GetComponent<Button>().interactable = false;
            soldOutIcon.enabled = true;
        }
    }

    public void buyItem()
    {
        if (goldValidation())
        {
            ItemManager.instance.unlockItem(itemData.id);
            if (itemData.equipmentSlot == Equipment_Slot.Bag)
            {
                upgradeBag(itemData.id);
            }
            else if (itemData.equipmentSlot == Equipment_Slot.Rod)
            {
                GameManager.instance.player.equippedItem[(int)Equipment_Slot.Rod] = itemData.id;
            }

            if (itemData.equipmentSlot == Equipment_Slot.Bait)
            {
                int itemQuantity = ItemManager.instance.getItemById(itemData.id).quantity += 1;
                InventorySlot inventorySlot = UIGameManager.instance.inventoryWindow.baitSlots[itemData.slotId];
                inventorySlot.quantity.text = itemQuantity.ToString();
            }
            else
            {
                GetComponent<Button>().interactable = false;
                soldOutIcon.enabled = true;
            }
            GameObject hudCoinEffect = (GameObject)Instantiate(Resources.Load("Prefabs/Particles/HUD Coin Effect"), Vector2.zero, Quaternion.identity);
            hudCoinEffect.transform.SetParent(UIGameManager.instance.goldPanel.goldIcon.transform, false); // set where it will be in the hierarchy
            //GameObject particle = (GameObject)Instantiate(Resources.Load("Prefabs/Particles/Coin From To"), GameManager.instance.merchantNear.transform.position, Quaternion.identity);
            //particle.GetComponent<ParticleAttractor>().origin = GameManager.instance.playerMovement.transform;
            //particle.GetComponent<ParticleAttractor>().destiny = GameManager.instance.merchantNear.transform;
            //particle.GetComponent<ParticleSystem>().trigger.SetCollider(0, GameManager.instance.merchantNear.transform);
        }
    }

    private bool goldValidation()
    {
        if (GameManager.instance.player.currentGold >= itemData.price)
        {
            GameManager.instance.player.currentGold -= itemData.price;
            UIGameManager.instance.updateCurrentGold();
            return true;
        }
        else
        {
            return false;
        }
    }

    private void upgradeBag(string idBag)
    {
        Destroy(UIGameManager.instance.animatedInventoryWindow.gameObject);
        Destroy(UIGameManager.instance.animatedInventoryButton.gameObject);

        GameManager.instance.player.equippedItem[(int)Equipment_Slot.Bag] = idBag;
        GameObject bag = Instantiate(ItemManager.instance.GetItemDataById(GameManager.instance.player.equippedItem[(int)Equipment_Slot.Bag]).bagInventory);
        bag.transform.SetParent(UIGameManager.instance.animatedInventorySpot, false); // set where it will be in the hierarchy
        GameObject bagButtonIcon = Instantiate(ItemManager.instance.GetItemDataById(GameManager.instance.player.equippedItem[(int)Equipment_Slot.Bag]).bagButtonIcon);
        bagButtonIcon.transform.SetParent(UIGameManager.instance.animatedInventorySpot, false);

        for (int i = 0; i < GameManager.instance.saveItemData.savedFish.Count; i++) // Fill the inventory back with the fishes that it owns
        {
            UIGameManager.instance.addItemFishToPlayerInventory(GameManager.instance.saveItemData.savedFish[i]);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        UIGameManager.instance.eqPanel.ActivatePanel(new DisplayItemInfo(itemData));
        Debug.Log("Bag");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UIGameManager.instance.eqPanel.DeactivatePanel();
    }
}
