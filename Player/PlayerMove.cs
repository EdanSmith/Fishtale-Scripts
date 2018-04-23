using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour
{

    public float moveSpeed;
    public Animator animator;
    public int playerDirection;
    public BodyPartsSprite bodyPartsSprite;
    private Rigidbody2D myRigidbody;
    private bool movementEnabled = true;
    //private CharCustomManager ccm;

    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        GameManager.instance.playerMovement = this;
        //ccm = CharCustomManager.instance;
        playerDirection = 0;
        UIGameManager.instance.mainCameraLocation = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.hook.gameObject.activeSelf || GameManager.instance.hookMarker.gameObject.activeSelf || UIGameManager.instance.obtainedItemWindow.gameObject.activeSelf)
        {
            movementEnabled = false;
            myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y);
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0f);
            animator.SetBool("PlayerMoving", false);
        }
        else
            movementEnabled = true;

        if (movementEnabled == true)
        {
            if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                //transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
                myRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, myRigidbody.velocity.y);
            }
            if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
            {
                //transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);
            }

            if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
            {
                myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y);
            }

            if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0f);
            }
            if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
            {
                animator.SetBool("PlayerMoving", false);
            }
            else
            {
                animator.SetBool("PlayerMoving", true);
            }

            Vector3 playerPixelPos = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 mousePixelPos = Input.mousePosition;
            Vector2 v = mousePixelPos - playerPixelPos;

            //use atan2 to get the angle; Atan2 returns radians
            float angleRadians = Mathf.Atan2(v.y, v.x);

            //convert to degrees
            float degreePos = angleRadians * Mathf.Rad2Deg;

            //angleDegrees will be in the range (-180,180].
            //I like normalizing to [0,360) myself, but this is optional..
            if (degreePos < 0)
                degreePos += 360;

            if (Input.GetAxisRaw("Vertical") > 0.5f)
            {
                animator.SetFloat("DirectionX", 0);
                animator.SetFloat("DirectionY", 1);
                playerDirection = (int)Direction.North;
            }
            if (Input.GetAxisRaw("Vertical") < -0.5f)
            {
                animator.SetFloat("DirectionX", 0);
                animator.SetFloat("DirectionY", -1);
                playerDirection = (int)Direction.South;
            }
            if (Input.GetAxisRaw("Horizontal") > 0.5f)
            {
                animator.SetFloat("DirectionX", 1);
                animator.SetFloat("DirectionY", 0);
                playerDirection = (int)Direction.East;
            }
            if (Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                animator.SetFloat("DirectionX", -1);
                animator.SetFloat("DirectionY", 0);
                playerDirection = (int)Direction.West;
            }
            if (EventSystem.current.IsPointerOverGameObject() != UIGameManager.instance.mainCanvas.gameObject) // if mouse is not over any UI object
            {
                if (Input.GetMouseButtonDown(0)) //responsible for changing sprite direciton based on degree relative to mouse pos from player pos
                {
                    updateDirectionOnClick();

                }
            }
            updateCharacterDirection(playerDirection);
        }
    }

    private void updateCharacterDirection(int currentDirection)
    {
        // 0 = south, 1 = west, 2 = north, 3 = east
        if (currentDirection == 0) // South
        {
            bodyPartsSprite.north.SetActive(false);
            bodyPartsSprite.south.SetActive(true); // True
            bodyPartsSprite.east.SetActive(false);
            bodyPartsSprite.west.SetActive(false);
        }
        else if (currentDirection == 1) // West
        {
            bodyPartsSprite.north.SetActive(false);
            bodyPartsSprite.south.SetActive(false);
            bodyPartsSprite.east.SetActive(false);
            bodyPartsSprite.west.SetActive(true); // True
        }
        else if (currentDirection == 2) // North
        {
            bodyPartsSprite.north.SetActive(true); // True
            bodyPartsSprite.south.SetActive(false);
            bodyPartsSprite.east.SetActive(false);
            bodyPartsSprite.west.SetActive(false);
        }
        else if (currentDirection == 3) // East
        {
            bodyPartsSprite.north.SetActive(false);
            bodyPartsSprite.south.SetActive(false);
            bodyPartsSprite.east.SetActive(true); // True
            bodyPartsSprite.west.SetActive(false);
        }
    }

    public void updateDirectionOnClick()
    {
        Vector3 playerPixelPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 mousePixelPos = Input.mousePosition;
        Vector2 v = mousePixelPos - playerPixelPos;

        //use atan2 to get the angle; Atan2 returns radians
        float angleRadians = Mathf.Atan2(v.y, v.x);

        //convert to degrees
        float degreePos = angleRadians * Mathf.Rad2Deg;

        if (degreePos < 0)
            degreePos += 360;

        if (degreePos >= 45f && degreePos < 135f)
        {
            animator.SetFloat("DirectionX", 0);
            animator.SetFloat("DirectionY", 1);
            playerDirection = (int)Direction.North;
        }

        if (degreePos >= 225f && degreePos < 315f)
        {
            animator.SetFloat("DirectionX", 0);
            animator.SetFloat("DirectionY", -1);
            playerDirection = (int)Direction.South;
        }
        if (degreePos >= 315f || degreePos < 45)
        {
            animator.SetFloat("DirectionX", 1);
            animator.SetFloat("DirectionY", 0);
            playerDirection = (int)Direction.East;
        }

        if (degreePos >= 135f && degreePos < 225f)
        {
            animator.SetFloat("DirectionX", -1);
            animator.SetFloat("DirectionY", 0);
            playerDirection = (int)Direction.West;
        }

        updateCharacterDirection(playerDirection);

    }
}