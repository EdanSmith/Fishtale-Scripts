using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCQuickTalkWindowResizer : MonoBehaviour {

    public TextMeshProUGUI text;

    void Start()
    {
        OnEnable();
    }

    // Use this for initialization
    void OnEnable () {
        GetComponent<Image>().rectTransform.sizeDelta = new Vector2(GetComponent<Image>().rectTransform.rect.width, text.preferredHeight + ((Screen.height / 100) * 5));
    }
}
