using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{

    public Image dayNightArea;
    public Image energyNumber;
    public Image minuteArrow;
    public Image hourArrow;
    public int currentHour;
    public int currentMinute;
    public int currentEnergy;
    public List<float> hourRotationDegree;

    private int minuteToHourAux;
    private int hourToEnergyAux;
    private Color32 color;

    // Use this for initialization
    void Start()
    {
        //currentHour = 600; // Divided by 100 = correct hour
        //currentMinute = 0; // Divided by 10 = correct minute
        InvokeRepeating("updateMinute", 0, 0.05f);
        color = hourArrow.color;
        StartCoroutine(smoothEnergyRotation(Quaternion.Euler(0, 0, hourRotationDegree[currentEnergy - 1])));
        GameManager.instance.clock = this;
    }

    // Update is called once per frame
    void Update()
    {
        hourArrow.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, currentHour * -0.3f);
        minuteArrow.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, currentMinute * -0.6f);
        dayNightArea.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, currentHour * -0.15f); // Hours divided by 2

        if ((currentHour > 530 && currentHour < 670) || (currentHour > 1730 && currentHour < 1870))
            color.a = 150;
        else
            color.a = 255;

        hourArrow.color = color;
        //energyNumber.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, currentEnergy * -22.5f);
    }

    private void updateHour()
    {
        if (currentHour >= 2399f) // at 23.99h it will change to 00:00
            currentHour = 0;
        else
            currentHour += 1;

        hourToEnergyAux += 1;

        if (hourToEnergyAux >= 100) // Every 1 hour
        {
            hourToEnergyAux = 0;
            if (currentEnergy > 1)
            {
                currentEnergy -= 1;
                StartCoroutine(smoothEnergyRotation(Quaternion.Euler(0, 0, hourRotationDegree[currentEnergy - 1]))); // rotation degree is being based on the list pre-set values
            }

        }

        minuteToHourAux = 0;
    }

    private void updateMinute()
    {
        if (currentMinute >= 600f) // 600 = 60 minutes
            currentMinute = 0;
        else
        {
            currentMinute += 1;
            minuteToHourAux += 1;
        }

        if (minuteToHourAux >= 6) // every 6 minutes = increases 10% of the hour
            updateHour();
    }

    private IEnumerator smoothEnergyRotation(Quaternion angle) // Smooth rotation for the energy display
    {
        while (energyNumber.GetComponent<RectTransform>().localRotation != angle)
        {
            energyNumber.GetComponent<RectTransform>().localRotation = Quaternion.RotateTowards(energyNumber.GetComponent<RectTransform>().localRotation, angle, 50f * Time.deltaTime);
            yield return null;
        }
        yield return null;
    }
}
