using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIImageAnimator : MonoBehaviour
{

    public List<Sprite> image;
    public Sprite staticImage;
    private Image currentImage;
    private int index;

    // Use this for initialization
    //void Start()
    //{

    //}

    void OnEnable()
    {
        InvokeRepeating("changeImage", 0, 0.4F);
        currentImage = GetComponent<Image>();
        index = 0;
    }
    void OnDisable()
    {
        CancelInvoke();
    }

    void changeImage()
    {
        if (index >= image.Count)
            index = 0;

        currentImage.sprite = image[index];
        index++;
    }
}
