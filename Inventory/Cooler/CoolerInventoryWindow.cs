using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolerInventoryWindow : MonoBehaviour {

	// Use this for initialization
	void Start () {
        UIGameManager.instance.animatedInventoryWindow = this;
	}
	
}
