using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookMarker : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameManager.instance.hookMarker = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
