using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClearManager : MonoBehaviour
{
    public static GameClearManager Inst { get; private set; }
    void Awake() => Inst = this;

    [SerializeField] GameObject Clear;
    bool isOne = true;
    public int FindHide = 0;

    BackGround backGround;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FindHide == 3)
        {
            if(isOne == true)
            {
                isOne = false;
                Invoke("GameClear", 1.8f);
                GameManager.Instance.Mini2Clear = true;
                
            }
        }

    }

    void GameClear()
    {
        Clear.SetActive(true);
        SoundManager.Instance.Effect[1].Play();
    }
}
