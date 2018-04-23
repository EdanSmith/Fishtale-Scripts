using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogSounds : MonoBehaviour {

    public void frogCroakSound()
    {
        SoundManager.instance.PlaySound("Frog Sound", transform.position);
    }

    public void frogSplashSound()
    {
        SoundManager.instance.PlaySound("Hook On Water", transform.position);
    }
}
