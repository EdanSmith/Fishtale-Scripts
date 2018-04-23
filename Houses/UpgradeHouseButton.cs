using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeHouseButton : MonoBehaviour {

    public void upgradePlayerHouse()
    {
        StartCoroutine(upgradeHouseConstructionTime(2));
    }

    private IEnumerator upgradeHouseConstructionTime(float seconds)
    {
        Instantiate(Resources.Load("Prefabs/Particles/House Construction"));
        SoundManager.instance.PlaySoundPitchless("Building House", GameManager.instance.playerHouse.transform.position);
        yield return new WaitForSeconds(seconds);
        GameManager.instance.playerHouse.GetComponent<SpriteRenderer>().sprite = Resources.LoadAll<Sprite>("Images/Environment/Houses")[0];
    }

}
