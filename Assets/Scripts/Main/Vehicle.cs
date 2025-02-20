using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    public Transform seatPosition; // 플레이어가 위치할 좌석 위치 
    private bool playerNearby = false; // 플레이어가 근처에 있는지 체크
    private MainPlayer player; // 플레이어 객체

    private bool isRiding = false; // 현재 탑승 중인지
    private float originalMoveSpeed; // 플레이어의 원래 이동 속도 저장

    private Vector2 moveInput;
    private void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.F))
        {
            if (!isRiding) // 탑승
            {
                RideVehicle();
            }
            else // 하차
            {
                ExitVehicle();
            }
        }

        // 플레이어가 탑승 중이면 차량도 같이 움직이도록 설정
        if (isRiding && player != null)
        {
            transform.position = player.transform.position; // 차량 위치를 플레이어 위치로 동기화
            moveInput.x = Input.GetAxisRaw("Horizontal");
            moveInput.y = Input.GetAxisRaw("Vertical");
            if (moveInput.x > 0) transform.eulerAngles = new Vector3(0, 0, 0);
            else if (moveInput.x < 0) transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    private void RideVehicle()
    {
        if (player == null || seatPosition == null) return; // Null 방지
        isRiding = true;

        originalMoveSpeed = player.moveSpeed; // 원래 이동 속도 저장
        player.moveSpeed = 8; // 탑승 시 속도 증가
        player.transform.position = seatPosition.position; // 플레이어를 좌석 위치로 이동


        Debug.Log("플레이어가 탑승했습니다!");
    }

    private void ExitVehicle()
    {
        if (player == null) return;
        isRiding = false;

        player.moveSpeed = originalMoveSpeed; // 원래 속도로 복구

        //  플레이어를 차량의 자식에서 해제
        player.transform.SetParent(null);

        Debug.Log(" 플레이어가 하차했습니다!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerNearby = true;
            player = collision.GetComponent<MainPlayer>();

            if (player == null)
                Debug.LogWarning(" 'Player' 태그를 가진 오브젝트에 'MainPlayer' 스크립트가 없습니다!");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }
}
