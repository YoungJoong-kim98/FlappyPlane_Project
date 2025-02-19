using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NPCInteraction : MonoBehaviour
{
    public GameObject MiniGameInfoUI;  // 활성화할 캔버스를 연결할 변수
    private bool isInRange = false;  // 플레이어가 NPC 근처에 있는지 확인하는 변수

    void Update()
    {
        // F 키를 눌렀을 때, 플레이어가 NPC 근처에 있을 경우
        if (isInRange && Input.GetKeyDown(KeyCode.F))
        {
            // 캔버스 활성화
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

