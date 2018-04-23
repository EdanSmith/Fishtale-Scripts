using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopWindow : MonoBehaviour {

    public GameObject[] items;

    void Start()
    {
        UIGameManager.instance.shopWindow = this;
    }

}
