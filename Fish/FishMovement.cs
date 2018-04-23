using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class FishMovement : MonoBehaviour
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
    public float speed;        // speed in units/second
    private int targetNum;
    private float totalDistance;
    private float currentDistance;
    private bool squarePatternReady;

    private bool waypointAux;
    //================ OVERALL ===========================<
    private LineScript hook;
    private Vector3 hookPos;
    private Vector3 moveDirection;
    private Player player;
    private LineRenderer lineRenderer;
    private Rigidbody2D myRigidbody;
    private FishData fishData;
    private List<FishPattern> patterns;
    private MethodInfo method;
    private Color32 color;
    public float currentDrag;
    public FishPattern currentPattern;
    public Animator animator;
    public Quaternion targetRotation;
    public PolygonCollider2D polygonCollider2D;

    // Use this for initialization
    void Start()
    {
        UIGameManager.instance.mainCameraLocation = transform;
        hook = GameManager.instance.hook;
        player = GameManager.instance.player;
        GameManager.instance.fish = this;
        myRigidbody = GetComponent<Rigidbody2D>();
        lineRenderer = hook.GetComponent<LineRenderer>();
        if (GameManager.instance.fishDetect.gameObject.activeSelf)
            GameManager.instance.fishDetect.gameObject.SetActive(false);

        fishData = GameManager.instance.GetFishDataById(GameManager.instance.currentSpawnedFish.id);
        patterns = fishData.patterns;

        //==== Random Pattern =====
        moveForce = fishData.moveForce;     //based on the fish
        maxSpeed = fishData.maxSpeed;        //based on the fish
        timeBetweenMove = fishData.timeBetweenMove; //based on the fish
        timeToMove = fishData.timeToMove;      //based on the fish
        decelerateSpeed = fishData.decelerateSpeed; //based on the fish
        timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f); //Randomizes a bit of the timer that the fish stops to move again
        timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeBetweenMove * 1.25f);           //Randomizes a bit of the timer that the fish keep moving

        //==== Circle Pattern =====
        angle = 0;
        radius = fishData.radius;
        circleSpeed = fishData.circleSpeed;

        //==== Square Pattern =====
        acceleration = 2.5f;
        deceleration = 5f;
        squarePatternReady = false;
        speed = 2f;

        //==== Overall =====
        waypointAux = false;
        InvokeRepeating("changePattern", 3F, 3F);
        changePattern();
        currentDrag = 0;
        color = new Color32(255, 255, 255, 255);

    }

    void Update()
    {
        GameManager.instance.hook.transform.position = transform.position; // That line disables the "reeling back" aka right click when the hook is out

        method.Invoke(this, null); // Calls the current selected pattern

        lineRenderer.SetPosition(0, animator.gameObject.transform.position); //applying the line position on the fish so it won't slip out from the hook (because of acceleration)
        GameManager.instance.hook.transform.position = animator.gameObject.transform.position; // re-applying hook position so it won't slip out (because of acceleration)
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

    public void squareGravityPattern()
    {
        waypoints = new Vector3[4];
        waypoints[0] = new Vector3(-1, 0, 0);
        waypoints[1] = new Vector3(0, 1, 0);
        waypoints[2] = new Vector3(1, 0, 0);
        waypoints[3] = new Vector3(0, -1, 0);

        gravityPatternBehavior(waypoints);
    }

    public void diagonalGravityPattern()
    {
        waypoints = new Vector3[4];
        waypoints[0] = new Vector3(-1, 1, 0);
        waypoints[1] = new Vector3(1, 1, 0);
        waypoints[2] = new Vector3(1, -1, 0);
        waypoints[3] = new Vector3(-1, -1, 0);

        gravityPatternBehavior(waypoints);
    }

    public void circlePattern()
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

    public void changePattern()
    {
        currentPattern = patterns[Random.Range(0, patterns.Count)];

        if (Random.Range(0, 100) <= fishData.abilityChance)
        {
           if (Random.Range(0, 100) <= 50)
            {
                StartCoroutine(setAnimationWithDelayToFinish("Jump", 1.4f, 0.5f));
            }
            else
            {
                StartCoroutine(setAnimationWithDelayToFinish("Thrash", 2.7f, 0.5f));
            }
        }

        System.Type thisType = GetType();
        method = thisType.GetMethod(currentPattern.ToString());
    }

    private void gravityPatternBehavior(Vector3[] waypoints)
    {
        Vector2 direction = (Vector2)moveDirection;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        targetRotation = Quaternion.AngleAxis(angle, new Vector3(0, 0, 1));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 300f * Time.deltaTime); // Rotates slowly the fish to the moving direction

        if (moving)
        {
            myRigidbody.drag = currentDrag;
            timeToMoveCounter -= Time.deltaTime;

            if (timeToMoveCounter < 0f)
            {
                moving = false;
                timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
            }


            waypointAux = false;
        }
        else
        {
            timeBetweenMoveCounter -= Time.deltaTime;
            myRigidbody.drag = decelerateSpeed + currentDrag;

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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.name == "TestCollider")
        {
            //currentPattern *= -1;
            Debug.Log("It did hit the TestCollider");
        }
    }

    private IEnumerator setAnimationWithDelayToFinish(string parameterName, float secondsDuration, float secondsToStart)
    {
        StartCoroutine(setLineAlertColor(secondsToStart + secondsDuration));
        yield return new WaitForSeconds(secondsToStart);
        animator.SetBool(parameterName, true);
        yield return new WaitForSeconds(secondsDuration);
        animator.SetBool(parameterName, false);
    }

    private IEnumerator setLineAlertColor(float duration)
    {
        float startTime = Time.time;
        while (Time.time < startTime + duration)
        {
                //if(color.g > 5) {
                //    color.g -= 3;
                //    color.b -= 3;
                //}
            GameManager.instance.hook.GetComponent<LineScript>().setLineColor(255, 0, 0, 255); // MODIFIED FOR THE TRAILER, SHOULD BE 255, 0, 0, 255
            yield return null;
        }
        GameManager.instance.hook.GetComponent<LineScript>().setLineColor(255, 255, 255, 10);
        yield return null;
    }

    void OnDisable()
    {
        StopAllCoroutines();
        CancelInvoke();
        if(GameManager.instance.hook != null)
            GameManager.instance.hook.GetComponent<LineScript>().setLineColor(255, 255, 255, 10);
    }
}


//Vector3 diff = moveDirection;// - transform.position;
//diff.Normalize();
//float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
//transform.rotation = Quaternion.Euler(0f, 0f, rot_z); // Turns the fish to the hook direction   ONE OF THE ROTATION SNIPPET (INTERNET)