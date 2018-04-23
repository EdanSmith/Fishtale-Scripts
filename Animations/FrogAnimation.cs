using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogAnimation : MonoBehaviour
{
    private Texture2D texture;

    public void deactivateThroatParticle()
    {
        if (transform.GetComponentInParent<Frog>().frogInflate.gameObject.activeSelf)
            transform.GetComponentInParent<Frog>().frogInflate.gameObject.SetActive(false);
    }

    public void deactivateAll()
    {
        transform.parent.gameObject.SetActive(false);
    }

    public void splashParticles()
    {
        Instantiate(Resources.Load("Prefabs/Particles/Frog Water Splash"), transform.position, Quaternion.identity);
    }

    //void Start()
    //{
    //    if (!string.IsNullOrEmpty(AssetDatabase.GetAssetPath(GetComponent<SpriteRenderer>().sprite.texture)))
    //    {
    //        //texture = Instantiate<Texture2D>(GetComponent<SpriteRenderer>().sprite.texture);
    //        //GetComponent<SpriteRenderer>().sprite = texture.Resize
    //    }
    //}

}
