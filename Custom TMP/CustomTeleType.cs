using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using UnityEngine.EventSystems;
using System;

public class CustomTeleType : MonoBehaviour, IPointerClickHandler
{

    public Image chatHightlightIcon;
    public TextMeshProUGUI talkerName;
    private float counter;
    //[Range(0, 100)]
    //public int RevealSpeed = 50;

    //private string label01 = "Example <sprite=2> of using <sprite=7> <#ffa000>Graphics Inline</color> <sprite=5> with Text in <font=\"Bangers SDF\" material=\"Bangers SDF - Drop Shadow\">TextMesh<#40a0ff>Pro</color></font><sprite=0> and Unity<sprite=1>";
    //private string label02 = "Example <sprite=2> of using <sprite=7> <#ffa000>Graphics Inline</color> <sprite=5> with Text in <font=\"Bangers SDF\" material=\"Bangers SDF - Drop Shadow\">TextMesh<#40a0ff>Pro</color></font><sprite=0> and Unity<sprite=2>";


    private TextMeshProUGUI m_textMeshPro;


    void Awake()
    {
        // Get Reference to TextMeshPro Component
        m_textMeshPro = GetComponent<TextMeshProUGUI>();
        //m_textMeshPro.text = label01;
        m_textMeshPro.enableWordWrapping = true;
        m_textMeshPro.alignment = TextAlignmentOptions.TopLeft;

        chatHightlightIcon.enabled = false;

        //if (GetComponentInParent(typeof(Canvas)) as Canvas == null)
        //{
        //    GameObject canvas = new GameObject("Canvas", typeof(Canvas));
        //    gameObject.transform.SetParent(canvas.transform);
        //    canvas.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;

        //    // Set RectTransform Size
        //    gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(500, 300);
        //    m_textMeshPro.fontSize = 48;
        //}


    }

    void OnDisable()
    {
        //SoundManager.instance.PlaySound2D("Kraken Spawn", Vector3.zero);
    }

    public void refresh()
    {
        StartCoroutine(Start());
    }

    void Update()
    {
        if (m_textMeshPro.maxVisibleCharacters == m_textMeshPro.textInfo.characterCount) // if all the letters are on the screen already
        {
            counter -= Time.deltaTime;

            if (counter <= 0)
            {
                highlightIconBehavior();
                counter = 0.5f;
            }
        }
    }

    private void highlightIconBehavior()
    {
        chatHightlightIcon.enabled = !chatHightlightIcon.enabled;
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (m_textMeshPro.maxVisibleCharacters == m_textMeshPro.textInfo.characterCount)
        {
            transform.parent.gameObject.SetActive(false);
        }
        m_textMeshPro.maxVisibleCharacters = m_textMeshPro.textInfo.characterCount;
        StopAllCoroutines();
    }

    IEnumerator Start()
    {
        chatHightlightIcon.enabled = false;
        // Force and update of the mesh to get valid information.
        m_textMeshPro.ForceMeshUpdate();


        int totalVisibleCharacters = m_textMeshPro.textInfo.characterCount; // Get # of Visible Character in text object
        int counter = 0;
        int visibleCount = 0;

        while (true)
        {
            visibleCount = counter % (totalVisibleCharacters + 1);

            m_textMeshPro.maxVisibleCharacters = visibleCount; // How many characters should TextMeshPro display?
            totalVisibleCharacters = m_textMeshPro.textInfo.characterCount; // <-- Should be on While?

            // Once the last character has been revealed, wait 1.0 second and start over.
            if (visibleCount >= totalVisibleCharacters)
            {
                yield return new WaitForSeconds(1.0f);
                //m_textMeshPro.text = "Your father asked me to go over some of the basics with you to help you get started.";
                counter = 0;
                //visibleCount = 0;
                //m_textMeshPro.maxVisibleCharacters = visibleCount;
                //yield return new WaitForSeconds(1.0f);
                StopAllCoroutines();   //<-- should be uncommented
                //m_textMeshPro.text = label01;
                //yield return new WaitForSeconds(1.0f);
            }

            if (m_textMeshPro.text[counter] != ' ')
            {
                SoundManager.instance.PlaySoundPitchless2D("Chat Text", Vector3.zero);
            }

            counter += 1;
            yield return new WaitForSeconds(0.04f);
        }

        //Debug.Log("Done revealing the text.");
    }

}