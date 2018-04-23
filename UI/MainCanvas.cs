using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using UnityEngine.EventSystems;
public class MainCanvas : MonoBehaviour, IPointerClickHandler
{

    private List<ItemFish> fishItemDatabase = new List<ItemFish>();

    private JsonData playerData;

    // Use this for initialization
    void Start()
    {
        UIGameManager.instance.mainCanvas = this;

        //playerData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Player.json"));

    }

    public void OnPointerClick(PointerEventData eventData)
    {

    }

}
