using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIItemFish : MonoBehaviour, IPointerClickHandler
{

    public SpriteRenderer sprite;

    public ItemFish itemFish;

    public void Init(ItemFish itemFish)
    {
        //sprite.sprite = itemFish.fishSprite; //get the fish image
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        UIGameManager.instance.selectedFish = this;
        UIGameManager.instance.showItemSpecificationWindow();

        //print(ItemManager.instance.GetItemDataById(itemFish.baseId).weatherType);
        //ItemManager.instance.deleteItemFish(itemFish.id);
        //Destroy(gameObject);
    }
}