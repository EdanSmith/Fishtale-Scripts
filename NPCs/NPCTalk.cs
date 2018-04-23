using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NPCTalk : MonoBehaviour, IInteractable, IPointerEnterHandler, IPointerExitHandler {

    public float playerDistance;
    public string npcChatText;
    public string npcName;
    private UIGameManager ui;

    // Use this for initialization
    void Start () {
        ui = UIGameManager.instance;
    }
	
	// Update is called once per frame
	void Update () {
        playerDistance = Vector3.Distance(transform.position, GameManager.instance.playerMovement.transform.position);
    }

    public void Interact()
    {
        playerDistance = Vector3.Distance(transform.position, GameManager.instance.playerMovement.transform.position);

        if (!ui.chatWindow.gameObject.activeSelf)
        {
            GameManager.instance.npcCurrentInteraction = this; // set which npc is the current being interacted
            UIGameManager.instance.portraitCamera.GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y, -10); // set the portrait camera position
            UIGameManager.instance.chatText.GetComponent<CustomTeleType>().talkerName.text = npcName; // Add the NPC name to the chat text area
            if (npcChatText.Length == 0)
                UIGameManager.instance.chatText.text = "What am I supposed to say?";
            else
                UIGameManager.instance.chatText.text = npcChatText;

            if (playerDistance < GameManager.instance.minDistanceToInteractNpc)
            {
                ui.chatWindow.gameObject.SetActive(true);
                ui.chatText.GetComponent<CustomTeleType>().refresh();
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ui.interactionIcon.gameObject.SetActive(true);
        UIGameManager.instance.SetInteractable(this);
        ui.npcMouseOverLocation = transform;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UIGameManager.instance.SetInteractable(null);
        ui.interactionIcon.gameObject.SetActive(false);
    }
}
