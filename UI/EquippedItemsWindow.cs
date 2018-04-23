using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EquippedItemsWindow : MonoBehaviour {

    public TextMeshProUGUI bag;
    public TextMeshProUGUI bait;
    public TextMeshProUGUI lure;
    public TextMeshProUGUI reel;
    public TextMeshProUGUI rod;
    private string none;

    // Use this for initialization
    void Start () {
        none = "None";
        UIGameManager.instance.equippedItemsWindow = this;
        updateEquippedItems();
    }
	
    public void updateEquippedItems()
    {
        if (ItemManager.instance.GetItemDataById(GameManager.instance.player.equippedItem[(int)Equipment_Slot.Bag]) == null)
            bag.text = none;
        else
            bag.text = TranslatorManager.instance.GetTranslationById("equipable_bag_name_" + ItemManager.instance.GetItemDataById(GameManager.instance.player.equippedItem[(int)Equipment_Slot.Bag]).id);


        if (ItemManager.instance.GetItemDataById(GameManager.instance.player.equippedItem[(int)Equipment_Slot.Bait]) == null)
            bait.text = none;
        else
            bait.text = TranslatorManager.instance.GetTranslationById("equipable_bait_name_" + ItemManager.instance.GetItemDataById(GameManager.instance.player.equippedItem[(int)Equipment_Slot.Bait]).id);


        if (ItemManager.instance.GetItemDataById(GameManager.instance.player.equippedItem[(int)Equipment_Slot.Lure]) == null)
            lure.text = none;
        else
            lure.text = TranslatorManager.instance.GetTranslationById("equipable_lure_name_" + ItemManager.instance.GetItemDataById(GameManager.instance.player.equippedItem[(int)Equipment_Slot.Lure]).id);


        if (ItemManager.instance.GetItemDataById(GameManager.instance.player.equippedItem[(int)Equipment_Slot.Reel]) == null)
            reel.text = none;
        else
            reel.text = TranslatorManager.instance.GetTranslationById("equipable_reel_name_" + ItemManager.instance.GetItemDataById(GameManager.instance.player.equippedItem[(int)Equipment_Slot.Reel]).id);


        if (ItemManager.instance.GetItemDataById(GameManager.instance.player.equippedItem[(int)Equipment_Slot.Rod]) == null)
            rod.text = none;
        else
            rod.text = TranslatorManager.instance.GetTranslationById("equipable_rod_name_" + ItemManager.instance.GetItemDataById(GameManager.instance.player.equippedItem[(int)Equipment_Slot.Rod]).id);
    }
}
