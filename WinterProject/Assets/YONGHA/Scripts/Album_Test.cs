using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Album_Test : MonoBehaviour
{
    [SerializeField] private GameObject ChaeAhHappyAlbum, SeHwaHappyAlbum, GaYoonHappyAlbum;
    [SerializeField] private GameObject ChaeAhNormal, SeHwaNormal, GaYoonNormal;
    [SerializeField] private GameObject ChaeAhHappy1, ChaeAhHappy2, ChaeAhHappy3;
    [SerializeField] private GameObject ChaeAhBtn, SeHwaBtn, GaYoonBtn;

    int ChaeAhCheak;
    private void Awake()
    {
        
    }

    public void NormalOn()
    {
        ChaeAhNormal.SetActive(true);
    }

    public void HappyOn()
    {
        ChaeAhHappyAlbum.SetActive(false);
        ChaeAhHappy1.SetActive(true);
        ChaeAhBtn.SetActive(true);
    }

    public void HappyClick()
    {
        if(ChaeAhCheak == 0)
        {
            ChaeAhHappy1.SetActive(false);
            ChaeAhHappy2.SetActive(true);
            ChaeAhCheak++;
        }
        else if(ChaeAhCheak == 1)
        {
            ChaeAhHappy2.SetActive(false);
            ChaeAhHappy3.SetActive(true);
            ChaeAhCheak++;
        }
        else if(ChaeAhCheak == 2)
        {
            ChaeAhHappy3.SetActive(false);
            ChaeAhHappy1.SetActive(true);
            ChaeAhCheak = 0;
        }
    }

}
