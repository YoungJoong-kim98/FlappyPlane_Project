using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator;
    Rigidbody2D _rigidbody;

    public float flapForce = 6f;
    public float forwardSpeed = 3f;
    public bool isDead = false;
    float deatCooldown = 0f;

    bool isFlap = false;

    public bool godMode = false;

    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;

        animator = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        if (animator == null)
            Debug.LogError("Not Founded Animator");
        if (_rigidbody == null)
            Debug.LogError("Not Founded Rigidbody");
        Time.timeScale = 1f;

    }

    // Update is called once per frame
    void Update()
    {
        if(isDead)
        {
            if(deatCooldown<=0)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    gameManager.RestartGame();
                }
            }
            else
            {
                deatCooldown -= Time.deltaTime;
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                isFlap = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isDead) return;

        Vector3 velociy = _rigidbody.velocity;
        velociy.x = forwardSpeed;
        
        if(isFlap)
        {
            velociy.y += flapForce;
            isFlap = false;
        }
        _rigidbody.velocity = velociy;

        float angle = Mathf.Clamp((_rigidbody.velocity.y*10f), -90, 90);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (godMode) return;

        if (isDead) return;

        isDead = true;
        deatCooldown = 1f;

        animator.SetInteger("IsDie", 1);
        gameManager.GameOver();
    }

}
