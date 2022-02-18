using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public string PlayerName;

    public bool Mini1Clear = false;
    public bool Mini2Clear = false;
    public bool Mini3Clear = false;
    public bool ChaeahHappyBool = false, SehwaHappyBool = false, GaYoonHappyBool = false;
    public bool ChaeahNormalBool = false, SehwaNormalBool = false, GayoonNormalBool = false;
    void Start()
    {
        Sound();
        SceneManager.sceneLoaded += LoadedsceneEvent;
    }

    private void LoadedsceneEvent(Scene scene, LoadSceneMode mode)
    {
        Sound();
    }
    void Update()
    {

    }
    void Sound()
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                int case0 = 0;
                foreach (var item in SoundManager.Instance.BGM)
                {
                    if (SoundManager.Instance.BGM[4]!)
                        SoundManager.Instance.BGM[case0].Stop();
                    case0++;
                }
                SoundManager.Instance.BGM[4].Play();
                break;
            case 1:
                int case1 = 0;
                foreach (var item in SoundManager.Instance.BGM)
                {
                    if (SoundManager.Instance.BGM[0]!)
                        SoundManager.Instance.BGM[case1].Stop();
                    case1++;
                }
                SoundManager.Instance.BGM[0].Play();
                break;
            case 2:
                int case2 = 0;
                foreach (var item in SoundManager.Instance.BGM)
                {
                    if (SoundManager.Instance.BGM[5]!)
                        SoundManager.Instance.BGM[case2].Stop();
                    case2++;
                }
                SoundManager.Instance.BGM[5].Play();
                break;
            case 4:
                int case3 = 0;
                foreach (var item in SoundManager.Instance.BGM)
                {
                    if (SoundManager.Instance.BGM[2]!)
                        SoundManager.Instance.BGM[case3].Stop();
                    case3++;
                }
                SoundManager.Instance.BGM[2].Play();
                break;
            case 6:
                int case4 = 0;
                foreach (var item in SoundManager.Instance.BGM)
                {
                    if (SoundManager.Instance.BGM[3]!)
                        SoundManager.Instance.BGM[case4].Stop();
                    case4++;
                }
                SoundManager.Instance.BGM[3].Play();
                break;
            case 8:
                int case5 = 0;
                foreach (var item in SoundManager.Instance.BGM)
                {
                    if (SoundManager.Instance.BGM[6]!)
                        SoundManager.Instance.BGM[case5].Stop();
                    case5++;
                }
                SoundManager.Instance.BGM[6].Play();
                break;
        }


    }
}
