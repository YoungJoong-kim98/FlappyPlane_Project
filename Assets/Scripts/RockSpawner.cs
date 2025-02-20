using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public GameObject RockPrefab; // ���� ������
    public float spawnInterval = 1.5f; // ���� ����
    public float spawnRangeX = 16f; // ���� ����

    void Start()
    {
        InvokeRepeating("Rockspawner", 1f, spawnInterval); // ���� �������� ���� ����
    }
    private void Update()
    {

    }

    void Rockspawner()
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX); // ������ X ��ġ
        Vector3 spawnPosition = new Vector3(randomX, transform.position.y+5, 0); // ���� ��ġ ����

        Instantiate(RockPrefab, spawnPosition, Quaternion.identity); // �� ����
        
    }
}
