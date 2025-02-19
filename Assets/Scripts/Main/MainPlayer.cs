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
        moveInput.x = Input.GetAxisRaw("Horizontal");  // A, D �Ǵ� ��, ��
        moveInput.y = Input.GetAxisRaw("Vertical");    // W, S �Ǵ� ��, ��

        // ���⿡ ���� ĳ���� ȸ��
        if (moveInput.x > 0) // ������ �̵�
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (moveInput.x < 0) // ���� �̵�
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = moveInput.normalized * moveSpeed;
    }
}
