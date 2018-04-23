using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class MouseEventHandler : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler,
    IPointerDownHandler, IPointerUpHandler, IDragHandler //, IScrollHandler
{
    public ScrollRect scrollRect;

    public delegate void ClickAction(PointerEventData eventData);
    public event ClickAction OnClick;

    public delegate void EnterAction(PointerEventData eventData);
    public event EnterAction OnEnter;

    public delegate void ExitAction(PointerEventData eventData);
    public event ExitAction OnExit;

    public delegate void PointerDownAction(PointerEventData eventData);
    public event PointerDownAction OnDown;

    public delegate void PointerUpAction(PointerEventData eventData);
    public event PointerUpAction OnUp;

    public delegate void TooltipAction(bool show);
    public event TooltipAction OnTooltip;

    void Awake()
    {
        //scrollRect = CustomUtils.GetComponentInParents<ScrollRect>(transform.parent);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (OnClick != null)
            OnClick(eventData);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (OnEnter != null)
            OnEnter(eventData);

        if (OnTooltip != null)
            OnTooltip(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (OnExit != null)
            OnExit(eventData);

        if (OnTooltip != null)
            OnTooltip(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (OnDown != null)
        {
            OnDown(eventData);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (OnUp != null)
        {
            OnUp(eventData);
        }
    }

    //public void OnScroll(PointerEventData eventData)
    //{
    //    if (scrollRect != null)
    //    {
    //        scrollRect.OnScroll(eventData);
    //    }
    //}

    public void OnDrag(PointerEventData eventData)
    {

    }
}