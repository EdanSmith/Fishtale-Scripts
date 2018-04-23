using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBoltEffect : MonoBehaviour {

    public float acceleration;
    private float counter;

    void Start()
    {
        counter = 0;
    }

    void Update()
    {
        counter += Time.deltaTime * acceleration;

        if (counter >= 3.5)
            counter = 0;

        GetComponent<CircleCollider2D>().radius = counter;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag.Equals("Catchable Animal"))
        {
            GameManager.instance.playerMovement.GetComponent<LightningBoltSkill>().activateSkill();
        }
    }

    public void impactParticle()
    {
        Instantiate(Resources.Load("Prefabs/Particles/Lightning Bolt Impact"), GameManager.instance.hook.transform.position, Quaternion.identity);
    }
}
