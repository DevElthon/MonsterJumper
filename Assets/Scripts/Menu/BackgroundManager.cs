using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField]
    private Sprite[] bgSprites;
    [SerializeField]
    private SpriteRenderer bgSpriteRenderer;
    void Awake()
    {
        bgSpriteRenderer.sprite = bgSprites[1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
