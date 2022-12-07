using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [HideInInspector]
    public float speed;

    private Rigidbody2D myBody;
    [SerializeField] private int destroyTimerA, destroyTimerB;

    // Start is called before the first frame update
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        StartCoroutine(TimeToDestroy());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myBody.velocity = new Vector2(speed, myBody.velocity.y);
    }

    IEnumerator TimeToDestroy()
    {
        yield return new WaitForSeconds(Random.Range(destroyTimerA, destroyTimerB));
        Destroy(this.gameObject);
    }
}