using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAnimation : MonoBehaviour {

    //private Sprite currentFishSprite;
    private FishData fishData;

    public void fishJumpOutWaterParticle()
    {
        Instantiate(Resources.Load("Prefabs/Particles/FishJumpingOutWater"), GameManager.instance.hook.transform.position, Quaternion.identity);
    }

    public void fishJumpInWaterParticle()
    {
        Instantiate(Resources.Load("Prefabs/Particles/FishJumpingInWater"), GameManager.instance.hook.transform.position, Quaternion.identity);
    }

    public void fishThrashingParticle()
    {
        Instantiate(Resources.Load("Prefabs/Particles/Fish Thrashing"), GameManager.instance.hook.transform.position, Quaternion.identity);
    }

    public void fishChangeLayer(int layer)
    {
        GetComponent<SpriteRenderer>().sortingOrder = layer;
    }

    // sprite goes from 0 to 2
    public void fishChangeSprite(int sprite)
    {
        fishData = GameManager.instance.GetFishDataById(GameManager.instance.currentSpawnedFish.id);
        GetComponent<SpriteRenderer>().sprite = fishData.fishSprite[sprite];
        
        //currentFishSprite = fishData.fishSprite[sprite];
    }


    //private bool jumpZRot;

    //public void jumpZRotation()
    //{
    //    GetComponent<Animator>().transform.position = new Vector3(0, -0.5f, 0);
    //    gameObject.transform.localPosition = new Vector3(0, -0.5f, 0);
    //    GetComponent<Animator>().rootPosition = new Vector3(0, -0.5f, 0);
    //    //gameObject.transform.position = new Vector3(0, -0.5f, 0);

    //    GetComponent<Animator>().transform.rotation = GameManager.instance.fish.targetRotation;
    //    transform.localRotation = GameManager.instance.fish.targetRotation;
    //    GetComponent<Animator>().rootRotation = GameManager.instance.fish.targetRotation;

    //    GameManager.instance.fish.targetRotation = transform.localRotation;

    //    Debug.Log("Mother Bitch");
    //    jumpZRot = true;
    //}

    //void LateUpdate()
    //{
    //    //if (jumpZRot)
    //    //{
    //    //    jumpZRotation();
    //    //    jumpZRot = false;
    //    //}
    //    if (currentFishSprite != null)
    //    {
    //        GetComponent<SpriteRenderer>().sprite = currentFishSprite;
    //    }
    //}
}
