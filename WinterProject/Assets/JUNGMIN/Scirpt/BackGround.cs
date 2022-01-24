using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackGround : MonoBehaviour
{
 
    bool isGameClear = false;
    bool isClickCoolTime = true;
    private int heartCount = 2;
    public Transform heartTransform;
    [SerializeField] List<GameObject> heart = new List<GameObject>();
 
    // Start is called before the first frame update
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
            SceneManager.LoadScene("GameOver");
        }

        if(GameClearManager.Inst.FindHide == 4)
        {
            isGameClear = true;
        }
    }

    void OnMouseOver()
    {      
        if (isGameClear == false && isClickCoolTime == true)
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
