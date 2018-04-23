using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using NodeCanvas.DialogueTrees;

using System.Collections.Generic;       //Allows us to use Lists. 
using UnityEngine.EventSystems;

public class UIGameManager : MonoBehaviour
{

    public static UIGameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
    //Awake is always called before any Start functions
    public MainCanvas mainCanvas;
    public Slider lineLengthBar;
    public CoolerSpace coolerSpace;
    //public FillLineLengthBarColor fillColor;
    public Camera mainCamera;
    public Transform mainCameraLocation;
    public Transform portraitCamera;

    public UIItemFish selectedFish;

    public ItemSpecificationWindow itemSpecificationWindow;
    public ObtainedItemWindow obtainedItemWindow;
    public Gold goldPanel;
    public InventoryWindow inventoryWindow;
    public CoolerInventoryWindow animatedInventoryWindow;
    public EquippedItemsWindow equippedItemsWindow;
    public AnimatedInventoryButton animatedInventoryButton;
    public ShopWindow shopWindow;
    public EqPanel eqPanel;
    public IInteractable currentInteractable;
    public Image interactionIcon;
    public Transform animatedInventorySpot; // So I can instantiate the animated inventory on an specific place
    public Catalog catalog;
    public Image vacuumSkillImage;
    public Image lightningBoltSkillImage;
    public Image skillPanel;
    public UIFishBarAnimator uiFishBarAnimator;
    public Image chatWindow;
    public TextMeshProUGUI chatText;
    public Transform npcMouseOverLocation;
    public UpgradeHouseButton upgradeHouseButton;
    public DialogueTreeController dialogue;

    public List<GameObject> menuButton; //TEMPORARY
    public GameObject test;

    private GameObject itemFishObject;
    private float playerDistance;
    private Color32 curColor;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        npcMouseOverLocation = transform; // so it starts as something... just a simple work around
    }

    void Update()
    {
        if (Input.GetMouseButton(1)) // For the interaction interface stuff
        {
            if (currentInteractable != null)
                currentInteractable.Interact();
        }

        if (interactionIcon.gameObject.activeSelf)
            //interactionIcon.transform.position = mainCamera.WorldToScreenPoint(new Vector2(npcMouseOverLocation.position.x + 0.5f, npcMouseOverLocation.position.y + 1f)); // Stays static on the screen
            interactionIcon.transform.position = new Vector2(Input.mousePosition.x + 40f, Input.mousePosition.y - 30f);

        playerDistance = Vector3.Distance(npcMouseOverLocation.position, GameManager.instance.playerMovement.transform.position);
        curColor = interactionIcon.color;

        if (playerDistance < GameManager.instance.minDistanceToInteractNpc)
        {
            curColor.a = 255;
            interactionIcon.GetComponent<UIImageAnimator>().enabled = true;
        }
        else
        {
            curColor.a = 128;
            interactionIcon.GetComponent<UIImageAnimator>().enabled = false;
            interactionIcon.sprite = interactionIcon.GetComponent<UIImageAnimator>().staticImage;
        }

        interactionIcon.color = curColor;

        if (Input.GetKeyDown(KeyCode.C))
        {
            mainCanvas.gameObject.SetActive(!mainCanvas.gameObject.activeSelf);
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            for(int i = 0; i < menuButton.Count; i++)
            {
                menuButton[i].SetActive(!menuButton[i].activeSelf);
            }

            foreach(UITranslator uiTrans in mainCanvas.GetComponentsInChildren<UITranslator>(true))
            {
                TranslatorManager.instance.translatedLabel.Add(uiTrans.gameObject);
            }

            foreach (GameObject uiTranslator in TranslatorManager.instance.translatedLabel)
            {
                uiTranslator.GetComponent<UITranslator>().Refresh();
            }
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            upgradeHouseButton.upgradePlayerHouse();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dialogue.StartDialogue();
        }
    }

    public void addItemFishToPlayerInventory(ItemFish itemFish)
    {
        itemFishObject = (GameObject)Instantiate(Resources.Load("Prefabs/ItemFish")); // gets the prefab
        itemFishObject.transform.SetParent(UIGameManager.instance.coolerSpace.transform, false); // set where it will be in the hierarchy
        itemFishObject.GetComponent<RectTransform>().localPosition = Vector2.zero + new Vector2(100, -100); // set the position that the item fish will spawn inside the inventory UI panel
        itemFishObject.GetComponent<UIItemFish>().itemFish = itemFish; // sends the fish attributes stuff
        itemFishObject.GetComponent<RectTransform>().localScale = new Vector2(1f + ((float)itemFish.length / 25), 1f + ((float)itemFish.length / 25));
    }

    public void showObtainedItemWindow(ItemFish itemFish)
    {
        ItemManager.instance.obtainedFish = itemFish;
        obtainedItemWindow.refresh(); // Setting it active on start()
    }

    public void showItemSpecificationWindow()
    {
        if (itemSpecificationWindow.gameObject.activeSelf)
        {
            closeItemSpecificationWindow();
        }
        itemSpecificationWindow.refresh();
        itemSpecificationWindow.gameObject.SetActive(true);
    }

    public void closeItemSpecificationWindow()
    {
        if (itemSpecificationWindow.gameObject.activeSelf)
        {
            itemSpecificationWindow.gameObject.SetActive(false);
        }
    }

    public void updateCurrentGold()
    {
        goldPanel.updateCurrentGold();
    }

    public void unlockItem(ItemData itemData, int quantity = 0)
    {
        InventorySlot inventorySlot = null;
        InventoryWindow inventoryWindow = this.inventoryWindow;
        if (itemData.equipmentSlot == Equipment_Slot.Bait)
        {
            inventorySlot = inventoryWindow.baitSlots[itemData.slotId];
            inventorySlot.itemImage.enabled = true;
            inventorySlot.GetComponent<Button>().enabled = true;
            inventorySlot.GetComponent<InventorySlot>().quantity.text = quantity.ToString();
            inventorySlot.GetComponent<InventorySlot>().quantity.gameObject.SetActive(true);
        }
        else if (itemData.equipmentSlot == Equipment_Slot.Lure)
        {
            inventorySlot = inventoryWindow.lureSlots[itemData.slotId];
            inventorySlot.itemImage.enabled = true;
            inventorySlot.GetComponent<Button>().enabled = true; // Repeated code because upgradable items will work differently... check it out
        }
        else if (itemData.equipmentSlot == Equipment_Slot.Reel)
        {
            inventorySlot = inventoryWindow.reelSlots[itemData.slotId];
            inventorySlot.itemImage.enabled = true;
            inventorySlot.GetComponent<Button>().enabled = true;
        }
        else if (itemData.equipmentSlot == Equipment_Slot.Bag)
        {
            inventorySlot = inventoryWindow.bagSlot;
            inventorySlot.itemImage.enabled = true;
        }
        else if (itemData.equipmentSlot == Equipment_Slot.Rod)
        {
            inventorySlot = inventoryWindow.rodSlot;
            inventorySlot.itemImage.enabled = true;
        }
        //int i = (int)Equipment_Slot.Bag; Example of Enum usage
    }

    public void SetInteractable(IInteractable interactable)
    {
        currentInteractable = interactable;

        //enable hover key above interactable.transform etc
        if (currentInteractable != null)
        {

        }
        else
        {
            //hide interactable icon
        }
    }

}