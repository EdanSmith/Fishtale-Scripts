using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour {

    private float inventoryWindowOriginalPosY;
    private bool moveDown;
    private bool moveUp;
    private float inventoryHeight;
    private float resolutionY;

    void Start()
    {
        resolutionY = UIGameManager.instance.mainCanvas.GetComponent<CanvasScaler>().referenceResolution.y / 2; // Gets the relative Y position so the UI Slide animation work with the Canvas Scaler with premade resolution set
        inventoryWindowOriginalPosY = UIGameManager.instance.inventoryWindow.GetComponent<RectTransform>().rect.height - (resolutionY + 155f);
        inventoryHeight = UIGameManager.instance.inventoryWindow.GetComponent<RectTransform>().rect.height;
    }

	public void hideInventory()
    {
        if (UIGameManager.instance.inventoryWindow.GetComponent<RectTransform>().localPosition.y == inventoryWindowOriginalPosY)
        {
            moveDown = true;
            moveUp = false;
            GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/HUD/InventoryArrowUp");
        }
        else
        {
            moveUp = true;
            moveDown = false;
            GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/HUD/InventoryArrowDown");
        }
    }

    void Update()
    {
        if (moveDown)
        {
            UIGameManager.instance.inventoryWindow.GetComponent<RectTransform>().localPosition = Vector2.MoveTowards(UIGameManager.instance.inventoryWindow.GetComponent<RectTransform>().localPosition,
   new Vector2(UIGameManager.instance.inventoryWindow.GetComponent<RectTransform>().localPosition.x, -inventoryHeight - (resolutionY - 155f)), 750f * Time.deltaTime);
            if (UIGameManager.instance.inventoryWindow.GetComponent<RectTransform>().localPosition.y == -inventoryHeight - (resolutionY - 155f))
            {
                moveDown = false;
            }
        }else if (moveUp)
        {
            UIGameManager.instance.inventoryWindow.GetComponent<RectTransform>().localPosition = Vector2.MoveTowards(UIGameManager.instance.inventoryWindow.GetComponent<RectTransform>().localPosition,
    new Vector2(UIGameManager.instance.inventoryWindow.GetComponent<RectTransform>().localPosition.x, inventoryWindowOriginalPosY), 750f * Time.deltaTime);
            if (UIGameManager.instance.inventoryWindow.GetComponent<RectTransform>().localPosition.y == inventoryWindowOriginalPosY)
            {
                moveUp = false;
            }
        }
    }
}
