using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackGround : MonoBehaviour
{
    bool isOn = false;
    bool isGameClear = false;
    public bool isGameOver = false;
    bool isClickCoolTime = true;
    private int heartCount = 2;
    public Transform heartTransform;
    [SerializeField] List<GameObject> heart = new List<GameObject>();

    void Start()
    {
        foreach (Transform hT in heartTransform)
        {
            heart.Add(hT.gameObject);
        }
       
    }
    
    void Update()
    {

        if (heartCount < 0)
        {
            isGameOver = true;
            SceneManager.LoadScene("GameOver");
        }

        if(GameClearManager.Inst.FindHide == 3)
        {
            isGameClear = true;
        }
    }

    void OnMouseOver()
    {
        if (isClickCoolTime == true && isGameClear == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                heart[heartCount].SetActive(false);
                heartCount--;
                isClickCoolTime = false;
                Invoke("CoolTime", 1f);
            }
        }
    }

    void CoolTime()
    {
        isClickCoolTime = true;
    }
}
