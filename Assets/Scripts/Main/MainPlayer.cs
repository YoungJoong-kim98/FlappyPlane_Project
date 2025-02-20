using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    //private Vehicle currentVehicle; // 현재 탑승 중인 차량

    private const string playerkeyx = "PlayerX";
    private const string playerkeyy = "PlayerY";

    void Awake()
    {
        float playerx = PlayerPrefs.GetFloat(playerkeyx, 0);
        float playery = PlayerPrefs.GetFloat(playerkeyy, 0);
        transform.position = new Vector3(playerx, playery, transform.position.z);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        // 방향 설정
        if (moveInput.x > 0) transform.eulerAngles = new Vector3(0, 0, 0);
        else if (moveInput.x < 0) transform.eulerAngles = new Vector3(0, 180, 0);
    }

    void FixedUpdate()
    {
        rb.velocity = moveInput.normalized * moveSpeed;
    }
}