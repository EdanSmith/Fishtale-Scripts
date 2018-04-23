using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatalogButton : MonoBehaviour
{

    private Catalog catalog;

    void Start()
    {
        catalog = UIGameManager.instance.catalog;
    }

    public void previousPage()
    {
        if (catalog.currentPageGroup == 0)
        {
            return;
        }
        catalog.currentPageGroup -= 1;
        SoundManager.instance.PlaySound2D("PageFlip", GameManager.instance.playerMovement.transform.position);
    }

    public void nextPage()
    {
        if (catalog.currentPageGroup == catalog.catalogPageGroup.Count - 1)
        {
            return;
        }
        catalog.currentPageGroup += 1;
        SoundManager.instance.PlaySound2D("PageFlip", GameManager.instance.playerMovement.transform.position);
    }

    public void showCatalog()
    {
        catalog.refresh();
        catalog.gameObject.SetActive(!catalog.gameObject.activeSelf);
    }
}
