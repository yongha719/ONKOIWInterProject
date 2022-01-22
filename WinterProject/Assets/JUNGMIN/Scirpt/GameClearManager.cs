using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClearManager : MonoBehaviour
{
    public static GameClearManager Inst { get; private set; }
    void Awake() => Inst = this;

    public GameObject Clear;
    bool isOne = true;
    public int FindHide = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FindHide == 4)
        {
            if(isOne == true)
            {
                isOne = false;
                Invoke("GameClear", 1.8f);
            }
        }
    }

    void GameClear()
    {
        Instantiate(Clear, new Vector3(0.53f, 0.02f, 0f), Quaternion.identity);
    }
}
