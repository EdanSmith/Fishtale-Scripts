using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Aim : MonoBehaviour
{

    private LineScript hook;
    private Player player;
    private Slider lineLengthBar;
    private bool aimOverFish;
    private float fillBarSpeed;
    private float unfillBarSpeed;
    private float reelInCounter;
    private float reelInCounterHandler;
    public float reelInTimer;
    private float reelOutCounter;
    private float reelOutCounterHandler;
    public float reelOutTimer;

    private bool reeling;

    public float fillBarSpeedModifier = 1f; //depends on the rod
    public float unfillBarSpeedModifier = 1f; //depends on the fish

    void Start()
    {
        GameManager.instance.aim = this;
        reelInTimer = 0.4f;
        reelOutTimer = 0.6f;
        reelInCounterHandler = reelInTimer;
        reelInCounter = reelInCounterHandler;
        reelOutCounterHandler = reelOutTimer;
        reelOutCounter = reelOutCounterHandler;
        reeling = true;
    }

    void Update()
    {
        if (aimOverFish == true && Input.GetButton("Fire1"))// If aim is on the fish + the person is pressing the mouse button
        {
            lineLengthBar.value = Mathf.MoveTowards(lineLengthBar.value, lineLengthBar.maxValue, fillBarSpeed * Time.deltaTime);

            reelInCounter -= Time.deltaTime;
            if (!SoundManager.instance.player.isPlaying && (reelInCounter <= 0 || !reeling))
            {
                SoundManager.instance.playSoundOnPlayer(SoundManager.instance.GetClipByName("reelIn"));
                reelInCounter = reelInCounterHandler;
            }
            reeling = true;
        }else
        {
            reelInCounterHandler = reelInTimer;
            reelInCounter = reelInCounterHandler;
        }
        if (aimOverFish == false)// If aim just isn't on the fish
        {
            lineLengthBar.value = Mathf.MoveTowards(lineLengthBar.value, lineLengthBar.minValue, unfillBarSpeed * Time.deltaTime);
            if (Input.GetButton("Fire1"))// If aim isn't on the fish + the person is pressing the mouse button
            {
                lineLengthBar.value = Mathf.MoveTowards(lineLengthBar.value, lineLengthBar.minValue, unfillBarSpeed * Time.deltaTime);
            }
            reelOutCounter -= Time.deltaTime;
            if (!SoundManager.instance.player.isPlaying && (reelOutCounter <= 0 || reeling))
            {
                SoundManager.instance.playSoundOnPlayer(SoundManager.instance.GetClipByName("reelIn"), 0.75f);
                //if (reelOutCounterHandler > 0.1f)
                    //reelOutCounterHandler = (reelOutCounterHandler / 100) * 75; //75%
                reelOutCounter = reelOutCounterHandler;
            }
            reeling = false;
        }
        else
        {
            reelOutCounterHandler = reelOutTimer;
            reelOutCounter = reelOutCounterHandler;
        }
            

        if (lineLengthBar.value >= lineLengthBar.maxValue)// If the bar reaches the max
        {
            //Destroy(GameManager.instance.fish.gameObject);
            GameManager.instance.fish.enabled = false;
            GameManager.instance.fish.polygonCollider2D.isTrigger = true;
            GameManager.instance.fish.GetComponent<Rigidbody2D>().drag = 10;
            GameManager.instance.hc.startHookCooldownTimer();
            UIGameManager.instance.lineLengthBar.gameObject.SetActive(false);
            GameManager.instance.hook.GetComponent<CircleCollider2D>().enabled = false;
            gameObject.SetActive(false);
            GameManager.instance.fishCaught = true;
            UIGameManager.instance.skillPanel.gameObject.SetActive(false);

            //GameManager.instance.hook.gameObject.SetActive(false);
            //UIGameManager.instance.showObtainedItemWindow(ItemManager.instance.getItemFishByBaseId(GameManager.instance.currentSpawnedFish.id)); // shows the obtained item window
            //UIGameManager.instance.obtainedItemWindow.newRecord = ItemManager.instance.saveFishRecordToDatabase(ItemManager.instance.obtainedFish); // return if it's a new fish size record or not
            //GameManager.instance.currentSpawnedFish = null;
        }
    }

    public void refresh()
    {
        hook = GameManager.instance.hook;
        player = GameManager.instance.player;
        lineLengthBar = UIGameManager.instance.lineLengthBar.GetComponent<Slider>();
        lineLengthBar.value = lineLengthBar.maxValue / 2;
        FishData fishData = GameManager.instance.GetFishDataById(GameManager.instance.currentSpawnedFish.id);
        UIGameManager.instance.lineLengthBar.gameObject.SetActive(true);
        fillBarSpeed = ((lineLengthBar.maxValue / 10) * fillBarSpeedModifier) * fishData.fillBarModifier;
        unfillBarSpeed = ((lineLengthBar.maxValue / 10) * unfillBarSpeedModifier) * fishData.unfillBarModifier;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Fish Animation")
        {
            aimOverFish = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Fish Animation")
        {
            aimOverFish = false;
        }
    }
}