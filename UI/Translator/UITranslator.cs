using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UITranslator : MonoBehaviour {

    public string translationId;

    // Use this for initialization
    void Start () {
        GetComponent<TextMeshProUGUI>().text = TranslatorManager.instance.GetTranslationById(translationId);
	}

    public void Refresh()
    {
        Start();
    }
}
