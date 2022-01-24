using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Thing : MonoBehaviour
{
    Image image;
    public int Idx;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Hide.hide[Idx].activeSelf == false)
        {
            Color color = image.color;
            color.a = 0.2f;
            image.color = color;
        }   
    }
}
