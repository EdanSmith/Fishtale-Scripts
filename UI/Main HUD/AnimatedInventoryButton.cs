using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedInventoryButton : MonoBehaviour {

    void Start()
    {
        UIGameManager.instance.animatedInventoryButton = this;
    }

    public void openAnimatedInventoryWindow()
    {
        UIGameManager.instance.animatedInventoryWindow.gameObject.SetActive(!UIGameManager.instance.animatedInventoryWindow.gameObject.activeSelf);
        UIGameManager.instance.closeItemSpecificationWindow();
        UIGameManager.instance.selectedFish = null;
    }
}
