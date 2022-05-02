using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundManager : Singleton<SoundManager>
{
    //0-스토리 1-노말엔딩 2-눈싸움 3-대화 4-메인,해피 5-비디오게임 6-찾기게임
    public AudioSource[] BGM;
    //0-겜오버 1-겜클리어 2-눈던진 3-눈맞은 4-때리는 소리 5-문두드리는 소리 6-문자 소리 7-버튼 누르는 소리
    //8-비디겜 뎀받는 소리 9-비디겜 총쏘는 소리 10-숨은그림 찾은 소리 11-전화 벨 소리
    public AudioSource[] Effect;

    public float MusicVolume = 1, BtnVolume = 1;
}
