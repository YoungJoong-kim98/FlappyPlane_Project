using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public GameObject MiniGameInfoUI;  // 활성화할 캔버스를 연결할 변수
    public GameObject MainUI;
    private bool isInRange = false;  // 플레이어가 NPC 근처에 있는지 확인하는 변수
    private const string playerkeyx = "PlayerX";
    private const string playerkeyy = "PlayerY";

    void Update()
    {
        // F 키를 눌렀을 때, 플레이어가 NPC 근처에 있을 경우
        if (isInRange && Input.GetKeyDown(KeyCode.F))
        {
            // 캔버스 활성화
            MiniGameInfoUI.SetActive(true);
            MainUI.SetActive(false);
            // 플레이어 위치 저장
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
