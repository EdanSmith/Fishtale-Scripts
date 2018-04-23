using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMother : MonoBehaviour {

    public Animator animator;
    public SpriteRenderer bird;
    public float angle;
    private Vector3 basePosition;
    private float playerDistance;
    public bool movingToRandomPlace;
    public bool movingToBasePos;
    private Vector3 destination;
    private float counter;
    private string parameterName;
    public Vector2 hopDestination;

	// Use this for initialization
	void Start () {
        movingToRandomPlace = false;
        movingToBasePos = false;
        basePosition = transform.position;
        animator.SetBool("OnGround", true);
        counter = 0;
    }
	
	// Update is called once per frame
	void Update () {
        playerDistance = Vector3.Distance(transform.position, GameManager.instance.playerMovement.transform.position); // Player distance between the bird

        counter -= Time.deltaTime; // counter for the hop and peck animation

        if (counter <= 0 && animator.GetBool("OnGround"))
        {
            StartCoroutine(delayedHopAndPeck(1f));
            counter = Random.Range(4, 7);
        }

        if (playerDistance < 3f && !movingToRandomPlace && !animator.GetBool("Landing")) // if player get near, the bird will lift off and fly
        {
            movingToRandomPlace = true;
            disableGroundParameters(); // Disabling animations that the bird can do in the ground so it won't bug on StopAllCoroutines()
            StopAllCoroutines();
            StartCoroutine(delayedLiftOffToFlying(0.5f));
            destination = new Vector3(Random.Range(transform.position.x -15f, transform.position.x + 15f), Random.Range(transform.position.y -15f, transform.position.y + 15f), 0);
        }

        if (movingToRandomPlace) // if the bird is in the middle action of moving to any place
        {
            movingToBasePos = false;
            animator.SetBool("OnGround", false);
            transform.position = Vector3.MoveTowards(transform.position, destination, 5f * Time.deltaTime);
            updateBirdDirection(destination);
        }

        if (transform.position == destination) // if the bird reach the random place destination
        {
            movingToRandomPlace = false;
            StartCoroutine(delayToFlyBack(3f));
        }

        if (movingToBasePos) // if the bird is moving back to his base position
        {
            transform.position = Vector3.MoveTowards(transform.position, basePosition, 5f * Time.deltaTime);
            updateBirdDirection(basePosition);
        }
        if (transform.position == basePosition && animator.GetBool("Flying")) // if the bird did reach his base position and he were flying
        {
            StartCoroutine(delayedLandingtoIdle(0.5f));
            movingToBasePos = false;
            animator.SetBool("OnGround", true);
        }
        if (animator.GetBool("OnGround") && animator.GetBool("Hoping"))
        {
            transform.position = Vector3.MoveTowards(transform.position, hopDestination, 1f * Time.deltaTime);
        }
        if (animator.GetBool("OnGround"))
        {
            GetComponent<CircleCollider2D>().enabled = true;
            movingToBasePos = false;
        }
    }

    private IEnumerator delayedLiftOffToFlying(float seconds)
    {
        GetComponent<CircleCollider2D>().enabled = false;
        animator.SetBool("LiftingOff", true);
        yield return new WaitForSeconds(seconds);
        animator.SetBool("Flying", true);
        animator.SetBool("LiftingOff", false);
    }

    private IEnumerator delayedLandingtoIdle(float seconds)
    {
        animator.SetBool("Landing", true);
        animator.SetBool("Flying", false);
        yield return new WaitForSeconds(seconds);
        animator.SetBool("Landing", false);
    }

    private IEnumerator delayToFlyBack(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        movingToBasePos = true;
    }

    private IEnumerator delayedHopAndPeck(float seconds)
    {
        int randomNumber = Random.Range(0, 8);
        if (randomNumber <= 2)
        {
            parameterName = "Hoping";
            hopDestination = new Vector2(transform.position.x + Random.Range(-10, 10), transform.position.y + Random.Range(-10, 10));
        }
        else if (randomNumber <= 5)
            parameterName = "Pecking";
        else
            parameterName = "Flaping";

        updateBirdDirection(hopDestination);

        animator.SetBool(parameterName, true);
        yield return new WaitForSeconds(seconds);
        animator.SetBool(parameterName, false);
    }

    private void disableGroundParameters()
    {
        animator.SetBool("Hoping", false);
        animator.SetBool("Flaping", false);
        animator.SetBool("Pecking", false);
    }

    private void updateBirdDirection(Vector2 destination)
    {
        // Get Angle in Radians
        float AngleRad = Mathf.Atan2(transform.position.y - destination.y, transform.position.x - destination.x);
        // Get Angle in Degrees
        angle = (180 / Mathf.PI) * AngleRad;

        //if (angle != 0)
        //{
            if (angle < -90f || angle > 90f)
                bird.flipX = false;
            else
                bird.flipX = true;
        //}
    }
}
