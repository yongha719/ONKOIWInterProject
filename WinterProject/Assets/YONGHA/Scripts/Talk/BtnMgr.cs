using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnMgr : MonoBehaviour
{
    public static BtnMgr Instance { get; private set; } = null;

    public string BtnChoiceText;
    public int Kang;
    public int Yang;
    public int Baek;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
