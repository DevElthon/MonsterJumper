using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField]
    CameraFollow mainCam;

    [SerializeField]
    private Sprite[] bgSprites, bgSkySprites, tileSprites, tile2Sprites, moons;

    [SerializeField]
    GameObject[] monsterSpawner, Torch;

    [SerializeField]
    private SpriteRenderer bgSpriteRenderer, bgSkySpriteRenderer, tileSpriteRenderer, tiledowngroundSpriteRenderer, moonSpriteRenderer;
    void Awake()
    {
        for (int i = 0; i < monsterSpawner.Length; i++)
        {
            if (i == PlayerPrefs.GetInt("BackgroundActive"))
            {
                monsterSpawner[i].SetActive(true);
                Torch[i].SetActive(true);
            }
            else
            {
                monsterSpawner[i].SetActive(false);
                Torch[i].SetActive(false);
            }
        }
        moonSpriteRenderer.sprite = moons[PlayerPrefs.GetInt("BackgroundActive")];
        bgSpriteRenderer.sprite = bgSprites[PlayerPrefs.GetInt("BackgroundActive")];
        tileSpriteRenderer.sprite = tileSprites[PlayerPrefs.GetInt("BackgroundActive")];
        tiledowngroundSpriteRenderer.sprite = tile2Sprites[PlayerPrefs.GetInt("BackgroundActive")];
        bgSkySpriteRenderer.sprite = bgSkySprites[PlayerPrefs.GetInt("BackgroundActive")];
    }
} 