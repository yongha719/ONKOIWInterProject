using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackGround : MonoBehaviour
{
    bool isOn = false;
    bool isGameClear = false;
    private int heartCount = 2;
    public Transform heartTransform;
    [SerializeField] List<GameObject> heart = new List<GameObject>();

    Coroutine heartCorutine;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform hT in heartTransform)
        {
            heart.Add(hT.gameObject);
        }

        //heartCorutine = StartCoroutine(HeartLoop());
    }
    //IEnumerator HeartLoop()
    //{
    //    while (heartCount > 0)
    //    {
    //        if (Input.GetMouseButtonDown(0) && isOn == true)
    //        {
    //            heart[heartCount].SetActive(false);
    //            heartCount--;
    //            yield return new WaitForSeconds(1);
    //        }
    //    }
    //}

    // Update is called once per frame
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
        isOn = true;
        if (isOn == true && isGameClear == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                heart[heartCount].SetActive(false);
                heartCount--;
            }
        }
    }

    void OnMouseExit()
    {
        isOn = false;
    }

}
