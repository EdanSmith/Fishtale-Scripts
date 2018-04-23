using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeatherNightFog : MonoBehaviour
{

    public Image fogNight;

    private Color32 fogNightColor;
    private GameManager gm;
    private float currentMinute;
    private int minutesToHourPercent;
    private int detailedFogAlpha;

    void Start()
    {
        fogNightColor = new Color32(255, 255, 255, 0);
        gm = GameManager.instance;
        updateNightFog();
    }

    void Update()
    {
        updateNightFog();
    }
    public void updateNightFog()
    {
        if (gm.clock.currentHour >= 1800 && gm.clock.currentHour < 1900)
        {
            updateNightFogOpacity(20, 1, true);
        }
        else if (gm.clock.currentHour >= 1900 && gm.clock.currentHour < 2000)
        {
            updateNightFogOpacity(40, 20, true);
        }
        else if (gm.clock.currentHour >= 2000 && gm.clock.currentHour < 2100)
        {
            updateNightFogOpacity(60, 40, true);
        }
        else if (gm.clock.currentHour >= 2100 && gm.clock.currentHour < 2200)
        {
            updateNightFogOpacity(80, 60, true);
        }
        else if (gm.clock.currentHour >= 2200 && gm.clock.currentHour < 2300)
        {
            updateNightFogOpacity(100, 80, true);
        }
        else if (gm.clock.currentHour >= 2300 && gm.clock.currentHour < 2400)
        {
            updateNightFogOpacity(120, 100, true);
        }
        else if (gm.clock.currentHour >= 0 && gm.clock.currentHour < 100)
        {
            updateNightFogOpacity(120, 100, false);
        }
        else if (gm.clock.currentHour >= 100 && gm.clock.currentHour < 200)
        {
            updateNightFogOpacity(100, 80, false);
        }
        else if (gm.clock.currentHour >= 200 && gm.clock.currentHour < 300)
        {
            updateNightFogOpacity(80, 60, false);
        }
        else if (gm.clock.currentHour >= 300 && gm.clock.currentHour < 400)
        {
            updateNightFogOpacity(60, 40, false);
        }
        else if (gm.clock.currentHour >= 400 && gm.clock.currentHour < 500)
        {
            updateNightFogOpacity(40, 20, false);
        }
        else if (gm.clock.currentHour >= 500 && gm.clock.currentHour < 600)
        {
            updateNightFogOpacity(20, 1, false);
        }
        else
        {
            updateNightFogOpacity(2, 1, false);
        }
    }

    private void updateNightFogOpacity(int alpha, int minAlpha, bool darkening)
    {
        if (gm.clock.currentMinute < 590) // To remove a small margin of error (Chance of the screen blink), it would reach 600 instead.
        {
            currentMinute = gm.clock.currentMinute;
            minutesToHourPercent = Mathf.RoundToInt((currentMinute / 600) * 100);
            if (!darkening)
                minutesToHourPercent = (minutesToHourPercent - 100) * -1;

            detailedFogAlpha = Mathf.RoundToInt((((alpha - minAlpha) * minutesToHourPercent) / 100) + minAlpha);
            fogNightColor = new Color32(255, 255, 255, (byte)detailedFogAlpha);
            fogNight.color = fogNightColor;
        }

    }
}
