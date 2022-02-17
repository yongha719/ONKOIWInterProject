using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    //0-스토리 1-노말엔딩 2-눈싸움 3-대화 4-메인,해피 5-비디오게임 6-찾기게임
    public AudioSource[] BGM;

    private void Start()
    {
        BGM[4].Play();
    }
}
