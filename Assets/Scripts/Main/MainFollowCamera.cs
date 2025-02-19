using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainFollowCamera : MonoBehaviour
{
    public Transform target;
    float offsetX;
    float offsetY;

    // Start is called before the first frame update
    void Start()
    {
        if (target == null)
            return;
        offsetX = transform.position.x - target.position.x; // 내 위치(카메라)에서 타겟 비행기의 x 값을 빼준 값 카메라와 플레이어 사이의 거리가 저장됨.  카메라 값을 3.5 줬으니 처음에 3.5가 셋팅 
        offsetY = transform.position.y - transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;

        Vector3 pos = transform.position;
        pos.x = target.position.x + offsetX;
        pos.y = target.position.y + offsetY;
        transform.position = pos;

    }

}
