using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour {

    public ParticleSystem frogInflate;
    public Animator animator;
    private float playerDistance;
    private float hookDistance;

    // Update is called once per frame
    void Update () {
        playerDistance = Vector3.Distance(transform.position, GameManager.instance.playerMovement.transform.position);
        hookDistance = Vector3.Distance(transform.position, GameManager.instance.hook.transform.position);


        if (playerDistance < 3f || (GameManager.instance.hook.gameObject.activeSelf && hookDistance < 2f))
        {
            StartCoroutine(jumpWithDelay(0.5f));
        }
    }

    private IEnumerator jumpWithDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        animator.SetBool("Jumping", true);
        if (Random.Range(0, 2) == 0)
            animator.SetBool("Left", false);
        else
            animator.SetBool("Left", true);
    }
}
