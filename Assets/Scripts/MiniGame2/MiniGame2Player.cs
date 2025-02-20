using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame2Player : MonoBehaviour
{
    private float speed = 5f; // 이동 속도
    private Rigidbody2D rb;
    private Vector2 moveInput;

    //public static bool isDead = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal"); // A, D 키 입력 받기
        if (moveInput.x > 0) transform.eulerAngles = new Vector3(0, 0, 0);
        else if (moveInput.x < 0) transform.eulerAngles = new Vector3(0, 180, 0);
    }

    void FixedUpdate()
    {        
            rb.velocity = new Vector2(moveInput.x * speed, rb.velocity.y); // 좌우 이동만 가능하도록 설정

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Rock"))
        {           
            RockDestroy.Instance.GamveOver();
        }
    }
}
