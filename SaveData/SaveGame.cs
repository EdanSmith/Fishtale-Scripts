using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class SaveGame : MonoBehaviour {

    public void saveGame()
    {
        File.WriteAllText(Application.dataPath + "/StreamingAssets/FishRecords.json", JsonMapper.ToJson(GameManager.instance.saveItemData.savedFishRecord));
        File.WriteAllText(Application.dataPath + "/StreamingAssets/Player.json", JsonMapper.ToJson(GameManager.instance.player));
        //File.WriteAllText(Application.dataPath + "/StreamingAssets/ItemsFish.json", JsonMapper.ToJson(GameManager.instance.saveItemData.savedFish)); // Saves all the items on the cooler on a JSON file
        File.WriteAllText(Application.dataPath + "/StreamingAssets/Items.json", JsonMapper.ToJson(GameManager.instance.saveItemData.savedItem)); // Saves all the items on the tackle box on a JSON file
    }
}
