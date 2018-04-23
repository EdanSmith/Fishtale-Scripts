using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownTimer : MonoBehaviour {

    public GameObject fillArea; // using slider UI

    void Update () {
        if (GameManager.instance.hc.hookOnCooldown)
        {
            //GetComponent<Text>().text = GameManager.instance.cooldownCountedSeconds.ToString();
            fillArea.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
            GetComponent<Slider>().value = GameManager.instance.hc.cooldownCountedSeconds;
        }else
        {
            //GetComponent<Text>().text = "Ready";
            fillArea.GetComponent<Image>().color = new Color32(0, 255, 0, 255);
        }
	}
}
