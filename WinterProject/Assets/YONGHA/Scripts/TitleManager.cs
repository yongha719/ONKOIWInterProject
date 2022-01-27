using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public static TitleManager Instance { get; set; }

    public GameObject Namefield;
    public Text PlayerName;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        Namefield.SetActive(false);
    }

    void Update()
    {
        GetIngameScene();
    }

    public void StartButton()
    {
        Namefield.SetActive(true);
    }

    void GetIngameScene()
    {
        if (SceneManager.GetActiveScene().name == "Title")
        {
            if (GameObject.Find("Canvas").transform.Find("NameField").gameObject.activeSelf)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                    SceneManager.LoadScene("Ingame");
            }
        }
    }
}
