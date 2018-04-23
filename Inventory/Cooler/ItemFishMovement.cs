using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFishMovement : MonoBehaviour
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

    //================ CIRCLE PATTERN =====================<
    public float angle;
    public float radius;
    public float circleSpeed;

    //================ SQUARE PATTERN =====================<
    public float acceleration;//How fast will object reach a maximum speed
    public float deceleration;//How fast will object reach a speed of 0
    public Vector3[] waypoints;
    public float currentPattern;
    public float speed;        // speed in units/second
    private int targetNum;
    private float totalDistance;
    private float currentDistance;
    private bool squarePatternReady;

    private bool waypointAux;
    //================ OVERALL ===========================<
    private Vector3 moveDirection;
    private Rigidbody2D myRigidbody;

    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        //==== Random Pattern =====
        moveForce = 15;     //based on the fish
        maxSpeed = 30;        //based on the fish
        timeBetweenMove = 1f; //based on the fish
        timeToMove = 3f;      //based on the fish
        decelerateSpeed = 3f; //based on the fish
        timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f); //Randomizes a bit of the timer that the fish stops to move again
        timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeBetweenMove * 1.25f);           //Randomizes a bit of the timer that the fish keep moving

        //==== Circle Pattern =====
        angle = 0;
        radius = 2;
        circleSpeed = 5;

        //==== Square Pattern =====
        acceleration = 2.5f;
        deceleration = 5f;
        squarePatternReady = false;
        speed = 2f;

        //==== Overall =====
        currentPattern = 1;
        waypointAux = false;
        InvokeRepeating("changePattern", 4, 4F);
    }

    void Update()
    {

        //randomPattern();

        if (currentPattern > 0)
            randomPattern();
        else if (currentPattern < 0)
            squareGravityPattern();

    }

    void FixedUpdate()
    {
        if (moving) //Random Pattern Stuff
        {
            myRigidbody.velocity = Vector3.ClampMagnitude(myRigidbody.velocity, maxSpeed);
            myRigidbody.AddForce(moveDirection.normalized * moveForce);
        }
    }

    void randomPattern()
    {
        if (moving)
        {
            myRigidbody.drag = 0f;
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
            myRigidbody.drag = decelerateSpeed;

            if (timeBetweenMoveCounter < 0f)
            {
                moving = true;
                timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeBetweenMove * 1.25f);
                moveDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0.0f); // Sets to which direction the fish should move to

            }

        }
    }

    void squareGravityPattern()
    {
        waypoints = new Vector3[4];
        waypoints[0] = new Vector3(-1, 0, 0);
        waypoints[1] = new Vector3(0, 1, 0);
        waypoints[2] = new Vector3(1, 0, 0);
        waypoints[3] = new Vector3(0, -1, 0);
        if (moving)
        {
            myRigidbody.drag = 0f;
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
            waypointAux = false;
        }
        else
        {
            timeBetweenMoveCounter -= Time.deltaTime;
            myRigidbody.drag = decelerateSpeed;

            if (timeBetweenMoveCounter < 0f)
            {
                moving = true;
                timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeBetweenMove * 1.25f);
                moveDirection = waypoints[targetNum]; // Sets to which direction the fish should move to

                if (waypointAux == false)
                {
                    targetNum = (targetNum + 1) % waypoints.Length;
                    waypointAux = true;
                }

            }

        }
    }

    void circlePattern()
    {
        float x, y;

        x = radius * Mathf.Cos(angle);
        y = radius * Mathf.Sin(angle);

        myRigidbody.MovePosition(transform.position + (new Vector3(x, y, transform.position.z) * circleSpeed * Time.deltaTime));
        //transform.Translate((new Vector2(x, y) * circleSpeed) * Time.deltaTime);
        angle += circleSpeed * Time.deltaTime;

        Vector2 direction = ((Vector2)transform.position + (new Vector2(x, y) * circleSpeed * Time.deltaTime) - (Vector2)transform.position);
        float angleAux = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.AngleAxis(angleAux, new Vector3(0, 0, 1));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 500f * Time.deltaTime); // Rotates slowly the fish to the moving direction
    }

    public void squarePattern()
    {
        if (squarePatternReady == false)
        {
            waypoints = new Vector3[4];
            waypoints[0] = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
            waypoints[1] = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            waypoints[2] = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
            waypoints[3] = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);

            squarePatternReady = true;
        }
        // move towards the current target
        Vector3 pos = transform.position;
        //transform.position = Vector3.MoveTowards(pos, waypoints[targetNum], speed * Time.deltaTime);

        myRigidbody.MovePosition(Vector3.MoveTowards(pos, waypoints[targetNum], speed * Time.deltaTime));
        currentDistance = Vector3.Distance(transform.position, waypoints[targetNum]);
        if ((currentDistance > (totalDistance / 100) * 25) && speed < 5f) //maximum speed
        {
            speed += acceleration * Time.deltaTime;
        }
        else if (speed > 2f) //minimum speed
        {
            speed -= deceleration * Time.deltaTime;
        }
        // if we reach it, go on to the next one
        if (transform.position == waypoints[targetNum])
        {
            targetNum = (targetNum + 1) % waypoints.Length;
            totalDistance = Vector3.Distance(transform.position, waypoints[targetNum]);

            waypoints[0] = new Vector3(transform.position.x - 3, transform.position.y, transform.position.z);
            waypoints[1] = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
            waypoints[2] = new Vector3(transform.position.x + 3, transform.position.y, transform.position.z);
            waypoints[3] = new Vector3(transform.position.x, transform.position.y - 3, transform.position.z);

            Vector2 direction = ((Vector2)waypoints[targetNum] - (Vector2)transform.position);
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.AngleAxis(angle, new Vector3(0, 0, 1));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 500f * Time.deltaTime); // Rotates slowly the fish to the moving direction
        }
    }

    void changePattern()
    {
        currentPattern *= -1;
        squarePatternReady = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.name == "TestCollider")
        {
            //currentPattern *= -1;
            Debug.Log("It did hit the TestCollider");
        }
    }
}


//Vector3 diff = moveDirection;// - transform.position;
//diff.Normalize();
//float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
//transform.rotation = Quaternion.Euler(0f, 0f, rot_z); // Turns the fish to the hook direction   ONE OF THE ROTATION SNIPPET (INTERNET)