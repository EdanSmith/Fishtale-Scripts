using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kraken : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        SoundManager.instance.PlaySoundPitchless2D("Kraken Spawn", Vector2.zero);
    }
}
