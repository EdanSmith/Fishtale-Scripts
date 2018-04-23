using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    //public int id;
    //public string itemId;
    //public string type;
    public ItemData item;
    public bool unlocked;
    public GameObject equippedItemMark;
    public TextMeshProUGUI quantity;
    public Image itemImage;

	void Start () {
            itemImage.enabled = false;
        if (GetComponent<Button>() != null)
            GetComponent<Button>().enabled = false;

        //if (!unlocked)
        //{
        //    GetComponent<Image>().enabled = false;
        //    GetComponent<Button>().enabled = false;
        //}else
        //{
        //    GetComponent<Image>().enabled = true;
        //    GetComponent<Button>().enabled = true;
        //}
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        UIGameManager.instance.eqPanel.ActivatePanel(new DisplayItemInfo(item));
        //userClickedOnItem.GetComponent<IEquipmentDataProvider>()
        Debug.Log("Bait");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Tooltip.Instance.HideTip();
        UIGameManager.instance.eqPanel.DeactivatePanel();
    }

}
