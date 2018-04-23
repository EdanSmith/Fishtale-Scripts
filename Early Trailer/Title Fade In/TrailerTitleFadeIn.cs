using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailerTitleFadeIn : MonoBehaviour
{

    public SpriteRenderer reflection;
    public Material displacementMaterial;
    private SpriteRenderer sr;
    private Color32 color;

    // Use this for initialization
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.color = new Color32(255, 255, 255, 0);
        color = sr.color;
        reflection.color = sr.color;
        displacementMaterial.SetFloat("_Magnitude", 0.0005f);

        //Debug.Log(displacementMaterial.HasProperty("_Magnitude"));
    }

    // Update is called once per frame
    void Update()
    {
        if (color.a < 250)
        {
            color.a += 3;
            sr.color = color;
            reflection.color = color;
        }
        if (color.a >= 250)
        {
            reflection.material = displacementMaterial;
            if (displacementMaterial.GetFloat("_Magnitude") < 0.02f)
            {
                displacementMaterial.SetFloat("_Magnitude", displacementMaterial.GetFloat("_Magnitude") + 0.00025f);
            }
        }
    }
}
