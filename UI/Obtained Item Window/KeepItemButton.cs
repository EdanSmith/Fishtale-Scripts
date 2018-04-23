using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepItemButton : MonoBehaviour {

    public void keepItem() // Obtained Item Window
    {
        UIGameManager.instance.addItemFishToPlayerInventory(ItemManager.instance.obtainedFish);
        ItemManager.instance.saveFishToDatabase(ItemManager.instance.obtainedFish);
        transform.parent.gameObject.SetActive(false);

        GameManager.instance.hook.gameObject.SetActive(false);
        Destroy(GameManager.instance.fish.GetComponent<FishCaughtAnimation>().drippingParticle.gameObject);
        Destroy(GameManager.instance.fish.gameObject);
        GameManager.instance.currentSpawnedFish = null;
        GameManager.instance.fishCaught = false;
    }

    public void closeSpecificationWindow() // Item Specification Window
    {
        UIGameManager.instance.selectedFish = null;
        UIGameManager.instance.closeItemSpecificationWindow();
    }
}
