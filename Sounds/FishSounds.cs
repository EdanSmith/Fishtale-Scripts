using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSounds : MonoBehaviour {

	public void jumpInWaterSound()
    {
        SoundManager.instance.PlaySound2D("Fish Jump In Water", GameManager.instance.hook.transform.position);
    }

    public void jumpOutWaterSound()
    {
        SoundManager.instance.PlaySound2D("Fish Jump Out Water", GameManager.instance.hook.transform.position);
    }

    public void trashingSound()
    {
        SoundManager.instance.PlaySound2D("Fish Thrashing", GameManager.instance.hook.transform.position);
    }
}
