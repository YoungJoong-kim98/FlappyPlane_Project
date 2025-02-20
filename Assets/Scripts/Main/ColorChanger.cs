using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour
{
    public Slider RcolorSlider; //  ���� �����̴�
    public Slider GcolorSlider; //  �ʷ� �����̴�
    public Slider BcolorSlider; //  �Ķ� �����̴�
    public SpriteRenderer Body; //  ĳ������ SpriteRenderer
    public SpriteRenderer Head;
    public SpriteRenderer Leg_F_F;
    public SpriteRenderer Leg_F_B;
    public SpriteRenderer Leg_B_B;
    public SpriteRenderer Leg_B_F;


    void Start()
    {
        // �����̴� ���� ����� �� UpdateColor ����
        RcolorSlider.onValueChanged.AddListener(delegate { UpdateColor(); });
        GcolorSlider.onValueChanged.AddListener(delegate { UpdateColor(); });
        BcolorSlider.onValueChanged.AddListener(delegate { UpdateColor(); });
    }

    void UpdateColor()
    {
        //  �����̴� ���� �����ͼ� RGB ���� ����
        float r = RcolorSlider.value;
        float g = GcolorSlider.value;
        float b = BcolorSlider.value;

        // ���ο� ���� ����
        Body.color = new Color(r, g, b, 1); 
        Head.color = new Color(r, g, b, 1);
        Leg_F_F.color = new Color(r, g, b, 1);
        Leg_F_B.color = new Color(r, g, b, 1);
        Leg_B_B.color = new Color(r, g, b, 1);
        Leg_B_F.color = new Color(r, g, b, 1);
    }
}
