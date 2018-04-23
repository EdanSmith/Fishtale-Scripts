using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolerSpace : MonoBehaviour
{
    // Use this for initialization
    void Awake()
    {
        UIGameManager.instance.coolerSpace = this;
    }
}

//this.Sprite = Resources.Load<Sprite>("Images/LeatherChest"); // or  this.Sprite = Resources.Load<Sprite>("Images/" + slug);