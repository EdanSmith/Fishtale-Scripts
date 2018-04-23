using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ThrowHookMarker : MonoBehaviour
{
    private Vector2 destiny;
    private bool markerActive = false;
    private float speed = 5f;
    private float maxThrowRange = 1.5f;
    private Animator animator;
    private float seconds;
    public float maxDistance;

    // Use this for initialization
    void Start()
    {
        speed *= Time.deltaTime;
        animator = GetComponent<Animator>();
        seconds = 0;
        maxDistance = 4f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.hookMarker.gameObject.activeSelf)
        {
            if (!GameManager.instance.hook.gameObject.activeSelf)
            {
                if (Input.GetButton("Fire1")) // If left mouse button is down
                {
                    //if (Vector3.Distance(transform.position, UIGameManager.instance.mainCamera.ScreenToWorldPoint(Input.mousePosition)) - 10f < maxThrowRange) // -10 so it starts at 0 --- if in throw range
                    if (EventSystem.current.IsPointerOverGameObject() != UIGameManager.instance.mainCanvas.gameObject && !UIGameManager.instance.obtainedItemWindow.gameObject.activeSelf) // if mouse is not over any UI object
                    {

                        if (!GameManager.instance.hc.hookOnCooldown) // if the hook isn't on cooldown
                        {
                            destiny = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                            GameManager.instance.hookMarker.gameObject.transform.position = (Vector2)transform.position + ((destiny - (Vector2)transform.position).normalized * maxDistance); // Defines the fixed max range for throwing the hook
                            GameManager.instance.target.gameObject.transform.position = GameManager.instance.playerMovement.bodyPartsSprite.getRodTipDirectionPos(GameManager.instance.playerMovement.playerDirection);
                            GameManager.instance.target.refresh();
                            GameManager.instance.hookMarker.gameObject.SetActive(true);
                            GameManager.instance.target.gameObject.SetActive(true);

                            GameManager.instance.hc.setHookOnCooldown();
                            animator.SetBool("CancelCastAnimation", false);
                            animator.SetBool("PlayerPreCasting", true);
                        }
                    }
                }
            }
        }
        else
        {
            if (Input.GetButton("Fire1") && !animator.GetBool("PlayerCasting"))
            {
                GameManager.instance.hookMarker.gameObject.transform.position = (Vector2)transform.position + (((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position).normalized * maxDistance);
                GameManager.instance.playerMovement.updateDirectionOnClick();
            }
            if (!Input.GetButton("Fire1") || animator.GetBool("PlayerCasting")) // if the left mouse button is not press
            {
                if (markerActive == false)
                {
                    animator.SetBool("PlayerCasting", true);
                    animator.SetBool("PlayerPreCasting", false);

                    seconds += Time.deltaTime;

                    GameManager.instance.target.setParalizeTarget(true);

                    if (seconds >= 0.3)
                    {
                        GameManager.instance.hook.gameObject.transform.position = GameManager.instance.playerMovement.bodyPartsSprite.getRodTipDirectionPos(GameManager.instance.playerMovement.playerDirection);
                        GameManager.instance.hook.refresh();
                        GameManager.instance.hook.gameObject.SetActive(true);
                        markerActive = true;
                        seconds = 0;
                    }
                }
                else
                {
                    if (GameManager.instance.hook.gameObject.activeSelf && GameManager.instance.hook.gameObject.transform.position != GameManager.instance.target.gameObject.transform.position) // if the hook exists but isn't on the end position yet
                    {
                        GameManager.instance.hook.gameObject.transform.position = Vector2.MoveTowards(GameManager.instance.hook.gameObject.transform.position, GameManager.instance.target.gameObject.transform.position, speed);
                    }
                    else
                    {
                        GameManager.instance.hook.GetComponent<CircleCollider2D>().enabled = true;
                        GameManager.instance.target.gameObject.SetActive(false);
                        GameManager.instance.hookMarker.gameObject.SetActive(false);
                        markerActive = false;
                        animator.SetBool("HookOnWater", true);
                        animator.SetBool("PlayerCasting", false);
                    }
                }

            }
            else if (GameManager.instance.hookMarker.gameObject.activeSelf && GameManager.instance.hook.gameObject.activeSelf) // if the hookMark and the hook exists
            {
                GameManager.instance.hook.gameObject.transform.position = Vector2.MoveTowards(GameManager.instance.hook.gameObject.transform.position, GameManager.instance.target.gameObject.transform.position, speed);
                if (GameManager.instance.hook.gameObject.transform.position == GameManager.instance.target.gameObject.transform.position) // if the hook reaches the end position
                {
                    GameManager.instance.hook.GetComponent<CircleCollider2D>().enabled = true;
                    GameManager.instance.target.gameObject.SetActive(false);
                    GameManager.instance.hookMarker.gameObject.SetActive(false);
                    animator.SetBool("HookOnWater", true);
                    animator.SetBool("PlayerCasting", false);
                }
            }

        }

        if (Input.GetButton("Fire2"))
        {
            if (GameManager.instance.hook.gameObject.activeSelf && GameManager.instance.hook.GetComponent<CircleCollider2D>().enabled == true && GameManager.instance.currentSpawnedFish == null)
            {
                markerActive = false;
                GameManager.instance.hook.GetComponent<CircleCollider2D>().enabled = false;
                GameManager.instance.hook.gameObject.SetActive(false);
                GameManager.instance.hc.startHookCooldownTimer();
                if (GameManager.instance.fish != null)
                {
                    Destroy(GameManager.instance.fish.gameObject);
                }
                if (GameManager.instance.aim.gameObject.activeSelf)
                {
                    GameManager.instance.aim.gameObject.SetActive(false);
                }
                animator.SetBool("PlayerPreCasting", false);
                animator.SetBool("PlayerCasting", false);
                animator.SetBool("HookOnWater", false);
                animator.SetBool("CancelCastAnimation", true);
                UIGameManager.instance.mainCameraLocation = GameManager.instance.playerMovement.transform;
            }
        }

        if (GameManager.instance.currentSpawnedFish != null)
        {
            animator.SetBool("HookOnFish", true);
            animator.SetBool("HookOnWater", false);
        }
        else
        {
            animator.SetBool("HookOnFish", false);
        }


    }

    private void OnTriggerEnter2D(Collider2D other) // We can use also OnCollisionEnter2D if we decide to treat it with "Is Trigger" disabled
    {
    }

    private void enableMarkerSprite(bool spriteEnable)
    {
        SpriteRenderer markerSprite = GetComponent<SpriteRenderer>();
        markerSprite.enabled = spriteEnable;
    }

    public float getMaxThrowRange()
    {
        return maxThrowRange;
    }
}
