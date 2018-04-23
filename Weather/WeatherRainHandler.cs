using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherRainHandler : MonoBehaviour
{

    private WeatherRainFog weatherRainFog;
    private GameManager gm;

    void Start()
    {
        gm = GameManager.instance;
        weatherRainFog = GetComponent<WeatherRainFog>();

        //startRain(Random.Range(0.1f, 1));
        endRain();
    }

    public void startRain(float intensity)
    {
        StartCoroutine(smoothStartRain(intensity));
    }

    public void endRain()
    {
        StartCoroutine(smoothEndRain());
    }

    private IEnumerator smoothStartRain(float intensity)
    {
        while (gm.rain.RainIntensity < intensity)
        {
            gm.rain.RainIntensity += 0.001f;
            weatherRainFog.updateRainFog(gm.rain.RainIntensity);
            yield return null;
        }
    }

    private IEnumerator smoothEndRain()
    {
        while (gm.rain.RainIntensity > 0)
        {
            gm.rain.RainIntensity -= 0.001f;
            if (gm.rain.RainIntensity < 0)
                gm.rain.RainIntensity = 0;
            weatherRainFog.updateRainFog(gm.rain.RainIntensity);
            yield return null;
        }
    }
}
