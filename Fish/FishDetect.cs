using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishDetect : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        GameManager.instance.fishDetect = this;
    }

    public void alertSpawn()
    {
        gameObject.SetActive(true);
        //SoundManager.instance.PlaySound("Fish Bite", GameManager.instance.hook.transform.position);
        InvokeRepeating("alertDespawn", 1, 1F);
    }


    void alertDespawn()
    {
        CancelInvoke("alertDespawn");
        gameObject.SetActive(false);
    }
}
