using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        if (UIGameManager.instance.mainCameraLocation == null)
        {
            UIGameManager.instance.mainCameraLocation = GameManager.instance.playerMovement.transform;
        }
        transform.position = new Vector3(UIGameManager.instance.mainCameraLocation.transform.position.x, UIGameManager.instance.mainCameraLocation.transform.position.y, -10);
	}
}
