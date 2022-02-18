using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Thing : MonoBehaviour
{
    Image image;
    public int Idx;
    bool isOnetime = true;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Hide.hide[Idx].activeSelf == false && isOnetime == true)
        {
            isOnetime = false;
            SoundManager.Instance.Effect[10].Play();
            Color color = image.color;
            color.a = 0.4f;
            image.color = color;
        }   
    }
}
