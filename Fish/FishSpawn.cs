using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawn : MonoBehaviour {

    public FishData[] spawnableFish;
    public GameObject fishDetectionAlert;
    public GameObject aim;
    private LineScript hook;
    private GameObject fishGameObject;
    private string spawnedFishId;
    private Transform cameraPos;
    private Transform hookPos;
    bool hookOnWater;

    void Start () {

    }
	
	void Update () {
        if (Input.GetMouseButtonDown(0) && GameManager.instance.fishDetect.gameObject.activeSelf && GameManager.instance.currentSpawnedFish == null && GameManager.instance.currentFishSpawnArea == this)
        {
            spawnedFishId = spawnableFish[(int)Random.Range(0.01f, spawnableFish.Length - 0.01f)].id;
            //Instantiate(GameManager.instance.spawnFish("fag_fish"), GameManager.instance.hook.transform.position, Quaternion.identity);
            fishGameObject = GameManager.instance.spawnFish(spawnedFishId); // the -0.01 is so it never reaches the non-existent index, also, same chance for every fish atm
            fishGameObject.SetActive(false);
            StartCoroutine(delayedSpawn(1));
            //GameManager.instance.spawnFish(spawnableFish[0].id); // the -0.01 is so it never reaches the non-existent index, also, same chance for every fish atm
            //Instantiate(aim, GameManager.instance.hook.transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (GameManager.instance.currentSpawnedFish == null)
        {
            if (other.name == "Hook")
            {
                hookOnWater = true;
                Debug.Log("Enter");
                InvokeRepeating("fishBite", 2, 2F);
                GameManager.instance.currentFishSpawnArea = this;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Hook")
        {
            hookOnWater = false;
            Debug.Log("Exit");
            CancelInvoke("fishBite");
        }
    }

    private void fishBite()
    {
        Debug.Log("Fish Bite!");
        if (GameManager.instance.hook != null)
        {
            //Instantiate(fishDetectionAlert, GameManager.instance.hook.transform.position, Quaternion.identity);
            GameManager.instance.fishDetect.alertSpawn();
            GameManager.instance.fishDetect.transform.position = GameManager.instance.hook.transform.position;
        }
        CancelInvoke("fishBite");
    }

    private IEnumerator delayedSpawn(float seconds)
    {
        if (GameManager.instance.fishDetect.gameObject.activeSelf)
            GameManager.instance.fishDetect.gameObject.SetActive(false);
        UIGameManager.instance.mainCamera.GetComponent<CameraHandler>().enabled = false;
        StartCoroutine(cameraLerpTowardsFishSpawn());
        GameObject fishShadow = (GameObject)Instantiate(Resources.Load("Prefabs/Animation/Fish Shadow Spawn Animation"), GameManager.instance.hook.transform.position, Quaternion.identity);
        fishShadow.GetComponent<SpriteRenderer>().sprite = GameManager.instance.GetFishDataById(spawnedFishId).fishSprite[1];

        yield return new WaitForSeconds(seconds);

        StopCoroutine("cameraLerpTowardsFishSpawn");
        UIGameManager.instance.mainCamera.GetComponent<CameraHandler>().enabled = true;
        GameManager.instance.aim.refresh();
        GameManager.instance.aim.gameObject.SetActive(true);
        GameManager.instance.aim.gameObject.transform.position = GameManager.instance.hook.transform.position;
        UIGameManager.instance.uiFishBarAnimator.refresh();
        UIGameManager.instance.skillPanel.gameObject.SetActive(true);
        fishGameObject.SetActive(true);
        Destroy(fishShadow);

    }

    IEnumerator cameraLerpTowardsFishSpawn()
    {
        cameraPos = UIGameManager.instance.mainCamera.transform;
        hookPos = GameManager.instance.hook.transform;

        while (UIGameManager.instance.mainCameraLocation.transform.position != GameManager.instance.hook.transform.position)
        {
            UIGameManager.instance.mainCamera.transform.position = Vector3.Lerp(
                new Vector3(cameraPos.position.x, cameraPos.position.y, -10),
                new Vector3(hookPos.position.x, hookPos.position.y, -10),
                4f * Time.deltaTime);
            yield return null;
        }
        yield return null;
    }
}
