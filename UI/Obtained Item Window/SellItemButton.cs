using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SellItemButton : MonoBehaviour
{

    UIItemFish selectedFish;

    public TextMeshProUGUI buttonText;

    public void sellItem()
    {
        quickSingleItemSell();
    }

    private void quickSingleItemSell()
    {
        selectedFish = UIGameManager.instance.selectedFish;
        if (selectedFish != null)
        {
            UIGameManager.instance.closeItemSpecificationWindow();
            GameManager.instance.player.currentGold += ItemManager.instance.sellItemFish(selectedFish);
            UIGameManager.instance.updateCurrentGold();
            GameObject hudCoinEffect = (GameObject)Instantiate(Resources.Load("Prefabs/Particles/HUD Coin Effect"), Vector2.zero, Quaternion.identity);
            hudCoinEffect.transform.SetParent(UIGameManager.instance.goldPanel.goldIcon.transform, false); // set where it will be in the hierarchy

            //GameObject particle = (GameObject)Instantiate(Resources.Load("Prefabs/Particles/Coin From To"), GameManager.instance.merchantNear.transform.position, Quaternion.identity);
            //particle.GetComponent<ParticleAttractor>().origin = GameManager.instance.merchantNear.transform;
            //particle.GetComponent<ParticleAttractor>().destiny = GameManager.instance.playerMovement.transform;
            //particle.GetComponent<ParticleSystem>().trigger.SetCollider(0, GameManager.instance.playerMovement.transform);
        }
    }

    void Update()
    {
        if (GameManager.instance.merchantNear != null)
        {
            GetComponent<Button>().interactable = true;
            buttonText.color = new Color32(255, 255, 0, 255);
        }
        else
        {
            GetComponent<Button>().interactable = false;
            buttonText.color = new Color32(255, 255, 255, 128);
        }
    }
}
