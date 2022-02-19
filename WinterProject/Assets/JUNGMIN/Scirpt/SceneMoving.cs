using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMoving : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    public void GameOver()
    {
        SceneManager.LoadScene("Love");
    }

    public void GameClear()
    {
        SceneManager.LoadScene("MiniStory");
    }
}
