using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscartItemButton : MonoBehaviour {

    public void closeObtainedItemWindow() //Obtained Item Window
    {
        transform.parent.gameObject.SetActive(false);

        GameManager.instance.hook.gameObject.SetActive(false);
        Destroy(GameManager.instance.fish.GetComponent<FishCaughtAnimation>().drippingParticle.gameObject);
        Destroy(GameManager.instance.fish.gameObject);
        GameManager.instance.currentSpawnedFish = null;
        GameManager.instance.fishCaught = false;
    }

    public void discartSelectedItem() //Item Specification Window
    {
        UIItemFish itemFish = UIGameManager.instance.selectedFish;
        ItemManager.instance.deleteItemFish(itemFish.itemFish.id);
        transform.parent.gameObject.SetActive(false);
        Destroy(itemFish.gameObject);
        UIGameManager.instance.selectedFish = null;
    }
}
