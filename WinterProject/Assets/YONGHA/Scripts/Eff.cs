using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Eff : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<Slider>().value = SoundManager.Instance.BtnVolume;
    }
    public void SetEffectVolume(float abc)
    {
        SoundManager.Instance.BtnVolume = abc;
        int cheak = 0;
        foreach (var item in SoundManager.Instance.Effect)
        {
            SoundManager.Instance.Effect[cheak].volume = SoundManager.Instance.BtnVolume;
            cheak++;
        }
    }
}