using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class LayerHandler : MonoBehaviour {

    public int adjustmentNumber = 0;
    private SortingGroup sortingGroup;
    private int originalSortingOrder;
    private int validateLayer;

    void Start()
    {
        sortingGroup = gameObject.GetComponent<SortingGroup>();
        originalSortingOrder = sortingGroup.sortingOrder;
    }

    void LateUpdate()
    {
        //spriteRenderer.sortingOrder = ((((int)Camera.main.WorldToScreenPoint(spriteRenderer.bounds.min).y * -1) + originalSortingOrder) + Screen.height / 2) + adjustmentNumber;
        ////if ((int)Camera.main.WorldToScreenPoint(spriteRenderer.bounds.min).y * -1 <= 2){
        ////    spriteRenderer.sortingOrder = 2 + originalSortingOrder;
        ////}
        //if (spriteRenderer.sortingOrder < originalSortingOrder)
        //{
        //    spriteRenderer.sortingOrder = originalSortingOrder;
        //}

        sortingGroup.sortingOrder = (Mathf.FloorToInt(transform.position.y * 10f) * -1) + adjustmentNumber;
    }
}
// Also, make it treat the sorting group instead of the sprite renderer. If you need to turn things alpha, just add a field for the Sprite Renderer(s) that are inside
// Add validation if the player is near, so it won't fuck up the performance