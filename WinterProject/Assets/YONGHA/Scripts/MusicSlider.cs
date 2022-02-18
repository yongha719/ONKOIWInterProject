using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MusicSlider : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<Slider>().value = SoundManager.Instance.MusicVolume;
    }
    public void SetMusicVolume(float abc)
    {
        SoundManager.Instance.MusicVolume = abc;
        int cheak = 0;
        foreach (var item in SoundManager.Instance.BGM)
        {
            SoundManager.Instance.BGM[cheak].volume = SoundManager.Instance.MusicVolume;
            cheak++;
        }
    }
}