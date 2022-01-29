using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{

    string PlayerName;

    void Start()
    {

    }

    void Update()
    {
        PlayerName = TitleManager.Instance.PlayerName.text;
    }
}
