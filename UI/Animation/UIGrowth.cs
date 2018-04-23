using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIGrowth : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private RectTransform rt;
    private float baseScaleX;
    private float baseScaleY;
    private bool overObject;

    public float animationSpeed = 300;
    public float growPercentage = 15;

    void Start()
    {
        rt = GetComponent<RectTransform>();
        baseScaleX = rt.transform.localScale.x;
        baseScaleY = rt.transform.localScale.y;
        overObject = false;
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        overObject = true;
        StartCoroutine(grow());

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        overObject = false;
        StartCoroutine(compress());
    }

    IEnumerator grow()
    {
        while (overObject)
        {
            if (rt.transform.localScale.x < baseScaleX + ((baseScaleX / 100) * growPercentage))
            {
                rt.transform.localScale += new Vector3((baseScaleX / 100) * animationSpeed * Time.deltaTime, (baseScaleY / 100) * animationSpeed * Time.deltaTime, rt.transform.localScale.z);
                yield return null;
            }
            else
                break;
        }
        yield return null;
    }

    IEnumerator compress()
    {
        float startTime = Time.time;
        while (!overObject)
        {
            if (rt.transform.localScale.x > baseScaleX)
            {
                rt.transform.localScale -= new Vector3((baseScaleX / 100) * animationSpeed * Time.deltaTime, (baseScaleY / 100) * animationSpeed * Time.deltaTime, rt.transform.localScale.z);
                yield return null;
            } else if (rt.transform.localScale.x < baseScaleX)
                rt.transform.localScale = new Vector3(baseScaleX, baseScaleY, rt.transform.localScale.z);
            else
                break;
        }

        yield return null;
    }
}

//IEnumerator grow(float seconds)
//{
//    float startTime = Time.time;
//    while (Time.time < startTime + seconds)
//    {
//        Debug.Log("Hi");
//    }

//    yield return null;
//}