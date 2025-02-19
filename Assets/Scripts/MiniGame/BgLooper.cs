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
    } //처음에 모든 장애물들을 찾고 처음부터 끝까지 배치를 해줌 
    // 각각의 배치가 끝나고 나면 배치한 위치를 받아와서 그 다음 생성될 위치를 전달해줌 그 순환을 돈다.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggerd :" + collision.name);
        if(collision.CompareTag("BackGround"))
        { //배경의 너비를 가져올껀데 콜라이더의 값으로 가져올거임
            float widtOfBgObject = ((BoxCollider2D)collision).size.x;//collision는 모든 collider의 부모클래스이기에
                                                                     //실제로 그 클래스에 접근하는게 아니기에 박스콜라이더의 사이즈를 가져올 수 없음
                                                                     //그래서 콜리전을 잠시 박스콜라이더로 형변환을 시켜주고 사이즈 값을 가져올 수 있음
            Vector3 pos = collision.transform.position;
            pos.x += widtOfBgObject * numBgCount;
            collision.transform.position = pos;
            return;
        }

        Obstacle obstacle = collision.GetComponent<Obstacle>(); // 충돌체에서 Obstacle이 있는지를 검사
        if (obstacle != null)
        {
            obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition,obstacleCount);
        }
        
    }
}
