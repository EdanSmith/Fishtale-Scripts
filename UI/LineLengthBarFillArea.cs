using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineLengthBarFillArea : MonoBehaviour {

    private Slider lineLengthBar;
    private Image lineLengthBarFill;

    // Use this for initialization
    void Start () {
        //UIGameManager.instance.fillColor = this;
        lineLengthBar = UIGameManager.instance.lineLengthBar.GetComponent<Slider>();
        lineLengthBarFill = GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {
        //if (lineLengthBar.value < lineLengthBar.maxValue / 2) // below 50%
        //{
        //    lineLengthBarFill.color = new Color32(255, 0, 0, 255);
        //}
        //else
        //{
        //    lineLengthBarFill.color = new Color32(0, 255, 0, 255);
        //}

    }
}
