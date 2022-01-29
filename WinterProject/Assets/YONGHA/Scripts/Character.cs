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
}
