using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SoundManager : Singleton<SoundManager>
{
    //0-���丮 1-�븻���� 2-���ο� 3-��ȭ 4-����,���� 5-�������� 6-ã�����
    public AudioSource[] BGM;

    private void Start()
    {
        BGM[4].Play();
    }
}
