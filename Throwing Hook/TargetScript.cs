using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{


    private float speed;
    private PlayerMove player;
    private GameObject hook;
    public bool moveTowardsPlayer;
    private bool paralizeTarget;
    private HookMarker hookMarker;
    private Vector2 mousePos;
    private Vector2 newTarget;
    private Vector2 playerPos;
    private float minDistance;
    private float angle;
    public float distance;

    // Use this for initialization
    void Start()
    {
        player = GameManager.instance.playerMovement;
        playerPos = GameManager.instance.playerMovement.transform.position;
        hookMarker = GameManager.instance.hookMarker;
        minDistance = 2f;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newTarget = mousePos - playerPos;
        transform.position = playerPos + ((newTarget).normalized * minDistance);
        speed = 5f;
        speed *= Time.deltaTime;
        paralizeTarget = false;
    }

    // Update is called once per frame
    void Update()
    {
        player = GameManager.instance.playerMovement;
        playerPos = GameManager.instance.playerMovement.transform.position;
        hookMarker = GameManager.instance.hookMarker;
        if (Input.GetKey(KeyCode.L))
        {

            //enableCurTarget(false);
            paralizeTarget = true;
        }

        // below --> GameManager.instance.throwHookMarker.maxDistance - distance < 0.1f = it's because if you move the mouse too fast, it never reach the end point, and with that it gives a small range
        if ((transform.position == hookMarker.transform.position || GameManager.instance.throwHookMarker.maxDistance - distance < 0.1f || moveTowardsPlayer == true) && paralizeTarget == false) // move towards the player
        {
            moveTowardsPlayer = true;
            transform.position = Vector2.MoveTowards(transform.position, playerPos +  ((mousePos - playerPos).normalized * minDistance), speed);
        }

        //below --> Similar behavior to the "if" above.
        if (((Vector2)transform.position == playerPos + ((newTarget).normalized * minDistance) || distance - minDistance < 0.1f || moveTowardsPlayer == false) && paralizeTarget == false) // move towards where the player clicked
        {
            moveTowardsPlayer = false;
            transform.position = Vector2.MoveTowards(transform.position, hookMarker.transform.position, speed);
        }

        Vector2 direction = (playerPos - (Vector2)hookMarker.transform.position).normalized;
        distance = Vector2.Distance(playerPos, transform.position);
        transform.position = ((Vector3)playerPos + (Vector3)direction * -(distance));

        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.AngleAxis(angle, new Vector3(0, 0, 1));
        transform.rotation = targetRotation; // Rotates the target to the moving direction
    }

    private void enableCurTarget(bool targetEnable)
    {
        SpriteRenderer targetSprite = GetComponent<SpriteRenderer>();
        targetSprite.enabled = targetEnable;
    }
    public void setParalizeTarget(bool paralize)
    {
        paralizeTarget = paralize;
    }

    public void refresh()
    {
        Start();
    }
}
