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
    //Scene�̵� �Լ��� ���⿡�� ���ּ���
    public void Title()
    {
        SceneManager.LoadScene("Title");
    }

    public void Skip()
    {
        SceneManager.LoadScene("Love");
    }
    
}
