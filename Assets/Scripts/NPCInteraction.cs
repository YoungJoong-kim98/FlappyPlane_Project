using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public GameObject MiniGameInfoUI;  // Ȱ��ȭ�� ĵ������ ������ ����
    public GameObject MainUI;
    private bool isInRange = false;  // �÷��̾ NPC ��ó�� �ִ��� Ȯ���ϴ� ����
    private const string playerkeyx = "PlayerX";
    private const string playerkeyy = "PlayerY";

    void Update()
    {
        // F Ű�� ������ ��, �÷��̾ NPC ��ó�� ���� ���
        if (isInRange && Input.GetKeyDown(KeyCode.F))
        {
            // ĵ���� Ȱ��ȭ
            MiniGameInfoUI.SetActive(true);
            MainUI.SetActive(false);
            // �÷��̾� ��ġ ����
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
            {
                PlayerPrefs.SetFloat(playerkeyx, playerObj.transform.position.x);
                PlayerPrefs.SetFloat(playerkeyy, playerObj.transform.position.y);
                PlayerPrefs.Save();  
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
        }
    }
}
