using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour
{
    public Slider RcolorSlider; //  빨강 슬라이더
    public Slider GcolorSlider; //  초록 슬라이더
    public Slider BcolorSlider; //  파랑 슬라이더
    public SpriteRenderer Body; //  캐릭터의 SpriteRenderer
    public SpriteRenderer Head;
    public SpriteRenderer Leg_F_F;
    public SpriteRenderer Leg_F_B;
    public SpriteRenderer Leg_B_B;
    public SpriteRenderer Leg_B_F;


    void Start()
    {
        // 슬라이더 값이 변경될 때 UpdateColor 실행
        RcolorSlider.onValueChanged.AddListener(delegate { UpdateColor(); });
        GcolorSlider.onValueChanged.AddListener(delegate { UpdateColor(); });
        BcolorSlider.onValueChanged.AddListener(delegate { UpdateColor(); });
    }

    void UpdateColor()
    {
        //  슬라이더 값을 가져와서 RGB 색상 적용
        float r = RcolorSlider.value;
        float g = GcolorSlider.value;
        float b = BcolorSlider.value;

        // 새로운 색상 적용
        Body.color = new Color(r, g, b, 1); 
        Head.color = new Color(r, g, b, 1);
        Leg_F_F.color = new Color(r, g, b, 1);
        Leg_F_B.color = new Color(r, g, b, 1);
        Leg_B_B.color = new Color(r, g, b, 1);
        Leg_B_F.color = new Color(r, g, b, 1);
    }
}
