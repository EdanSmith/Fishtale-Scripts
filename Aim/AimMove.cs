using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimMove : MonoBehaviour
{

    public float moveSpeed;
    private Rigidbody2D myRigidbody;

    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

            if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                myRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, myRigidbody.velocity.y);
            }
            if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
            {
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
        }
}