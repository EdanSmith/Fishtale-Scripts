using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingSounds : MonoBehaviour {

    public void castingHookSound()
    {
        SoundManager.instance.playSoundOnPlayer(SoundManager.instance.GetClipByName("castingHook"));
    }

    public void hookOnSomethingSoundAnimation()
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(GameManager.instance.hook.transform.position, GameManager.instance.hook.GetComponent<CircleCollider2D>().radius);
        foreach (Collider2D col in cols)
        {
            if (col.tag.Equals("Water"))
            {
                SoundManager.instance.PlaySound("Hook On Water", GameManager.instance.hook.transform.position);
                Instantiate(Resources.Load("Prefabs/Particles/Fish Thrashing"), GameManager.instance.hook.transform.position, Quaternion.identity);
                break;
            }
        }
    }

    public void fishAlertSound()
    {
        SoundManager.instance.PlaySound("Fish Bite", GameManager.instance.hook.transform.position);
    }
}
