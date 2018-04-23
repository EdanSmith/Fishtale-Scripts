using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using LitJson;
using System.IO;
using System.Collections.Generic;       //Allows us to use Lists. 
using TMPro;

public class CharCustomManager : MonoBehaviour
{

    public static CharCustomManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.

    private JsonData playerData;

    public PlayerCustomization playerCustomization;

    public TextMeshProUGUI characterName;
    public CharacterCustomButton characterCustomButton;

    public CharacterCustomizationWindow charCustomWindow;
    public BodyPartsImage bodyPartsImage;
    public BodyPartsSprite bodyPartsSprite;

    public List<HairData> baseHairs = new List<HairData>();
    public List<ShirtData> baseShirts = new List<ShirtData>();
    public List<PantsData> basePants = new List<PantsData>();
    public List<BodyTypeData> baseBodyTypes = new List<BodyTypeData>();
    public List<EyebrowsData> baseEyebrows = new List<EyebrowsData>();
    public List<EyesData> baseEyes = new List<EyesData>();
    public List<MouthData> baseMouths = new List<MouthData>();
    public List<ShoesData> baseShoes = new List<ShoesData>();

    //Awake is always called before any Start functions
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        playerCustomization = new PlayerCustomization();

        baseHairs.AddRange(Resources.LoadAll<HairData>("Body Customization Data/Hair Data"));
        baseShirts.AddRange(Resources.LoadAll<ShirtData>("Body Customization Data/Shirt Data"));
        basePants.AddRange(Resources.LoadAll<PantsData>("Body Customization Data/Pants Data"));

        baseBodyTypes.AddRange(Resources.LoadAll<BodyTypeData>("Body Customization Data/Body Type Data"));
        baseEyebrows.AddRange(Resources.LoadAll<EyebrowsData>("Body Customization Data/Eyebrows Data"));
        baseEyes.AddRange(Resources.LoadAll<EyesData>("Body Customization Data/Eyes Data"));
        baseMouths.AddRange(Resources.LoadAll<MouthData>("Body Customization Data/Mouth Data"));
        baseShoes.AddRange(Resources.LoadAll<ShoesData>("Body Customization Data/Shoes Data"));
    }
    //transform.SetSiblingIndex to change the Image display order

    public HairData GetHairDataById(string id)
    {
        return baseHairs.Find(x => x.id == id);
    }

    public ShirtData GetShirtDataById(string id)
    {
        return baseShirts.Find(x => x.id == id);
    }

    public PantsData GetPantsDataById(string id)
    {
        return basePants.Find(x => x.id == id);
    }

    public BodyTypeData GetBodyTypeDataById(string id)
    {
        return baseBodyTypes.Find(x => x.id == id);
    }

    public EyebrowsData GetEyebrowsDataById(string id)
    {
        return baseEyebrows.Find(x => x.id == id);
    }

    public EyesData GetEyesDataById(string id)
    {
        return baseEyes.Find(x => x.id == id);
    }

    public MouthData GetMouthDataById(string id)
    {
        return baseMouths.Find(x => x.id == id);
    }

    public ShoesData GetShoesDataById(string id)
    {
        return baseShoes.Find(x => x.id == id);
    }
}