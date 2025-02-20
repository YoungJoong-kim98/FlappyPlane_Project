using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIManager : MonoBehaviour
{

    public Button AppearancechangeButton;
    public GameObject Pigchange;
    // Start is called before the first frame update
    void Start()
    {
        AppearancechangeButton.onClick.AddListener(Appearancechange);
    }

    // Update is called once per frame
    public void Appearancechange()
    {
        Pigchange.SetActive(true);
    }
}
