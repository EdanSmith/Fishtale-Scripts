using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortraitCamera : MonoBehaviour {

    public Transform backgroundCamera;
    public Transform npcCamera;

    void Update()
    {
        if (GameManager.instance.npcCurrentInteraction != null)
        {
            UIGameManager.instance.portraitCamera.position = new Vector3(GameManager.instance.npcCurrentInteraction.transform.position.x, GameManager.instance.npcCurrentInteraction.transform.position.y + 0.3f, -10);
        }
    }
}
