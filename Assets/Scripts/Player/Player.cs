using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.InputSystem.OnScreen;

public class Player : MonoBehaviour
{
    [Header("Move forces")]
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 11f;

    [Header("Player input controls")]
    [SerializeField] private PlayerInput playerInput;

    private float movementX;
    private bool isGrounded;

    private float inputR;
    private float inputL;

    private Rigidbody2D myBody;
    private SpriteRenderer sr;
    private Animator anim;

    private string WALK_ANIMATION = "Walk";
    private string GROUND_TAG = "Ground";
    private string ENEMY_TAG = "Enemy";

    private GameObject right, left;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        PlayerMove();
        AnimatePlayer();
    }

    private void FixedUpdate()
    {
        PlayerJump();
    }

    private void LateUpdate()
    {
        BecomeInvencible();
    }

    public void BecomeInvencible()
    {
        if (GameManager.instance.invencible)
        {
            sr.color = new Color(1, 1, 1, 0.4f);
        }
        else
        {
            sr.color = new Color(1, 1, 1, 1);
        }
    }

    void PlayerMove() 
    {
        inputR = playerInput.actions["MoveRight"].ReadValue<float>();
        inputL = playerInput.actions["MoveLeft"].ReadValue<float>();

        if (inputR > 0)
        {
            transform.position += new Vector3(inputR, 0f, 0f) * moveForce * Time.deltaTime;
        }

        if (inputL > 0)
        {
            transform.position += new Vector3(-inputL, 0f, 0f) * moveForce * Time.deltaTime;
        }
    }

    void AnimatePlayer() 
    {
        if(Time.timeScale == 1)
        {
            if (inputR > 0 && inputL == 0f)
            {
                anim.SetBool(WALK_ANIMATION, true);
                sr.flipX = false;
            }
            else if (inputL > 0 && inputR == 0)
            {
                // we are going to the left side
                anim.SetBool(WALK_ANIMATION, true);
                sr.flipX = true;
            }
            else
            {
                anim.SetBool(WALK_ANIMATION, false);
            }
        }
    }

    void PlayerJump() 
    {
        if(isGrounded == true)
        {
            AudioManager.Instance.Play(AudioManager.Instance.sfx[2]);
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG)) 
            isGrounded = true;
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ENEMY_TAG) && GameManager.instance.invencible == false)
        {
            AudioManager.Instance.Play(AudioManager.Instance.sfx[4]);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag(ENEMY_TAG) && GameManager.instance.invencible == true)
        {
            AudioManager.Instance.Play(AudioManager.Instance.sfx[4]);
            Destroy(collision.gameObject);
        }
    }
    
    private void OnDestroy()
    {
        GameManager.instance.OnPlayerDeath();
        GameplayUIController.playerIsDead = true;
    }
}