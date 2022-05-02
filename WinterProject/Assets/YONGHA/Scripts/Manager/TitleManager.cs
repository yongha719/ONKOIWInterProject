using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class TitleManager : MonoBehaviour
{ 
    public GameObject Namefield;
    public GameObject Soundfield;
    public GameObject Albumfield;
    public GameObject Continuefield;

    public Text PlayerName;
    void Awake()
    {

    }
    void Start()
    {
        Namefield.SetActive(false);
        Soundfield.SetActive(false);
        Albumfield.SetActive(false);
        Continuefield.SetActive(false);
    }
    void Update()
    {
        GetIngameScene();
        GameManager.Instance.PlayerName = PlayerName.text;
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
