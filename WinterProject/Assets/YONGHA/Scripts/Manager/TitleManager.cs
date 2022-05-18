using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class TitleManager : MonoBehaviour
{
    public GameObject NameField;
    public GameObject SoundField;
    public GameObject AlbumField;
    public GameObject ContinueField;

    public Text PlayerName;

    void Start()
    {
        NameField.SetActive(false);
        SoundField.SetActive(false);
        AlbumField.SetActive(false);
    }
    void Update()
    {
        if (SceneManager.GetActiveScene().name.Equals("Title"))
        {
            getIngameScene();
        }
        GameManager.Instance.PlayerName = PlayerName.text;
    }

    void getIngameScene()
    {
        if (NameField.activeSelf)
        {
            if (Input.anyKeyDown)
                SceneManager.LoadScene("Ingame");
        }
    }
}
