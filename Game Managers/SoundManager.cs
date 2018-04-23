using UnityEngine;
using System.Collections;
using LitJson;
using System.IO;
using System.Collections.Generic;       //Allows us to use Lists. 

public class SoundManager : MonoBehaviour
{

    public static SoundManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.

    public AudioSource player;
    public List<PooledAudioPlayer> audioPlayers2D = new List<PooledAudioPlayer>();
    public List<PooledAudioPlayer> audioPlayers = new List<PooledAudioPlayer>();

    private List<AudioClip> baseClips = new List<AudioClip>();
    public int clipIndex;
    public int clipIndex2D;
    public Dictionary<string, AudioClip> clip = new Dictionary<string, AudioClip>();

    //Awake is always called before any Start functions
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        baseClips.AddRange(Resources.LoadAll<AudioClip>("Sounds"));

        for (int i = 0; i < baseClips.Count; i++)
        {
            clip.Add(baseClips[i].name, baseClips[i]);
        }
        clipIndex = 0;
        clipIndex2D = 0;

    }

    public AudioClip GetClipByName(string clipName)
    {
        return clip[clipName];
    }

    public void playSoundOnPlayer(AudioClip clip, float pitch = 0f)
    {
        if(pitch == 0f)
            pitch = Random.Range(0.925f, 1.075f);

        player.clip = clip;
        player.pitch = pitch;
        player.Play();
    }

    public void PlaySound(string clip, Vector3 position, float volume = 1f)
    {
        audioPlayers[clipIndex].transform.position = position;
        audioPlayers[clipIndex].PlayClip(clip, volume); // Sound volume
        if (clipIndex + 1 >= audioPlayers.Count)
            clipIndex = 0;
        else
            clipIndex++;
    }

    public void PlaySound2D(string clip, Vector3 position, float volume = 1f)
    {
        audioPlayers2D[clipIndex2D].transform.position = position;
        audioPlayers2D[clipIndex2D].PlayClip(clip, volume); // Sound volume
        if (clipIndex2D + 1 >= audioPlayers.Count)
            clipIndex2D = 0;
        else
            clipIndex2D++;
    }

    public void PlaySoundPitchless(string clip, Vector3 position, float volume = 1f)
    {
        audioPlayers[clipIndex].transform.position = position;
        audioPlayers[clipIndex].PlayClipPitchless(clip, volume); // Sound volume
        if (clipIndex + 1 >= audioPlayers.Count)
            clipIndex = 0;
        else
            clipIndex++;
    }

    public void PlaySoundPitchless2D(string clip, Vector3 position, float volume = 1f)
    {
        audioPlayers2D[clipIndex2D].transform.position = position;
        audioPlayers2D[clipIndex2D].PlayClipPitchless(clip, volume); // Sound volume
        if (clipIndex2D + 1 >= audioPlayers.Count)
            clipIndex2D = 0;
        else
            clipIndex2D++;
    }

}