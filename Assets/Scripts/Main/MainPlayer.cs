using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");  // A, D 또는 ←, →
        moveInput.y = Input.GetAxisRaw("Vertical");    // W, S 또는 ↑, ↓

        // 방향에 따라 캐릭터 회전
        if (moveInput.x > 0) // 오른쪽 이동
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (moveInput.x < 0) // 왼쪽 이동
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = moveInput.normalized * moveSpeed;
    }
}
