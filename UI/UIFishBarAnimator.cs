using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFishBarAnimator : MonoBehaviour
{

    private Image imageComponent;
    private List<Sprite> fishSprite;
    private FishData fishData;
    private int counter;
    private float animationDelay;
    private bool returnToStart;
    private float oldSliderValue;
    private RectTransform rt;
    public Slider slider;
    public Image handle;

    // Use this for initialization
    void Start()
    {
        imageComponent = GetComponent<Image>();

        fishData = GameManager.instance.GetFishDataById(GameManager.instance.currentSpawnedFish.id);
        fishSprite = fishData.fishSprite;
        rt = GetComponent<RectTransform>();
        counter = 0;
        returnToStart = false;
        animationDelay = 0.25f;
        oldSliderValue = 0;
    }

    public void refresh()
    {
        Start();
    }

    // Update is called once per frame
    void Update()
    {
        animationDelay += Time.deltaTime;
        if (animationDelay >= 0.25f)
        {
            changeSprite();
        }
        if (oldSliderValue > slider.value)
        {
            rt.localScale = new Vector3(-1, 1, 1);
            handle.color = new Color32(255, 0, 0, 255);
        }
        else
        {
            rt.localScale = new Vector3(1, 1, 1);
            handle.color = new Color32(0, 255, 0, 255);
        }
        oldSliderValue = slider.value;
    }

    private void changeSprite()
    {
        //if (counter == 0) {
        //    counter++;
        //    returnToStart = false;
        //}
        //else if (counter == 2) {
        //    counter--;
        //    returnToStart = true;
        //}else if (counter == 1)
        //{
        //    if (!returnToStart)
        //        counter++;
        //    else
        //        counter--;
        //}
        if (counter > 5000)
            counter = 0;

        animationDelay = 0;
        imageComponent.sprite = fishSprite[(int)Mathf.PingPong(counter, 2)];
        counter++;
    }
}
