using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledAudioPlayer : MonoBehaviour {

    public AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayClip(string clip, float volume)
    {
        audioSource.volume = volume;
        audioSource.clip = SoundManager.instance.GetClipByName(clip);
        audioSource.pitch = Random.Range(0.925f, 1.075f);
        GetComponent<AudioSource>().Play();
    }

    public void PlayClipPitchless(string clip, float volume)
    {
        audioSource.volume = volume;
        audioSource.clip = SoundManager.instance.GetClipByName(clip);
        audioSource.pitch = 1;
        GetComponent<AudioSource>().Play();
    }
}
