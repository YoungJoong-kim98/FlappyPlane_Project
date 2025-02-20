using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    public Transform seatPosition; // �÷��̾ ��ġ�� �¼� ��ġ 
    private bool playerNearby = false; // �÷��̾ ��ó�� �ִ��� üũ
    private MainPlayer player; // �÷��̾� ��ü

    private bool isRiding = false; // ���� ž�� ������
    private float originalMoveSpeed; // �÷��̾��� ���� �̵� �ӵ� ����

    private Vector2 moveInput;
    private void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.F))
        {
            if (!isRiding) // ž��
            {
                RideVehicle();
            }
            else // ����
            {
                ExitVehicle();
            }
        }

        // �÷��̾ ž�� ���̸� ������ ���� �����̵��� ����
        if (isRiding && player != null)
        {
            transform.position = player.transform.position; // ���� ��ġ�� �÷��̾� ��ġ�� ����ȭ
            moveInput.x = Input.GetAxisRaw("Horizontal");
            moveInput.y = Input.GetAxisRaw("Vertical");
            if (moveInput.x > 0) transform.eulerAngles = new Vector3(0, 0, 0);
            else if (moveInput.x < 0) transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    private void RideVehicle()
    {
        if (player == null || seatPosition == null) return; // Null ����
        isRiding = true;

        originalMoveSpeed = player.moveSpeed; // ���� �̵� �ӵ� ����
        player.moveSpeed = 8; // ž�� �� �ӵ� ����
        player.transform.position = seatPosition.position; // �÷��̾ �¼� ��ġ�� �̵�


        Debug.Log("�÷��̾ ž���߽��ϴ�!");
    }

    private void ExitVehicle()
    {
        if (player == null) return;
        isRiding = false;

        player.moveSpeed = originalMoveSpeed; // ���� �ӵ��� ����

        //  �÷��̾ ������ �ڽĿ��� ����
        player.transform.SetParent(null);

        Debug.Log(" �÷��̾ �����߽��ϴ�!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerNearby = true;
            player = collision.GetComponent<MainPlayer>();

            if (player == null)
                Debug.LogWarning(" 'Player' �±׸� ���� ������Ʈ�� 'MainPlayer' ��ũ��Ʈ�� �����ϴ�!");
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
