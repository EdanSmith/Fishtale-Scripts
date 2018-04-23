using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIButtonSounds : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler {

    public AudioClip mouseEnterClip;
    public AudioClip mouseExitClip;
    public AudioClip mouseClickClip;
    public AudioClip mouseClickDownClip;
    public AudioClip mouseClickUpClip;

    private bool interactable;

    void Start()
    {
        interactable = GetComponent<Button>().interactable;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(mouseEnterClip != null)
            SoundManager.instance.PlaySound2D(mouseEnterClip.name, GameManager.instance.playerMovement.transform.position);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (mouseExitClip != null)
            SoundManager.instance.PlaySound2D(mouseExitClip.name, GameManager.instance.playerMovement.transform.position);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (mouseClickClip != null && (GetComponent<Button>().interactable || interactable))
            SoundManager.instance.PlaySound2D(mouseClickClip.name, GameManager.instance.playerMovement.transform.position);

        interactable = GetComponent<Button>().interactable;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (mouseClickDownClip != null)
            SoundManager.instance.PlaySound2D(mouseClickDownClip.name, GameManager.instance.playerMovement.transform.position);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (mouseClickUpClip != null)
            SoundManager.instance.PlaySound2D(mouseClickUpClip.name, GameManager.instance.playerMovement.transform.position);
    }
}
