using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    public Texture2D srcTexture;
    Texture2D newTexture;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        newTexture = new Texture2D(srcTexture.width, srcTexture.height);
        Color[] colors = srcTexture.GetPixels();
        newTexture.SetPixels(colors);
        newTexture.Apply();
        sr.sprite = Sprite.Create(newTexture, new Rect(0, 0, newTexture.width, newTexture.height), Vector2.one * 0.5f);

        gameObject.AddComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
