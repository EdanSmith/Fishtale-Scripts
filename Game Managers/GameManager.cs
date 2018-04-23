using UnityEngine;
using System.Collections;
using LitJson;
using System.IO;
using System.Collections.Generic;       //Allows us to use Lists. 
using DigitalRuby.RainMaker;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.

    private JsonData playerData;
    public float minDistanceToInteractNpc;

    public PlayerMove playerMovement;
    public Player player;
    public TargetScript target;
    public LineScript hook;
    public HookMarker hookMarker;
    public ThrowHookMarker throwHookMarker;
    public FishMovement fish;
    public FishDetect fishDetect;
    public Aim aim;
    public HookCooldown hc;
    public MerchantNpc merchantNear;
    public bool fishCaught = false;
    public GameObject playerHouse;
    public Fish currentSpawnedFish;
    public NPCTalk npcCurrentInteraction;
    public FishSpawn currentFishSpawnArea;
    public Clock clock;
    public RainScript2D rain;

    public SaveItemData saveItemData = new SaveItemData();

    public List<FishData> baseFishes = new List<FishData>();

    //Awake is always called before any Start functions
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        baseFishes.AddRange(Resources.LoadAll<FishData>("Fish Data"));

        playerData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Player.json"));
        setPlayerData(playerData);

        minDistanceToInteractNpc = 2f;

        //========== Hook Cooldown ==============
        hc = new HookCooldown();
        hc.hookOnCooldown = false;
        hc.cooldownCountedSeconds = 0;
        hc.hookCooldownTime = 1f; //this value will come from the equipped item

    }

    void Update()
    {
        if (hc.cooldownTimerEnabled)
        {
            hc.startHookCooldownTimer();
        }
    }

    private void setPlayerData(JsonData playerData)
    {
        this.player = new Player(playerData);
    }

    public FishData GetFishDataById(string id)
    {
        return baseFishes.Find(x => x.id == id);
    }

    public GameObject spawnFish(string baseId)
    {
        FishData fishData = this.GetFishDataById(baseId);
        Fish fish = new Fish(fishData);
        this.currentSpawnedFish = fish;
        GameObject fishToSpawn = (GameObject)Instantiate(Resources.Load("Prefabs/Fish"), GameManager.instance.hook.transform.position, Quaternion.identity);
        return fishToSpawn;
    }
}