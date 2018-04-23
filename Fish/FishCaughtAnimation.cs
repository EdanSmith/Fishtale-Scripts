using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCaughtAnimation : MonoBehaviour
{

    private FishData fishData;
    private LineRenderer lineRenderer;
    private Vector2 rodTip;
    private bool onTrigger;
    private bool onTriggerEnter;
    private bool swingAnimation;
    private bool swingLeft;
    private FishMovement fish;
    private Transform fishAnimation;
    private Quaternion fishRotation;
    private Quaternion fishAnimationRotation;
    private bool caught;
    private float pauseCounter;
    public GameObject drippingParticle;

    void Start()
    {
        fishData = GameManager.instance.GetFishDataById(GameManager.instance.currentSpawnedFish.id);
        lineRenderer = GameManager.instance.hook.GetComponent<LineRenderer>();
        fish = GameManager.instance.fish;
        fishAnimation = GameManager.instance.fish.animator.GetComponent<Transform>();
        onTrigger = false;
        onTriggerEnter = false;
        swingAnimation = false;
        caught = false;
        pauseCounter = 0.5f;
    }

    void Update()
    {
        rodTip = GameManager.instance.playerMovement.bodyPartsSprite.getRodTipDirectionPos(GameManager.instance.playerMovement.playerDirection);
        if (GameManager.instance.fishCaught)
        {
            lineRenderer.SetPosition(0, fishAnimation.position);
            GameManager.instance.hook.transform.position = fishAnimation.position;
            if (!caught)
            {
                SoundManager.instance.PlaySound2D("Fish Jump Out Water", GameManager.instance.hook.transform.position);
                Instantiate(Resources.Load("Prefabs/Particles/FishJumpingOutWater"), GameManager.instance.hook.transform.position, Quaternion.identity);
            }
            caught = true;
            if (pauseCounter > 0)
            {
                pauseCounter -= Time.deltaTime;
                fish.animator.enabled = false;
                fish.gameObject.transform.localScale = new Vector2(0.5f, 0.5f);
                fish.animator.GetComponent<SpriteRenderer>().sprite = fishData.fishSprite[1]; // 1 = the 2nd sprite of his sprite list, which is the one that the fish is 100% straight
                fish.animator.GetComponent<SpriteRenderer>().sortingOrder = 30;

                float angle = getAngleBetweenTwoPoints((Vector2)transform.position, rodTip);
                fishRotation = Quaternion.AngleAxis(angle, new Vector3(0, 0, 1));
                transform.rotation = fishRotation;
            }
            else
            {
                transform.position = Vector2.Lerp(transform.position, new Vector2(rodTip.x, rodTip.y - 0.5f), 5f * Time.deltaTime);

                if (!onTrigger)
                {
                    float angle = getAngleBetweenTwoPoints((Vector2)transform.position, rodTip);
                    fishRotation = Quaternion.AngleAxis(angle, new Vector3(0, 0, 1));
                    transform.rotation = fishRotation;//Quaternion.RotateTowards(transform.rotation, fishRotation, 1000f * Time.deltaTime); // Rotates slowly the fish to the moving direction

                    fishAnimation.rotation = new Quaternion(0, 0, 0, 0);//Quaternion.RotateTowards(transform.rotation, fishAnimationRotation, 1000f * Time.deltaTime);
                }
                else if (!swingAnimation)
                {
                    fishRotation = Quaternion.AngleAxis(90, new Vector3(0, 0, 1));
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, fishRotation, 400 * Time.deltaTime);
                    if (transform.rotation == fishRotation)
                        swingAnimation = true;
                }
                else
                {
                    if (swingLeft)
                    {
                        fishRotation = Quaternion.AngleAxis(100, new Vector3(0, 0, 1));
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, fishRotation, 30 * Time.deltaTime);
                        if (fishRotation == transform.rotation)
                            swingLeft = false;
                    }
                    else
                    {
                        fishRotation = Quaternion.AngleAxis(80, new Vector3(0, 0, 1));
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, fishRotation, 30 * Time.deltaTime);
                        if (fishRotation == transform.rotation)
                            swingLeft = true;
                    }
                    drippingParticle.transform.position = new Vector2(fishAnimation.position.x, fishAnimation.position.y - 0.2f);
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (GameManager.instance.fishCaught && collider.name == "Rod Tip" && !onTriggerEnter) // !onTriggerEnter to guarantee it will not enter twice
        {
            onTrigger = true;
            onTriggerEnter = true;
            drippingParticle = (GameObject)Instantiate(Resources.Load("Prefabs/Particles/Fish Dripping"));
            UIGameManager.instance.showObtainedItemWindow(ItemManager.instance.getItemFishByBaseId(GameManager.instance.currentSpawnedFish.id)); // shows the obtained item window
            UIGameManager.instance.obtainedItemWindow.newRecord = ItemManager.instance.saveFishRecordToDatabase(ItemManager.instance.obtainedFish); // return if it's a new fish size record or not
            //GameManager.instance.fishCaught = false;
        }
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (GameManager.instance.fishCaught && !onTrigger && collider.name == "Rod Tip")
        {
            OnTriggerEnter2D(collider);
            onTrigger = true;
        }
    }

    private float getAngleBetweenTwoPoints(Vector2 vec1, Vector2 vec2)
    {
        Vector2 diference = vec2 - vec1;
        float sign = (vec2.y < vec1.y) ? -1.0f : 1.0f;
        return Vector2.Angle(Vector2.right, diference) * sign;
    }


}
