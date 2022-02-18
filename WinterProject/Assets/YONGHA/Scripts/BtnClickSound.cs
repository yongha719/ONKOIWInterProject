using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnClickSound : MonoBehaviour
{
    public void Click()
    {
        SoundManager.Instance.Effect[7].Play();
    }
}
