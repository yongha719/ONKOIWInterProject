using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    //Scene이동 함수는 여기에서 써주세요
    public void Title()
    {
        SceneManager.LoadScene("Title");
    }

    public void Skip()
    {
        SceneManager.LoadScene("Love");
    }
    
}
