using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    Transform explosion_transform;
    [SerializeField]
    int time_to_destroy = 3;

    private void Awake() {
        explosion_transform = this.transform;
    }

    private void Start(){
        StartCoroutine(EndExplosion());
    }
    
    public void ActivateExplosion(){
        explosion_transform.localScale = new Vector3(explosion_transform.localScale.x + 20 * Time.deltaTime, explosion_transform.localScale.y + 20 * Time.deltaTime, 1);
    }

    IEnumerator EndExplosion(){
        yield return new WaitForSeconds(time_to_destroy);
        Destroy(this.gameObject);
    }


    void Update(){
        ActivateExplosion();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag =="Enemy"){
            Destroy(other.gameObject);
        }
    }
}
