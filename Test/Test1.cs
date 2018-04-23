using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test1 : MonoBehaviour {

    private Texture2D texture;
    private SpriteRenderer npcSprite;

    void Start()
    {
        npcSprite = GetComponent<SpriteRenderer>();
        if (1 == 1)//!string.IsNullOrEmpty(AssetDatabase.GetAssetPath(GetComponent<SpriteRenderer>().sprite.texture)))
        {
            Vector2 p = new Vector2(0.5f, 0.5f);
            //Sprite sprite = Sprite.Create(texture, new Rect(npcSprite.rect.x / 2, npcSprite.rect.y / 2, npcSprite.rect.width / 2, npcSprite.rect.height / 2), p


            // First make a texture large enough to hold the cropped contents
            var t = new Texture2D(204, 1181, npcSprite.sprite.texture.format, npcSprite.sprite.texture.mipmapCount > 1);

            // Then copy in the cropped contents only
            var pixels = npcSprite.sprite.texture.GetPixels(0, 0, 204, 1181);
            t.SetPixels(pixels);

            // Now actually scale the image data
            TextureScale.Point(t, 204, 1181);

            Sprite sprite = Sprite.Create(t, new Rect(13, 649, 86, 164), p);
            npcSprite.sprite = sprite;
        }
    }

    // Update is called once per frame
    void Update () {

    }


//    // First make a texture large enough to hold the cropped contents
//    var t = new Texture2D(inWidth, inHeight, npcSprite.sprite.texture.format npcSprite.sprite.texture.mipmapCount > 1);

//    // Then copy in the cropped contents only
//    var pixels = npcSprite.sprite.texture.GetPixels(cropLeft, cropTop, inWidth, inHeight);
//    t.SetPixels(pixels);

//// Now actually scale the image data
//TextureScale.Bilinear (t, outWidth, Height);
}
