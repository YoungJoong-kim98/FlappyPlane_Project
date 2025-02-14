using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public int obstacleCount = 0;
    public Vector3 obstacleLastPosition = Vector3.zero;
    public int numBgCount = 5;
    // Start is called before the first frame update
    void Start()
    {
        
        Obstacle[] obstacles = GameObject.FindObjectsOfType<Obstacle>();
        obstacleLastPosition = obstacles[0].transform.position;
        obstacleCount = obstacles.Length;

        for(int i = 0; i < obstacleCount; i++)
        {
            obstacleLastPosition = obstacles[i].SetRandomPlace(obstacleLastPosition,obstacleCount);
        }
    } //ó���� ��� ��ֹ����� ã�� ó������ ������ ��ġ�� ���� 
    // ������ ��ġ�� ������ ���� ��ġ�� ��ġ�� �޾ƿͼ� �� ���� ������ ��ġ�� �������� �� ��ȯ�� ����.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggerd :" + collision.name);
        if(collision.CompareTag("BackGround"))
        { //����� �ʺ� �����ò��� �ݶ��̴��� ������ �����ð���
            float widtOfBgObject = ((BoxCollider2D)collision).size.x;//collision�� ��� collider�� �θ�Ŭ�����̱⿡
                                                                     //������ �� Ŭ������ �����ϴ°� �ƴϱ⿡ �ڽ��ݶ��̴��� ����� ������ �� ����
                                                                     //�׷��� �ݸ����� ��� �ڽ��ݶ��̴��� ����ȯ�� �����ְ� ������ ���� ������ �� ����
            Vector3 pos = collision.transform.position;
            pos.x += widtOfBgObject * numBgCount;
            collision.transform.position = pos;
            return;
        }

        Obstacle obstacle = collision.GetComponent<Obstacle>(); // �浹ü���� Obstacle�� �ִ����� �˻�
        if (obstacle != null)
        {
            obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition,obstacleCount);
        }
        
    }
}
