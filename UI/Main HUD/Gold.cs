using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Gold : MonoBehaviour
{
    public Transform goldIcon;
    public TextMeshProUGUI playerCurrentGold;

    void Start()
    {
        UIGameManager.instance.goldPanel = this;
    }

    public void updateCurrentGold()
    {
        playerCurrentGold.text = GameManager.instance.player.currentGold.ToString();
    }
}
