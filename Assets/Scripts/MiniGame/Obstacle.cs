using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float highPosY = 1f; // 장애물이 이동할 때 상하로 얼마나 이동할것인지 지정하는변수
    public float lowPosY = -1f;

    public float holeSizeMin = 1f; // 탑과바텀사이에 공간을 얼마나 가져갈것인지 지정하는 변수
    public float holeSizeMax = 3f;

    public Transform topObject; // 탑 오브젝트
    public Transform bottomObject; // 바텀 오브젝트

    public float widthPadding = 4f; // 이 오브젝트들을 배치할 때 사이에 폭을 얼마나 가져갈건지 정해주는 변수
    
    GameManager gamaManager;

    private void Start()
    {
        gamaManager = GameManager.Instance;
    }
    public Vector3 SetRandomPlace(Vector3 lastPosition , int obstaclCount)
    {
        float holeSize = Random.Range(holeSizeMin, holeSizeMax); // 1 ~ 3 실수 값 사이에 배치
        float halfHoleSize = holeSize / 2; // 위에 랜덤값에 절반을 저장하는 변수

        topObject.localPosition = new Vector3(0,halfHoleSize); // 탑 오브젝트 위치 지정
        bottomObject.localPosition = new Vector3(0,-halfHoleSize); // 바텀 오브젝트 위치 지정 얘는 아래로 가야하니 - 부호
        //여기서 로컬좌표를 사용하는 이유는 부모의 위치값을 따라가야하기 때문에 기준이 부모의 좌표를 기준으로 적용됨.

        Vector3 placePosition = lastPosition + new Vector3(widthPadding,0); //마지막 오브젝트 뒤에 4 만큼 지난 값으로 이동을 시킴(배치시킴)
        placePosition.y = Random.Range(lowPosY, highPosY);
        transform.position = placePosition;
        return placePosition;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if(player != null)
        {
            gamaManager.AddScore(1);
        }
    }


}
