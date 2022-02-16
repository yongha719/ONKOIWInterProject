using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Album_Test : MonoBehaviour
{
    [SerializeField] private GameObject ChaeAhHappyAlbum, SeHwaHappyAlbum, GaYoonHappyAlbum;
    [SerializeField] private GameObject ChaeAhNormal, SeHwaNormal, GaYoonNormal;
    [SerializeField] private GameObject ChaeAhHappy1, ChaeAhHappy2, ChaeAhHappy3, SeHwaHappy1, SeHwaHappy2, SeHwaHappy3, GayoonHappy1, GayoonHappy2, GayoonHappy3;
    [SerializeField] private GameObject ChaeAhBtn, SeHwaBtn, GaYoonBtn;

    int ChaeAhCheak, SeHwaCheak, GayoonCheak;

    public void NormalOn() //�븻 ���� �ر� ���� �� (���� ĳ���͸��� ���� �������)
    {
        ChaeAhNormal.SetActive(true);SeHwaNormal.SetActive(true);GaYoonNormal.SetActive(true);
    }

    public void HappyOn() //���� ���� �ر� ���� �� (���� ĳ���͸��� ���� �������)
    {
        ChaeAhHappyAlbum.SetActive(false);SeHwaHappyAlbum.SetActive(false);GaYoonHappyAlbum.SetActive(false);
        ChaeAhHappy1.SetActive(true);SeHwaHappy1.SetActive(true);GayoonHappy1.SetActive(true);
        ChaeAhBtn.SetActive(true);SeHwaBtn.SetActive(true);GaYoonBtn.SetActive(true);
    }

    public void HappyClickChaeAh()
    {
        if (ChaeAhCheak == 0)
        {
            ChaeAhHappy1.SetActive(false);
            ChaeAhHappy2.SetActive(true);
            ChaeAhCheak++;
        }
        else if (ChaeAhCheak == 1)
        {
            ChaeAhHappy2.SetActive(false);
            ChaeAhHappy3.SetActive(true);
            ChaeAhCheak++;
        }
        else if (ChaeAhCheak == 2)
        {
            ChaeAhHappy3.SetActive(false);
            ChaeAhHappy1.SetActive(true);
            ChaeAhCheak = 0;
        }
    }
    public void HappyCheakSeHwa()
    {
        if (SeHwaCheak == 0)
        {
            SeHwaHappy1.SetActive(false);
            SeHwaHappy2.SetActive(true);
            SeHwaCheak++;
        }
        else if (SeHwaCheak == 1)
        {
            SeHwaHappy2.SetActive(false);
            SeHwaHappy3.SetActive(true);
            SeHwaCheak++;
        }
        else if (SeHwaCheak == 2)
        {
            SeHwaHappy3.SetActive(false);
            SeHwaHappy1.SetActive(true);
            SeHwaCheak = 0;
        }
    }
    public void HappyCheakGayoon()
    {
        if (GayoonCheak == 0)
        {
            GayoonHappy1.SetActive(false);
            GayoonHappy2.SetActive(true);
            GayoonCheak++;
        }
        else if (GayoonCheak == 1)
        {
            GayoonHappy2.SetActive(false);
            GayoonHappy3.SetActive(true);
            GayoonCheak++;
        }
        else if (GayoonCheak == 2)
        {
            GayoonHappy3.SetActive(false);
            GayoonHappy1.SetActive(true);
            GayoonCheak = 0;
        }
    }
}

