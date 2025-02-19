using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pigchange : MonoBehaviour
{
    public SpriteRenderer Body; //  캐릭터의 Body SpriteRenderer
    public SpriteRenderer Head;
    public SpriteRenderer Leg_F_F; // 앞쪽 왼쪽 다리 (Front-Front)
    public SpriteRenderer Leg_F_B; // 앞쪽 오른쪽 다리 (Front-Back)
    public SpriteRenderer Leg_B_B; // 뒤쪽 오른쪽 다리 (Back-Back)
    public SpriteRenderer Leg_B_F; // 뒤쪽 왼쪽 다리 (Back-Front)

    // 변경할 스프라이트 리스트 (Inspector에서 할당)
    public Sprite Body_Pink;
    public Sprite Head_Pink;
    public Sprite Leg_F_F_Pink;
    public Sprite Leg_F_B_Pink;
    public Sprite Leg_B_B_Pink;
    public Sprite Leg_B_F_Pink;

    public Sprite Body_Black;
    public Sprite Head_Black;
    public Sprite Leg_F_F_Black;
    public Sprite Leg_F_B_Black;
    public Sprite Leg_B_B_Black;
    public Sprite Leg_B_F_Black;

    public Sprite Body_Green;
    public Sprite Head_Green;
    public Sprite Leg_F_F_Green;
    public Sprite Leg_F_B_Green;
    public Sprite Leg_B_B_Green;
    public Sprite Leg_B_F_Green;

    // 분홍 돼지로 변경
    public void Pig()
    {
        Body.sprite = Body_Pink;
        Head.sprite = Head_Pink;
        Leg_F_F.sprite = Leg_F_F_Pink;
        Leg_F_B.sprite = Leg_F_B_Pink;
        Leg_B_B.sprite = Leg_B_B_Pink;
        Leg_B_F.sprite = Leg_B_F_Pink;
    }

    // 검은 돼지로 변경
    public void BlackPig()
    {
        Body.sprite = Body_Black;
        Head.sprite = Head_Black;
        Leg_F_F.sprite = Leg_F_F_Black;
        Leg_F_B.sprite = Leg_F_B_Black;
        Leg_B_B.sprite = Leg_B_B_Black;
        Leg_B_F.sprite = Leg_B_F_Black;
    }

    // 초록 돼지로 변경
    public void GreenPig()
    {
        Body.sprite = Body_Green;
        Head.sprite = Head_Green;
        Leg_F_F.sprite = Leg_F_F_Green;
        Leg_F_B.sprite = Leg_F_B_Green;
        Leg_B_B.sprite = Leg_B_B_Green;
        Leg_B_F.sprite = Leg_B_F_Green;
    }
}
