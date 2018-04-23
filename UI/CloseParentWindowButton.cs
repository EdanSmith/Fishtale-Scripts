using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseParentWindowButton : MonoBehaviour {

    public void closeParentWindow()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
