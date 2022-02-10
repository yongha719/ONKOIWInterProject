using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public string PlayerName;

    void Start()
    {

    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Title")
            PlayerName = TitleManager.Instance.PlayerName.text;
    }
}