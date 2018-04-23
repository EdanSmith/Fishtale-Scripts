using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineScript : MonoBehaviour
{

    public Vector2 destiny;
    public float speed;
    private LineRenderer lineRenderer;
    private PlayerMove player;
    private Color32 color;
    private int currentAlpha;
    private Vector2 hookPos;

    // Use this for initialization
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = true;
        lineRenderer.useWorldSpace = true;
        lineRenderer.sortingLayerName = "LineRenderer";
        color = GetComponent<SpriteRenderer>().color;
        currentAlpha = 255;

        GameManager.instance.hook = this;
        player = GameManager.instance.playerMovement;
        transform.rotation = Quaternion.AngleAxis(0f, Vector3.zero);
        if (ItemManager.instance.GetItemDataById(GameManager.instance.player.equippedItem[(int)Equipment_Slot.Lure]) != null)
        {
            GetComponent<SpriteRenderer>().sprite = ItemManager.instance.GetItemDataById(GameManager.instance.player.equippedItem[(int)Equipment_Slot.Lure]).lureIcon;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = ItemManager.instance.GetItemDataById("default_lure").lureIcon;
        }
        hookPos = GameManager.instance.hook.transform.position;
        Vector2 direction = ((Vector2)player.transform.position - (Vector2)hookPos).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.AngleAxis(angle, new Vector3(0, 0, 1));
        transform.rotation = targetRotation;//Quaternion.RotateTowards(transform.rotation, targetRotation, 75f * Time.deltaTime);
        //UIGameManager.instance.mainCameraLocation = transform;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up);
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, GameManager.instance.playerMovement.bodyPartsSprite.getRodTipDirectionPos(GameManager.instance.playerMovement.playerDirection));

        if (Input.GetKey(KeyCode.I))
        {
            lineRenderer.enabled = true;
        }
        if (Input.GetKey(KeyCode.O))
        {
            lineRenderer.enabled = false;
        }

        if (GameManager.instance.playerMovement.GetComponent<Animator>().GetBool("PlayerCasting"))
        {
            GameManager.instance.playerMovement.GetComponent<PlayerAnimation>().lureLayer(5);
            color.a = 255;
        }
        else if (GameManager.instance.playerMovement.GetComponent<Animator>().GetBool("HookOnWater"))
        {
            GameManager.instance.playerMovement.GetComponent<PlayerAnimation>().lureLayer(2);
            if (color.a > 0)
            {
                color.a--;
            }
        }
        else
        {
            GameManager.instance.playerMovement.GetComponent<PlayerAnimation>().lureLayer(0);
            color.a = 255;
        }

        GetComponent<SpriteRenderer>().color = color;


    }

    public void refresh()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, GameManager.instance.playerMovement.bodyPartsSprite.getRodTipDirectionPos(GameManager.instance.playerMovement.playerDirection));
        lineRenderer.startColor = new Color32(255, 255, 255, 10);
        lineRenderer.endColor = new Color32(255, 255, 255, 10);
        transform.position = GameManager.instance.playerMovement.bodyPartsSprite.getRodTipDirectionPos(GameManager.instance.playerMovement.playerDirection);
        Start();
    }

    public void setLineColor(byte r, byte g, byte b, byte a)
    {
        lineRenderer.startColor = new Color32(r, g, b, a);
        lineRenderer.endColor = new Color32(r, g, b, a);
    }
}
