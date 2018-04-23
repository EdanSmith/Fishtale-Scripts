using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragonfly : MonoBehaviour
{

    //================ RANDOM PATTERN =====================<
    public float moveForce;
    public float maxSpeed;
    public float timeBetweenMove;
    public float timeToMove;
    public float decelerateSpeed;
    private float timeBetweenMoveCounter;
    private float timeToMoveCounter;
    private bool moving;
    private float originalMoveForce;
    private float originalMaxSpeed;

    //================ OVERALL ===========================<
    private Vector3 moveDirection;
    private Rigidbody2D myRigidbody;
    private float currentDrag;
    public Quaternion targetRotation;


    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        currentDrag = 0;
        originalMoveForce = moveForce;
        originalMaxSpeed = maxSpeed;
        InvokeRepeating("speedChange", 4f, 4f);
    }

    void Update()
    {
        randomPattern();
    }

    void FixedUpdate()
    {
        if (moving) //Random Pattern Stuff
        {
            myRigidbody.velocity = Vector3.ClampMagnitude(myRigidbody.velocity, maxSpeed);
            myRigidbody.AddForce(moveDirection.normalized * moveForce);
        }
    }

    public void randomPattern()
    {
        if (moving)
        {
            myRigidbody.drag = currentDrag;
            timeToMoveCounter -= Time.deltaTime;

            if (timeToMoveCounter < 0f)
            {
                moving = false;
                timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
            }

            Vector2 direction = (Vector2)moveDirection;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.AngleAxis(angle, new Vector3(0, 0, 1));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 500f * Time.deltaTime); // Rotates slowly the fish to the moving direction

        }
        else
        {
            timeBetweenMoveCounter -= Time.deltaTime;
            myRigidbody.drag = decelerateSpeed + currentDrag;

            if (timeBetweenMoveCounter < 0f)
            {
                moving = true;
                timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeBetweenMove * 1.25f);
                moveDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0.0f); // Sets to which direction the fish should move to

            }

        }
    }

    private void speedChange()
    {
        float randomValue = Random.Range(0, 100);

        if (randomValue > 25)
        {
            moveForce = originalMoveForce;
            maxSpeed = originalMaxSpeed;
        }else if (randomValue <= 25 && randomValue > 10)
        {
            moveForce = originalMoveForce * 1.5f;
            maxSpeed = originalMaxSpeed * 1.5f;
        }else
        {
            moveForce = originalMoveForce * 2;
            maxSpeed = originalMaxSpeed * 2;
        }
    }
}
