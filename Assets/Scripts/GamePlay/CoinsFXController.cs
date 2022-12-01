using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsFXController : MonoBehaviour
{
    private Animator anim;
    [SerializeField]
    private GameObject shiny;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(GameManager.instance.coinactive && !shiny.activeSelf)
        {
            shiny.SetActive(true);
        }
        else if(!GameManager.instance.coinactive && shiny.activeSelf)
        {
            shiny.SetActive(false);
        }

        if(GameManager.instance.dubCTimer > GameManager.instance.maxDubCTime * 0.6)
        {
            anim.SetBool("Ending", true);
        }
        else if(anim.GetBool("Ending") == true)
        {
            anim.SetBool("Ending", false);
        }
    }
}
