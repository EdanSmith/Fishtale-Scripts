using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCQuickTalkWindow : MonoBehaviour
{

    public GameObject quickTalkWindow;
    public bool npcTalks;
    public SpriteRenderer sr;

    void Update() // Temporary to record a scene
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            quickTalkWindow.transform.position = UIGameManager.instance.mainCamera.WorldToScreenPoint(new Vector2(transform.position.x, transform.position.y + sr.sprite.bounds.size.y / 2));
            quickTalkWindow.SetActive(!quickTalkWindow.activeSelf);
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            quickTalkWindow.GetComponentInChildren<TextMeshProUGUI>().text = "Help! Someone, please!";
        }
    }

    void LateUpdate()
    {
        if (quickTalkWindow.activeSelf)
        {
            quickTalkWindow.transform.position = UIGameManager.instance.mainCamera.WorldToScreenPoint(new Vector2(transform.position.x, transform.position.y + sr.sprite.bounds.size.y / 2));
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (npcTalks)
        {
            if (other.gameObject.tag == "Player")
            {
                if (Random.Range(0, 2) < 1) // Chance of showing up the message
                {
                    quickTalkWindow.transform.position = UIGameManager.instance.mainCamera.WorldToScreenPoint(new Vector2(transform.position.x, transform.position.y + sr.sprite.bounds.size.y / 2));
                    quickTalkWindow.SetActive(true);
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (npcTalks)
        {
            if (other.gameObject.tag == "Player")
            {
                quickTalkWindow.SetActive(false);
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (npcTalks)
        {
            if (other.gameObject.tag == "Player")
            {
                quickTalkWindow.transform.position = UIGameManager.instance.mainCamera.WorldToScreenPoint(new Vector2(transform.position.x, transform.position.y + sr.sprite.bounds.size.y / 2));
            }
        }
    }
}
