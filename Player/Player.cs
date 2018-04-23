using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class Player {

    public int currentGold;
    public string[] equippedItem = new string[6];

    public Player(JsonData playerData)
    {
        this.currentGold = (int)playerData["currentGold"];
        //GameManager.instance.player.currentGold = this.currentGold;
    }

}
