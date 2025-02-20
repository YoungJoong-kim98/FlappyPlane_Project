using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public GameObject RockPrefab; // 바위 프리팹
    public float spawnInterval = 1.5f; // 생성 간격
    public float spawnRangeX = 16f; // 가로 범위

    void Start()
    {
        InvokeRepeating("Rockspawner", 1f, spawnInterval); // 일정 간격으로 바위 생성
    }
    private void Update()
    {

    }

    void Rockspawner()
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX); // 랜덤한 X 위치
        Vector3 spawnPosition = new Vector3(randomX, transform.position.y+5, 0); // 스폰 위치 설정

        Instantiate(RockPrefab, spawnPosition, Quaternion.identity); // 돌 생성
        
    }
}
