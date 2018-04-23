using UnityEngine;
using System.Collections;
using LitJson;
using System.IO;
using System.Collections.Generic;       //Allows us to use Lists. 

public class TranslatorManager : MonoBehaviour
{

    public static TranslatorManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.

    private List<UITranslation> baseUITranslation = new List<UITranslation>();
    private Dictionary<string, UITranslationData> uiTranslation = new Dictionary<string, UITranslationData>();

    public string globalLanguage;

    //public static string CurrentLanguage { get { return instance.globalLanguage; } }


    public List<GameObject> translatedLabel;

    //Awake is always called before any Start functions
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        baseUITranslation.AddRange(Resources.LoadAll<UITranslation>("Translations Data"));

        for (int i = 0; i < baseUITranslation.Count; i++)
        {
            for (int j = 0; j < baseUITranslation[0].dataArray.Length; j++)
            {
                uiTranslation.Add(baseUITranslation[0].dataArray[j].Id, baseUITranslation[0].dataArray[j]);
            }
        }
    }

    public string GetTranslationById(string id)
    {
        try
        {
            if (globalLanguage == "en")
            {
                return uiTranslation[id].En;
            }
            if (globalLanguage == "pt")
            {
                return uiTranslation[id].Pt;
            }
            if (globalLanguage == "es")
            {
                return uiTranslation[id].Es;
            }
            if (globalLanguage == "pl")
            {
                return uiTranslation[id].Pl;
            }
            else
            {
                return uiTranslation[id].En;
            }
        }
        catch (KeyNotFoundException e)
        {
            Debug.LogWarning("The translation ID: *" + id + "* was not found!!");
            return "Translation Not Found.";
        }
    }

    public string GetDialogTranslationById(string id)
    {
        if (globalLanguage == "en")
        {
            return uiTranslation[id].En;
        }
        if (globalLanguage == "pt")
        {
            return uiTranslation[id].Pt;
        }
        if (globalLanguage == "es")
        {
            return uiTranslation[id].Es;
        }
        if (globalLanguage == "pl")
        {
            return uiTranslation[id].Pl;
        }
        else
        {
            return uiTranslation[id].En;
        }

    }

}