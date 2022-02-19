using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BtnTest : MonoBehaviour, IPointerClickHandler
{
    Button test;
    void Start()
    {

    }

    void Update()
    {

    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (pointerEventData.button == PointerEventData.InputButton.Left)
        {
            print("¤¾¤·");
        }
        else if (pointerEventData.button == PointerEventData.InputButton.Right)
            print("½È¾î");
    }
}
