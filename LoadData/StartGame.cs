using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LitJson;
using System.IO;

public class StartGame : MonoBehaviour {

    public void startGame()
    {
        CharCustomManager ccm = CharCustomManager.instance;

        ccm.playerCustomization.characterName = ccm.characterName.text.Replace("\u200B", "");
        ccm.playerCustomization.bodyTypeId = ccm.baseBodyTypes[ccm.characterCustomButton.currentBodyType].id;
        ccm.playerCustomization.eyebrowsId = ccm.baseEyebrows[ccm.characterCustomButton.currentEyebrows].id;
        ccm.playerCustomization.eyesId = ccm.baseEyes[ccm.characterCustomButton.currentEyes].id;
        ccm.playerCustomization.hairId = ccm.baseHairs[ccm.characterCustomButton.currentHair].id;
        ccm.playerCustomization.mouthId = ccm.baseMouths[ccm.characterCustomButton.currentMouth].id;
        ccm.playerCustomization.pantsId = ccm.basePants[ccm.characterCustomButton.currentPants].id;
        ccm.playerCustomization.shirtId = ccm.baseShirts[ccm.characterCustomButton.currentShirt].id;
        ccm.playerCustomization.shoesId = ccm.baseShoes[ccm.characterCustomButton.currentShoes].id;

        File.WriteAllText(Application.dataPath + "/StreamingAssets/PlayerCustomization.json", JsonMapper.ToJson(CharCustomManager.instance.playerCustomization));
        SceneManager.LoadScene("MainScene");
    }
}
