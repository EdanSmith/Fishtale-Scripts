using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    private static Tooltip instance;
    public static Tooltip Instance
    {
        get
        {
            return instance;
        }
    }

    public Text tipText;
    private RectTransform rect;

    bool inside;
    bool xShifted = false;
    bool yShifted = false;
    float width;
    float height;
    int screenWidth;
    int screenHeight;
    float yShift;
    float xShift;

    void Awake()
    {
        //ensure only 1 instance running of script
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

        rect = GetComponent<RectTransform>();
        screenWidth = Screen.width;
        screenHeight = Screen.height;
    }

    void FixedUpdate()
    {
        if (gameObject.activeSelf)
        {
            if (inside)
            {
                UpdatePosition();
            }
        }
    }

    public void HideTip()
    {
        xShifted = yShifted = false;
        transform.position = Input.mousePosition - new Vector3(xShift, yShift, 0f);
        inside = false;
        gameObject.SetActive(false);
    }

    public void ShowTip(string info, float maxWidth)
    {
        string tip = info;
        tipText.text = tip;

        UpdateSizePos(maxWidth);

        gameObject.SetActive(true);
    }

    void UpdateSizePos(float maxWidth)
    {
        float newWidth = tipText.preferredWidth;
        if(newWidth > maxWidth)
        {
            newWidth = maxWidth;
        }

        Vector2 newSize = new Vector2(newWidth, tipText.preferredHeight + 25f);

        rect.sizeDelta = newSize;
        width = rect.sizeDelta[0];
        height = rect.sizeDelta[1];
        xShift = newSize.x * .5f;
        yShift = -newSize.y * .5f;

        UpdatePosition();

        inside = true;
    }

    void UpdatePosition()
    {
        //ScreenSpaceOverlay Tooltip
        Vector3 newPos = Input.mousePosition;
        newPos.z = 0f;
        newPos = newPos - new Vector3(xShift, yShift, 0f);
        //check and solve problems for the tooltip that goes out of the screen on the horizontal axis
        float val;

        val = (newPos.x - (width / 2));
        if (val <= 0)
        {
            newPos.x += (-val);
        }

        val = (newPos.x + (width / 2));
        if (val > screenWidth)
        {
            newPos.x -= (val - screenWidth);
        }

        //check and solve problems for the tooltip that goes out of the screen on the vertical axis
        val = (screenHeight - newPos.y - (height / 2));
        if (val <= 0)
        {
            if (!yShifted)
            {
                yShift = (-yShift + 25f);
                newPos.y += yShift * 2;
                yShifted = true;
            }
        }

        transform.position = newPos;
    }
}