using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colectable : MonoBehaviour
{
    [HideInInspector]
    public float speed;
    [HideInInspector]
    public bool active = false;

    private Rigidbody2D myBody;
    [SerializeField] private string WALL_TAG;
    [SerializeField] private string PLAYER_TAG;

    // Start is called before the first frame update
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        StartCoroutine(TimeToDestroy());
    }

    void FixedUpdate()
    {
        myBody.velocity = new Vector2(speed, myBody.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(WALL_TAG) || collision.gameObject.CompareTag(PLAYER_TAG))
        {
            AudioManager.Instance.Play(AudioManager.Instance.sfx[1]);
            Destroy(gameObject);
        }
    }

    IEnumerator TimeToDestroy()
    {
        yield return new WaitForSeconds(Random.Range(10, 25));
        Destroy(this.gameObject);
    }
}
