using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFinishedAnimation : MonoBehaviour {

    public void selfDestruction()
    {
        Destroy(gameObject);
    }
}
