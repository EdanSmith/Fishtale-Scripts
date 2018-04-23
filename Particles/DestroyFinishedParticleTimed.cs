using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFinishedParticleTimed : MonoBehaviour {

    private ParticleSystem particleSystem;
    public float timer = 1f;

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }


    void Update()
    {
        timer -= Time.deltaTime;
        if (timer > 0)
            return;

        Destroy(gameObject);
    }
}
