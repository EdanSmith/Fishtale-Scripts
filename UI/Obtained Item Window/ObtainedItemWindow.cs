using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObtainedItemWindow : MonoBehaviour
{

    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemLength;
    public TextMeshProUGUI itemWeight;
    public TextMeshProUGUI itemRarity;
    public Image itemImage;
    public List<ParticleSystem> particle;
    public TextMeshProUGUI newRecordText;
    public bool newRecord;

    private ItemFish obtainedFish;
    private FishItemData obtainedFishData;

    // Use this for initialization
    void Start()
    {
        obtainedFish = ItemManager.instance.obtainedFish;
        obtainedFishData = ItemManager.instance.GetItemFishDataById(obtainedFish.baseId);

        itemName.text = TranslatorManager.instance.GetTranslationById("fish_name_" + obtainedFishData.id);
        itemLength.text = obtainedFish.length.ToString() + " " + TranslatorManager.instance.GetTranslationById("measurement_inches");
        itemWeight.text = obtainedFish.weight.ToString() + " " + TranslatorManager.instance.GetTranslationById("measurement_pounds");
        itemRarity.text = TranslatorManager.instance.GetTranslationById("rarity_" + obtainedFishData.rarity);
        itemImage.preserveAspect = true;
        itemImage.sprite = obtainedFishData.fishPortraitImage;
        newRecordText.gameObject.SetActive(false);
        gameObject.SetActive(true);
    }

    public void refresh()
    {
        Start();
        for (int i = 0; i < particle.Count; i++) // Deactivate all the particles so it can be re-applied
        {
            particle[i].gameObject.SetActive(false);
        }
        StartCoroutine(delayedStarSpawn(0.6f));
    }

    private IEnumerator delayedStarSpawn(float seconds)
    {
        for (int i = 0; i < obtainedFish.star; i++)
        {
            yield return new WaitForSeconds(seconds);
            particle[i].gameObject.SetActive(true);
            SoundManager.instance.PlaySoundPitchless2D("star" + (i + 1), GameManager.instance.playerMovement.transform.position);
        }
        yield return new WaitForSeconds(seconds);
        if (newRecord)
        {
            newRecordText.gameObject.SetActive(true);
            newRecordText.GetComponent<TMPro.Examples.CustomVertexZoom>().refresh();
            newRecord = false;
            SoundManager.instance.PlaySoundPitchless2D("NewFishRecord", GameManager.instance.playerMovement.transform.position);
        }
    }
}
