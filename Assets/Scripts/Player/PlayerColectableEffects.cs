using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColectableEffects : MonoBehaviour
{
    private string COIN_TAG = "Coin";
    private string DOUBLEP_TAG = "DoubleP";
    private string DOUBLEC_TAG = "DoubleC";
    private string INVENCIBLE_TAG = "Invencible";

    public Player player;

    private void Start()
    {
        player = this.gameObject.GetComponent<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Coins
        if (collision.gameObject.CompareTag(COIN_TAG))
        {
            if (GameManager.instance.coinactive)
            {
                GameManager.instance.coins += GameManager.instance.dubCoins;
            }
            else
            {
                GameManager.instance.coins += 1;
            }
            AudioManager.Instance.Play(AudioManager.Instance.sfx[0]);
        }

        //Double Points
        if (collision.gameObject.CompareTag(DOUBLEP_TAG))
        {
            GameManager.instance.dubPTimer = 0;
            GameManager.instance.pointactive = true;
            AudioManager.Instance.Play(AudioManager.Instance.sfx[1]);
        }

        //Double Coins
        if (collision.gameObject.CompareTag(DOUBLEC_TAG))
        {
            GameManager.instance.dubCTimer = 0;
            GameManager.instance.coinactive = true;
            AudioManager.Instance.Play(AudioManager.Instance.sfx[1]);
        }

        //Invencible
        if (collision.gameObject.CompareTag(INVENCIBLE_TAG))
        {
            GameManager.instance.invencible = true;
            GameManager.instance.invTimer = 0;
            GameManager.instance.invactive = true;
            AudioManager.Instance.Play(AudioManager.Instance.sfx[1]);
        }
    }

    private void Update()
    {
        if(GameManager.instance.pointactive)
            DoublePoints();

        if(GameManager.instance.coinactive)
            DoubleCoins();

        if(GameManager.instance.invactive)
            ActiveInv();
    }

    void DoublePoints()
    {
        //Points
        if (GameManager.instance.dubPTimer < GameManager.instance.maxDubTime)
        {
            GameManager.instance.PointstimeEffects();
            GameManager.instance.dubPTimer += Time.deltaTime;
        }
        else if (GameManager.instance.dubPTimer >= GameManager.instance.maxDubTime)
        {
            GameManager.instance.dubPTimer = 0;
            GameManager.instance.dubPoints = 1;
            GameManager.instance.pointactive = false;
        }
    }

    void DoubleCoins()
    {
        //Coins
        if (GameManager.instance.dubCTimer < GameManager.instance.maxDubCTime)
        {
            GameManager.instance.CoinstimeEffects();
            GameManager.instance.dubCTimer += Time.deltaTime;
        }
        else if (GameManager.instance.dubCTimer >= GameManager.instance.maxDubCTime)
        {
            GameManager.instance.dubCTimer = 0;
            GameManager.instance.dubCoins = 1;
            GameManager.instance.coinactive = false;
        }
    }

    void ActiveInv()
    {
        //Invencible
        if (GameManager.instance.invTimer < GameManager.instance.maxInvTimer)
        {
            GameManager.instance.InvtimeEffects();
            GameManager.instance.invencible = true;
            GameManager.instance.invTimer += Time.deltaTime;
        }
        else if (GameManager.instance.invTimer >= GameManager.instance.maxInvTimer)
        {
            GameManager.instance.invTimer = 0;
            GameManager.instance.invencible = false;
            GameManager.instance.invactive = false;
        }
    }
}
