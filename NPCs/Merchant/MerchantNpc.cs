using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MerchantNpc : MonoBehaviour, IInteractable, IPointerEnterHandler, IPointerExitHandler
{

    public float playerDistance;
    private UIGameManager ui;
    private Color32 curColor;
    private bool isMouseOver;

    // Use this for initialization
    void Start()
    {
        ui = UIGameManager.instance;
        isMouseOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        playerDistance = Vector3.Distance(transform.position, GameManager.instance.playerMovement.transform.position);
        if (playerDistance < 3f)
        {
            GameManager.instance.merchantNear = this;
            //    quickTalkWindow.transform.position = UIGameManager.instance.mainCamera.WorldToScreenPoint(transform.position);
            //    quickTalkWindow.SetActive(true);
        }
        else
        {
            GameManager.instance.merchantNear = null;
            //    quickTalkWindow.SetActive(false);
        }

        if (isMouseOver)
        {
            //playerDistance = Vector3.Distance(transform.position, GameManager.instance.playerMovement.transform.position);
            //curColor = ui.interactionIcon.color;

            //if (playerDistance < GameManager.instance.minDistanceToInteractNpc)
            //    curColor.a = 255;
            //else
            //    curColor.a = 128;

            //ui.interactionIcon.color = curColor;
        }
    }

    void OnMouseDown()
    {
        //UIGameManager.instance.shopWindow.gameObject.SetActive(true);
    }


    public void Interact()
    {
        playerDistance = Vector3.Distance(transform.position, GameManager.instance.playerMovement.transform.position);

        if (playerDistance < GameManager.instance.minDistanceToInteractNpc)
        {
            UIGameManager.instance.portraitCamera.GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y + 0.45f, -10); // set the portrait camera position
            ui.shopWindow.gameObject.SetActive(true);
        }
    }

    //void OnMouseEnter()
    //{
    //    if (!EventSystem.current.IsPointerOverGameObject())
    //    {
    //        ui.interactionIcon.gameObject.SetActive(true);

    //        UIGameManager.instance.SetInteractable(this);
    //    }
    //}

    //void OnMouseExit()
    //{
    //        UIGameManager.instance.SetInteractable(null);
    //        ui.interactionIcon.gameObject.SetActive(false);
    //}

    //void OnMouseOver()
    //{
    //    if (!EventSystem.current.IsPointerOverGameObject())
    //    {
    //        playerDistance = Vector3.Distance(transform.position, GameManager.instance.playerMovement.transform.position);

    //        curColor = ui.interactionIcon.color;

    //        if (playerDistance < GameManager.instance.minDistanceToInteractNpc)
    //        {
    //            curColor.a = 255;
    //        }
    //        else
    //        {
    //            curColor.a = 128;
    //        }


    //        ui.interactionIcon.color = curColor;
    //    }//else
    //        //OnPointerExit();
    //}

    public void OnPointerEnter(PointerEventData eventData)
    {
        ui.interactionIcon.gameObject.SetActive(true);
        UIGameManager.instance.SetInteractable(this);
        ui.npcMouseOverLocation = transform;
        isMouseOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UIGameManager.instance.SetInteractable(null);
        ui.interactionIcon.gameObject.SetActive(false);
        isMouseOver = false;
    }
}
