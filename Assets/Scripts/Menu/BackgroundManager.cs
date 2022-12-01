using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField]
    private Sprite[] bgSprites, tileSprites;
    [SerializeField]
    private SpriteRenderer bgSpriteRenderer, tileSpriteRenderer;
    void Awake()
    {
        bgSpriteRenderer.sprite = bgSprites[PlayerPrefs.GetInt("BackgroundActive")];
        tileSpriteRenderer.sprite = tileSprites[PlayerPrefs.GetInt("BackgroundActive")];
    }
    /*
    void Update()
    {
        if(bgSpriteRenderer.sprite != bgSprites[PlayerPrefs.GetInt("BackgroundActive")])
            bgSpriteRenderer.sprite = bgSprites[PlayerPrefs.GetInt("BackgroundActive")];
    }
    */
}