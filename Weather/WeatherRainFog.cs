using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeatherRainFog : MonoBehaviour {

    public Image fogRain;

    private Color32 fogRainColor;
    private GameManager gm;

    void Awake()
    {
        gm = GameManager.instance;
        fogRainColor = new Color32(255, 255, 255, 0);
        //updateRainFog();
    }

    public void updateRainFog(float rainIntensity)
    { // Rain intensity = the rain multiplier from the RainPrefab2D asset
        try
        {
            fogRainColor.a = (byte)(gm.rain.RainIntensity * 130);
        }
        catch (System.NullReferenceException)
        {
            fogRainColor = new Color32(255, 255, 255, (byte)(rainIntensity * 130));
        }
        fogRain.color = fogRainColor;
    }
}
