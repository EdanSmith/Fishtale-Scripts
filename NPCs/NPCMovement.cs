using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NPCMovement : MonoBehaviour {

    public float moveSpeed;
    public int playerDirection;
    public BodyPartsSprite bps;

    public bool movingNorth;
    public bool movingSouth;
    public bool movingEast;
    public bool movingWest;

    private Animator animator;
    private Rigidbody2D myRigidbody;
    private bool movementEnabled = true;

    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerDirection = 0;
        animator.speed = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        animator.speed = 0.8f;
        if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            movingNorth = !movingNorth;
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            movingSouth = !movingSouth;
        }
        if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            movingEast = !movingEast;
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            movingWest = !movingWest;
        }
        if (1 == 2)
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

            if(movingEast)
                myRigidbody.velocity = new Vector2(1 * moveSpeed, myRigidbody.velocity.y);
            else if(movingWest)
                myRigidbody.velocity = new Vector2(-1 * moveSpeed, myRigidbody.velocity.y);

            if(!movingEast && !movingWest)
                myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y);

            if (movingNorth)
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 1 * moveSpeed);
            else if (movingSouth)
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, -1 * moveSpeed);

            if(!movingNorth && !movingSouth)
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0f);

            //if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
            //{
            //    //transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
            //    myRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, myRigidbody.velocity.y);
            //}
            //if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
            //{
            //    //transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
            //    myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);
            //}

            //if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
            //{
            //    myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y);
            //}

            //if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
            //{
            //    myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0f);
            //}
            if (!movingNorth && !movingSouth && !movingEast && !movingWest)
            {
                animator.SetBool("PlayerMoving", false);
            }
            else
            {
                animator.SetBool("PlayerMoving", true);
            }

            if (movingSouth)
            {
                animator.SetFloat("DirectionX", 0);
                animator.SetFloat("DirectionY", -1);
                playerDirection = (int)Direction.South;
            }

            if (movingNorth)
            {
                animator.SetFloat("DirectionX", 0);
                animator.SetFloat("DirectionY", 1);
                playerDirection = (int)Direction.North;
            }

            if (movingWest)
            {
                animator.SetFloat("DirectionX", -1);
                animator.SetFloat("DirectionY", 0);
                playerDirection = (int)Direction.West;
            }

            if (movingEast)
            {
                animator.SetFloat("DirectionX", 1);
                animator.SetFloat("DirectionY", 0);
                playerDirection = (int)Direction.East;
            }

            updateCharacterDirection(playerDirection);
        }
    }

    private void updateCharacterDirection(int currentDirection)
    {
        // 0 = south, 1 = west, 2 = north, 3 = east
        if (currentDirection == 0) // South
        {
            bps.north.SetActive(false);
            bps.south.SetActive(true); // True
            bps.east.SetActive(false);
            bps.west.SetActive(false);
        }
        else if (currentDirection == 1) // West
        {
            bps.north.SetActive(false);
            bps.south.SetActive(false);
            bps.east.SetActive(false);
            bps.west.SetActive(true); // True
        }
        else if (currentDirection == 2) // North
        {
            bps.north.SetActive(true); // True
            bps.south.SetActive(false);
            bps.east.SetActive(false);
            bps.west.SetActive(false);
        }
        else if (currentDirection == 3) // East
        {
            bps.north.SetActive(false);
            bps.south.SetActive(false);
            bps.east.SetActive(true); // True
            bps.west.SetActive(false);
        }
    }

}
