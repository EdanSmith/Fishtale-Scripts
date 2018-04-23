using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class LoadGame : MonoBehaviour
{
    // Reminder -- Load is usually separated in 2 pieces, the UI load and the gameData load (json)
    private JsonData itemData;
    private JsonData charCustomData;

    public void loadGame()
    {
        loadEquippedItems();
        loadCoolerInventoryItems();
        loadTackleBoxInventoryItems();
        loadCharacterCustomization();
        loadFishRecords();
        UIGameManager.instance.updateCurrentGold(); //Load current gold
    }

    private void loadCoolerInventoryItems()
    {
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/ItemsFish.json"));

        for (int i = 0; i < itemData.Count; i++) // for each item on Json
        {
            GameManager.instance.saveItemData.savedFish.Add(new ItemFish(itemData[i]["id"].ToString(), itemData[i]["baseId"].ToString(), (double)itemData[i]["length"], (double)itemData[i]["weight"], (int)itemData[i]["star"])); // STORING FISH ITEM TO BE SAVED ON JSON
            UIGameManager.instance.addItemFishToPlayerInventory(ItemManager.instance.getItemFishById(itemData[i]["id"].ToString())); // stores the fish on the player inventory
        }
    }

    private void loadTackleBoxInventoryItems()
    {
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));

        for (int i = 0; i < itemData.Count; i++) // for each item on Json
        {
            if ((bool)itemData[i]["unlocked"])
            {
                Item item = ItemManager.instance.getItemById(itemData[i]["itemId"].ToString());
                item.unlocked = true; // enabling the items that are already enabled on Json
                item.quantity = (int)itemData[i]["quantity"];
                UIGameManager.instance.unlockItem(ItemManager.instance.GetItemDataById(itemData[i]["itemId"].ToString()), item.quantity);
            }
        }
    }

    private void loadEquippedItems()
    {
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Player.json"));

        Player player = GameManager.instance.player;
        if (itemData["equippedItem"][(int)Equipment_Slot.Bait] != null)
        {
            player.equippedItem[(int)Equipment_Slot.Bait] = itemData["equippedItem"][(int)Equipment_Slot.Bait].ToString();
            //InventorySlot inventorySlot = UIGameManager.instance.inventoryWindow.baitSlots[ItemManager.instance.GetItemDataById(player.equippedItem[(int)Equipment_Slot.Bait]).slotId];
            //inventorySlot.equippedItemMark.SetActive(true);
        }
        if (itemData["equippedItem"][(int)Equipment_Slot.Lure] != null)
        {
            player.equippedItem[(int)Equipment_Slot.Lure] = itemData["equippedItem"][(int)Equipment_Slot.Lure].ToString();
        }
        if (itemData["equippedItem"][(int)Equipment_Slot.Reel] != null)
        {
            player.equippedItem[(int)Equipment_Slot.Reel] = itemData["equippedItem"][(int)Equipment_Slot.Reel].ToString();
        }
        if (itemData["equippedItem"][(int)Equipment_Slot.Bag] != null)
        {
            player.equippedItem[(int)Equipment_Slot.Bag] = itemData["equippedItem"][(int)Equipment_Slot.Bag].ToString();
        }
        if (itemData["equippedItem"][(int)Equipment_Slot.Rod] != null)
        {
            player.equippedItem[(int)Equipment_Slot.Rod] = itemData["equippedItem"][(int)Equipment_Slot.Rod].ToString();
        }
        UIGameManager.instance.inventoryWindow.refresh(); // Highlight the equipped items

        //======= Bag ========
        player.equippedItem[(int)Equipment_Slot.Bag] = itemData["equippedItem"][(int)Equipment_Slot.Bag].ToString();
        GameObject bag = Instantiate(ItemManager.instance.GetItemDataById(player.equippedItem[(int)Equipment_Slot.Bag]).bagInventory);
        bag.transform.SetParent(UIGameManager.instance.animatedInventorySpot, false); // set where it will be in the hierarchy
        GameObject bagButtonIcon = Instantiate(ItemManager.instance.GetItemDataById(player.equippedItem[(int)Equipment_Slot.Bag]).bagButtonIcon);
        bagButtonIcon.transform.SetParent(UIGameManager.instance.animatedInventorySpot, false);

        UIGameManager.instance.equippedItemsWindow.updateEquippedItems();
    }

    private void loadCharacterCustomization()
    {
        charCustomData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/PlayerCustomization.json"));

        BodyPartsSprite bps = GameManager.instance.playerMovement.bodyPartsSprite;

        BodyTypeData bodyType = CharCustomManager.instance.GetBodyTypeDataById(charCustomData["bodyTypeId"].ToString());
        EyebrowsData eyebrows = CharCustomManager.instance.GetEyebrowsDataById(charCustomData["eyebrowsId"].ToString());
        EyesData eyes = CharCustomManager.instance.GetEyesDataById(charCustomData["eyesId"].ToString());
        HairData hair = CharCustomManager.instance.GetHairDataById(charCustomData["hairId"].ToString());
        MouthData mouth = CharCustomManager.instance.GetMouthDataById(charCustomData["mouthId"].ToString());
        PantsData pants = CharCustomManager.instance.GetPantsDataById(charCustomData["pantsId"].ToString());
        ShirtData shirt = CharCustomManager.instance.GetShirtDataById(charCustomData["shirtId"].ToString());
        ShoesData shoes = CharCustomManager.instance.GetShoesDataById(charCustomData["shoesId"].ToString());

        bps.southHead.sprite = bodyType.frontHead;
        bps.southHair.sprite = hair.frontHair;
        bps.southLeftEye.sprite = eyes.frontEye;
        bps.southRightEye.sprite = eyes.frontEye;
        bps.southLeftEyebrow.sprite = eyebrows.eyebrow;
        bps.southRightEyebrow.sprite = eyebrows.eyebrow;
        bps.southMouth.sprite = mouth.frontMouth;
        bps.southLeftLeg.sprite = bodyType.leg;
        bps.southLeftPants.sprite = pants.pants;
        bps.southLeftShoes.sprite = shoes.frontShoes;
        bps.southRightLeg.sprite = bodyType.leg;
        bps.southRightPants.sprite = pants.pants;
        bps.southRightShoes.sprite = shoes.frontShoes;
        bps.southChest.sprite = bodyType.frontChest;
        bps.southShirt.sprite = shirt.frontShirt;
        bps.southLeftArm.sprite = bodyType.arm;
        bps.southLeftSleeve.sprite = shirt.frontSleeve;
        bps.southRightArm.sprite = bodyType.arm;
        bps.southRightSleeve.sprite = shirt.frontSleeve;

        bps.northHead.sprite = bodyType.frontHead;
        bps.northHair.sprite = hair.backHair;
        bps.northLeftLeg.sprite = bodyType.leg;
        bps.northLeftPants.sprite = pants.pants;
        bps.northLeftShoes.sprite = shoes.backShoes;
        bps.northRightLeg.sprite = bodyType.leg;
        bps.northRightPants.sprite = pants.pants;
        bps.northRightShoes.sprite = shoes.backShoes;
        bps.northChest.sprite = bodyType.frontChest;
        bps.northShirt.sprite = shirt.backShirt;
        bps.northLeftArm.sprite = bodyType.arm;
        bps.northLeftSleeve.sprite = shirt.frontSleeve;
        bps.northRightArm.sprite = bodyType.arm;
        bps.northRightSleeve.sprite = shirt.frontSleeve;

        bps.eastHead.sprite = bodyType.sideHead;
        bps.eastHair.sprite = hair.sideHair;
        bps.eastEye.sprite = eyes.sideEye;
        bps.eastEyebrow.sprite = eyebrows.eyebrow;
        bps.eastMouth.sprite = mouth.sideMouth;
        bps.eastLeftLeg.sprite = bodyType.leg;
        bps.eastLeftPants.sprite = pants.pants;
        bps.eastLeftShoes.sprite = shoes.sideShoes;
        bps.eastRightLeg.sprite = bodyType.leg;
        bps.eastRightPants.sprite = pants.pants;
        bps.eastRightShoes.sprite = shoes.sideShoes;
        bps.eastChest.sprite = bodyType.sideChest;
        bps.eastShirt.sprite = shirt.sideShirt;
        bps.eastLeftArm.sprite = bodyType.arm;
        bps.eastLeftSleeve.sprite = shirt.sideSleeve;
        bps.eastRightArm.sprite = bodyType.arm;
        bps.eastRightSleeve.sprite = shirt.sideSleeve;

        bps.westHead.sprite = bodyType.sideHead;
        bps.westHair.sprite = hair.sideHair;
        bps.westEye.sprite = eyes.sideEye;
        bps.westEyebrow.sprite = eyebrows.eyebrow;
        bps.westMouth.sprite = mouth.sideMouth;
        bps.westLeftLeg.sprite = bodyType.leg;
        bps.westLeftPants.sprite = pants.pants;
        bps.westLeftShoes.sprite = shoes.sideShoes;
        bps.westRightLeg.sprite = bodyType.leg;
        bps.westRightPants.sprite = pants.pants;
        bps.westRightShoes.sprite = shoes.sideShoes;
        bps.westChest.sprite = bodyType.sideChest;
        bps.westShirt.sprite = shirt.sideShirt;
        bps.westLeftArm.sprite = bodyType.arm;
        bps.westLeftSleeve.sprite = shirt.sideSleeve;
        bps.westRightArm.sprite = bodyType.arm;
        bps.westRightSleeve.sprite = shirt.sideSleeve;
    }

    private void loadFishRecords()
    {
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/FishRecords.json"));

        for (int i = 0; i < itemData.Count; i++) // for each item on Json
        {
            GameManager.instance.saveItemData.savedFishRecord.Add(new FishRecord(itemData[i]["baseId"].ToString(), (int)itemData[i]["totalCaught"], (double)itemData[i]["smallestCaught"], (double)itemData[i]["biggestCaught"], (int)itemData[i]["highestStar"]));
        }
    }
}
