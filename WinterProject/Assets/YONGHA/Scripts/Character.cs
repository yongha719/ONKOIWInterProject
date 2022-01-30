using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Character : MonoBehaviour
{
    public GameObject Kang;
    public GameObject Yang;
    public GameObject Baek;

    int i = 0;
    [SerializeField] private GameObject Gift;

    public List<GameObject> BtnNum = new List<GameObject>();
    public void Conversation1()
    {
        Kang.SetActive(true);
    }

    public void Conversation2()
    {
        Yang.SetActive(true);
    }

    public void Conversation3()
    {
        Baek.SetActive(true);
    }

    public void ExitBtn()
    {
        Kang.SetActive(false);
        Yang.SetActive(false);
        Baek.SetActive(false);    
    }
    public void LoveBtn()
    {
        Gift.SetActive(true);

        foreach(var list in BtnNum)
        {
            list.SetActive(false);
        }
    }
}
