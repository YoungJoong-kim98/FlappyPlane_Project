using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float highPosY = 1f; // ��ֹ��� �̵��� �� ���Ϸ� �󸶳� �̵��Ұ����� �����ϴº���
    public float lowPosY = -1f;

    public float holeSizeMin = 1f; // ž�����һ��̿� ������ �󸶳� ������������ �����ϴ� ����
    public float holeSizeMax = 3f;

    public Transform topObject; // ž ������Ʈ
    public Transform bottomObject; // ���� ������Ʈ

    public float widthPadding = 4f; // �� ������Ʈ���� ��ġ�� �� ���̿� ���� �󸶳� ���������� �����ִ� ����
    
    GameManager gamaManager;

    private void Start()
    {
        gamaManager = GameManager.Instance;
    }
    public Vector3 SetRandomPlace(Vector3 lastPosition , int obstaclCount)
    {
        float holeSize = Random.Range(holeSizeMin, holeSizeMax); // 1 ~ 3 �Ǽ� �� ���̿� ��ġ
        float halfHoleSize = holeSize / 2; // ���� �������� ������ �����ϴ� ����

        topObject.localPosition = new Vector3(0,halfHoleSize); // ž ������Ʈ ��ġ ����
        bottomObject.localPosition = new Vector3(0,-halfHoleSize); // ���� ������Ʈ ��ġ ���� ��� �Ʒ��� �����ϴ� - ��ȣ
        //���⼭ ������ǥ�� ����ϴ� ������ �θ��� ��ġ���� ���󰡾��ϱ� ������ ������ �θ��� ��ǥ�� �������� �����.

        Vector3 placePosition = lastPosition + new Vector3(widthPadding,0); //������ ������Ʈ �ڿ� 4 ��ŭ ���� ������ �̵��� ��Ŵ(��ġ��Ŵ)
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
