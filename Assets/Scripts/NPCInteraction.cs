using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NPCInteraction : MonoBehaviour
{
    public GameObject MiniGameInfoUI;  // Ȱ��ȭ�� ĵ������ ������ ����
    private bool isInRange = false;  // �÷��̾ NPC ��ó�� �ִ��� Ȯ���ϴ� ����

    void Update()
    {
        // F Ű�� ������ ��, �÷��̾ NPC ��ó�� ���� ���
        if (isInRange && Input.GetKeyDown(KeyCode.F))
        {
            // ĵ���� Ȱ��ȭ
            MiniGameInfoUI.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            Debug.Log("1");
            isInRange = true;
            //Debug.Log("Player entered range");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            Debug.Log("2");
            isInRange = false;
            //Debug.Log("Player exited range");
        }
    }

}

