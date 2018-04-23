using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCustomizationWindow : MonoBehaviour {

    void Start()
    {
        CharCustomManager.instance.charCustomWindow = this;
    }
}
