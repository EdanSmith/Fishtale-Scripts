using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFishImageAnimator : MonoBehaviour
{

    Image imageComponent;
    UIItemFish itemFishScript;
    private List<Sprite> fishSprite;
    private float animationDelay;
    private int counter;
    // If necessary, create an array instead of a lot of variables for the animations

    void Start()
    {
        itemFishScript = GetComponent<UIItemFish>();
        fishSprite = GameManager.instance.GetFishDataById(itemFishScript.itemFish.fishItemData.id).fishSprite;

        imageComponent = GetComponent<Image>(); //Our image component is the one attached to this gameObject.
        InvokeRepeating("changeSprite", 0, 0.4F);

        counter = 0;
        animationDelay = 0.4f;
    }

    //void Update()
    //{
    //    animationDelay += Time.deltaTime;
    //    if (animationDelay >= 0.25f)
    //    {
    //        changeSprite();
    //    }
    //}

    void changeSprite()
    {
        if (counter > 5000)
            counter = 0;

        animationDelay = 0;
        imageComponent.sprite = fishSprite[(int)Mathf.PingPong(counter, 2)];
        counter++;
    }
}
