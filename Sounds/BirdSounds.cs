using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSounds : MonoBehaviour {

    public void flapSound()
    {
        SoundManager.instance.PlaySound("flap2", transform.position);
    }
    public void flyingSound()
    {
        SoundManager.instance.PlaySound("flap1", transform.position);
    }
    public void pewSound()
    {
        SoundManager.instance.PlaySound("chrip1", transform.position);
    }
    public void pewpewSound()
    {
        SoundManager.instance.PlaySound("chrip2", transform.position);
    }
}
