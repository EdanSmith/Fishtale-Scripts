using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrakenTentacleAnimation : MonoBehaviour {

    private SpriteRenderer sr;
    private float tentacleMaxHeight;
    private float tentacleMaxWidth;
    private float currentHeight;
    private Animator animator;

    public ParticleSystem ps;
    public float spawnSpeed = 1;

	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        tentacleMaxHeight = 1.74f;
        tentacleMaxWidth = 0.58f;
        currentHeight = 0;
        StartCoroutine(tentacleSpawnAnimation());
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    private IEnumerator tentacleSpawnAnimation()
    {
        while (currentHeight < 1.74f)
        {
            currentHeight += Time.deltaTime * spawnSpeed;
            sr.size = new Vector2(tentacleMaxWidth, currentHeight);
            yield return null;
        }
        animator.SetBool("FullySpawned", true);
        ps.Stop();
        yield return null;
    }
}
