using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EqPanel : MonoBehaviour
{

    private TextMeshProUGUI maxDataCharacter;
    private TextMeshProUGUI maxLabelCharacter;
    private float maxDataWidth;
    public RectTransform columnName;
    public RectTransform columnSpecification;

    [System.Serializable]
    public struct EqDataEntry
    {
        public TextMeshProUGUI label;
        public TextMeshProUGUI data;
        public ItemStarInfo stars;
        //public float height;
    }

    //A child obj, scaled to keep the background behind them data
    [SerializeField]
    Vector3 offset;
    [SerializeField]
    GameObject background;
    [SerializeField]
    EqDataEntry[] texts;

    void LateUpdate()
    {
        //gameObject.transform.position = new Vector2(Input.mousePosition.x + 100f, Input.mousePosition.y + 160f);
        if (Input.mousePosition.y > Screen.height / 2)
        {
            gameObject.transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y - ((Screen.height / 100) * 3));
            GetComponent<RectTransform>().pivot = new Vector2(0f, 1);
        }
        else
        {
            gameObject.transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y + ((Screen.height / 100) * 3));
            GetComponent<RectTransform>().pivot = new Vector2(0f, 0);
        }
    }

    public void ActivatePanel(IEquipmentDataProvider eq)
    {
        maxDataCharacter = new TextMeshProUGUI();
        maxLabelCharacter = new TextMeshProUGUI();
        maxDataCharacter.text = "";
        maxLabelCharacter.text = "";

        gameObject.SetActive(true);
        //transform.position = (eq as MonoBehaviour).transform.position;
        foreach (EqDataEntry t in texts)
        {
            t.label.gameObject.SetActive(false);
            t.data.gameObject.SetActive(false);
            t.stars.gameObject.SetActive(false);
        }
        int i = 0;
        float scale = 0f;
        EquipmentData[] data = eq.GetEquipmentData();
        RectTransform rt = gameObject.GetComponent<RectTransform>();
        foreach (EquipmentData d in data)
        {
            if (i >= texts.Length) break;
            if (i >= data.Length) break;
            texts[i].label.gameObject.SetActive(true);
            texts[i].data.gameObject.SetActive(true);
            texts[i].stars.gameObject.SetActive(true);
            texts[i].label.text = d.label;
            texts[i].data.text = d._value;
            if(i != 0)
                texts[i].label.GetComponent<TextMeshProUGUI>().alignment = TextAlignmentOptions.Left;
            //scale += texts[i].height;
            if (maxLabelCharacter.text != "") // This if is necessary because it gives an error if maxLabelCharacter has no reference
            {
                if (maxLabelCharacter.preferredWidth < texts[i].label.preferredWidth && i != data.Length - 1) // && i != data.Length - 1 IS AN ITEM DESCRIPTION DERPYNESS ALSO
                    maxLabelCharacter = texts[i].label;
            }else
            {
                if (maxLabelCharacter.text.Length < texts[i].label.text.Length && i != data.Length - 1) // && i != data.Length - 1 IS AN ITEM DESCRIPTION DERPYNESS ALSO
                    maxLabelCharacter = texts[i].label;
            }
            if (maxDataCharacter.text.Length < texts[i].data.text.Length)
            {
                maxDataCharacter = texts[i].data;
                if (maxDataCharacter.preferredWidth > 100) // 100 = stars width * 5
                    maxDataWidth = maxDataCharacter.preferredWidth;
                else
                    maxDataWidth = 100;
            }

            for (int k = 0; k < texts[i].stars.star.Count; k++)
            { // Setting all the stars to be black and enabling them all because of the description derpyness
                texts[i].stars.star[k].color = new Color32(0, 0, 0, 255);
                texts[i].stars.star[k].enabled = true;
            }
            for (int l = 0; l < d._starAmount; l++) // Based on the quality of the weapon, setting the stars to be golden
                texts[i].stars.star[l].color = new Color32(255, 255, 255, 255);
            i++;
        }

        int j = 0;
        foreach (EquipmentData d in data)
        {
            texts[j].label.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(maxLabelCharacter.preferredWidth + 30, texts[j].label.GetComponent<RectTransform>().sizeDelta.y);
            texts[j].data.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(maxDataCharacter.preferredWidth + 30, texts[j].data.GetComponent<RectTransform>().sizeDelta.y);
            j++;
        }

        for (int l = 0; l < texts[i - 1].stars.star.Count; l++) // disabling them all because of the description derpyness
            texts[i - 1].stars.star[l].enabled = false;

        texts[i - 1].label.GetComponent<TextMeshProUGUI>().alignment = TextAlignmentOptions.TopLeft; // Item Description Derpyness
        texts[i - 1].label.GetComponent<RectTransform>().sizeDelta = new Vector2(maxLabelCharacter.preferredWidth + maxDataWidth + 40, texts[i - 1].label.GetComponent<RectTransform>().sizeDelta.y); // Item Description Derpyness
        float descriptionHeight = texts[i - 1].label.GetComponent<TextMeshProUGUI>().preferredHeight; // getting the total height of the description derpyness field

        columnName.sizeDelta = new Vector2(maxLabelCharacter.preferredWidth + 30, (data.Length * 20) + descriptionHeight - 20); // preferredHeight was bugging for some reason || 20 = each line height
        columnSpecification.sizeDelta = new Vector2(maxDataWidth + 30, data.Length * 20);
        Vector2 totalSize = new Vector2(columnName.sizeDelta.x + columnSpecification.sizeDelta.x, columnName.sizeDelta.y + 20);
        texts[0].label.GetComponent<RectTransform>().sizeDelta = new Vector2(totalSize.x - 30, texts[0].label.GetComponent<RectTransform>().rect.height); // Item Name derpiness to stay in the center
        rt.sizeDelta = totalSize;
        //gameObject.transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y + (columnName.sizeDelta.y / 1.5f) + 25f);
        //gameObject.GetComponent<GridLayoutGroup>().cellSize = new Vector2(rt.sizeDelta.x / 2, gameObject.GetComponent<GridLayoutGroup>().cellSize.y);
        //background.transform.localScale = new Vector3(background.transform.localScale.x, scale, background.transform.localScale.z);
    }

    public void DeactivatePanel()
    {
        gameObject.SetActive(false);
    }

}