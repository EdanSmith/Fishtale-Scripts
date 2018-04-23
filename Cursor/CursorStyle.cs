using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorStyle : MonoBehaviour
{

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    //private float warningThrowRange;
    //private float warningThrowRangeAux;
    //private float mousePlayerDistance;
    //private int throwWarningPercentage = 50;

    void Start()
    {
        Cursor.SetCursor(getTexture2DArea(cursorTexture, 0, 0, 26, 31), hotSpot, cursorMode);
    }

    // Update is called once per frame
    void Update()
    {
        //mousePlayerDistance = Vector3.Distance(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition)) - 10f;
        //ThrowHookMarker thm = new ThrowHookMarker();

        //warningThrowRange = (thm.getMaxThrowRange() / 100) * throwWarningPercentage; // 0 to warningPercentage
        //warningThrowRangeAux = (thm.getMaxThrowRange() / 100) * (100 - throwWarningPercentage); // warningPercentage to 100

        //if (mousePlayerDistance <= thm.getMaxThrowRange() - warningThrowRangeAux) // -10 so it starts at 0
        //    Cursor.SetCursor(getTexture2DArea(cursorTexture, 0, 32, 16, 16), hotSpot, cursorMode);
        //else if(mousePlayerDistance > warningThrowRange && mousePlayerDistance <= thm.getMaxThrowRange())
        //    Cursor.SetCursor(getTexture2DArea(cursorTexture, 0, 16, 16, 16), hotSpot, cursorMode);
        //else
        //    Cursor.SetCursor(getTexture2DArea(cursorTexture, 0, 0, 16, 16), hotSpot, cursorMode);

    }

    public Texture2D getTexture2DArea(Texture2D texture, int x, int y, int width, int height)
    {
        Color[] pix = texture.GetPixels(x, y, width, height);
        Texture2D textureArea = new Texture2D(width, height);
        textureArea.SetPixels(pix);
        textureArea.Apply();
        return textureArea;
    }
}
