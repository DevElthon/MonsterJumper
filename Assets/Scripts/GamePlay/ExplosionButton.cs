using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionButton : MonoBehaviour
{
    private GameObject player;

    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
        if(player == null){
            return;
        }
    }

    public void Explode(GameObject explosion){
        StartCoroutine(activate_explosion(explosion));
    }

    IEnumerator activate_explosion(GameObject explosion){
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        GameManager.instance.loading_explosion = 0;
        GameManager.instance.invencible = true;
        GameManager.instance.invTimer = 0;
        GameManager.instance.invactive = true;
        yield return new WaitForSeconds(0.1f);
        Instantiate(explosion, player.transform);
        yield return new WaitForSeconds(1f);
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }
}
