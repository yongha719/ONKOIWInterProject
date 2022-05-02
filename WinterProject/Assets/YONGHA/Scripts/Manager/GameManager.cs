using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public string PlayerName;
    ITalkLoad loader;
    ITalkSave saver;
    public bool Mini1Clear = false;
    public bool Mini2Clear = false;
    public bool Mini3Clear = false;
    public bool ChaeahHappyBool = true, SehwaHappyBool = true, GaYoonHappyBool = true;
    public bool ChaeahNormalBool = true, SehwaNormalBool = true, GayoonNormalBool = true;
    public float kanglike = 0, yanglike = 0, beaklike = 0;
    Album Albumlist;
    TalkProgress talkprog;
    void Start()
    {
        loader = new JsonLoader();
        saver = new JsonLoader();
        talkprog = new TalkProgress();
        talkprog.Talkprog = new List<int>() { 0, 0, 0 };
        saver.SaveTalk(talkprog);
        print("g");
        Sound();
        SceneManager.sceneLoaded += LoadedsceneEvent;
        LoadAlbums();
    }

    private void LoadedsceneEvent(Scene scene, LoadSceneMode mode)
    {
        Sound();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
            AlbumSave();
    }
    public void AlbumSave()
    {
        Albumlist.album = new List<bool>() { ChaeahNormalBool, ChaeahHappyBool, SehwaNormalBool, SehwaHappyBool, GayoonNormalBool, GaYoonHappyBool };
        saver.AlbumSave(Albumlist);
    }
    public void LoadAlbums()
    {
        var album = loader.LoadAlbum();
        ChaeahNormalBool = album.album[0];
        ChaeahHappyBool = album.album[1];
        SehwaNormalBool = album.album[2];
        SehwaHappyBool = album.album[3];
        GayoonNormalBool = album.album[4];
        GaYoonHappyBool = album.album[5];
    }
    void Sound()
    {
        //0-�׿��� 1-��Ŭ���� 2-������ 3-������ 4-������ �Ҹ� 5-���ε帮�� �Ҹ� 6-���� �Ҹ� 7-��ư ������ �Ҹ�
        //8-���� ���޴� �Ҹ� 9-���� �ѽ�� �Ҹ� 10-�����׸� ã�� �Ҹ� 11-��ȭ �� �Ҹ�
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
    private void OnApplicationQuit()
    {
        saver.AlbumSave(Albumlist);
        print("GameManager : OnApplicationQuit");
    }
}
