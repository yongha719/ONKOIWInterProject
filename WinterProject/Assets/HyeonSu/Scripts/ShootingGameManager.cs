using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShootingGameManager : MonoBehaviour
{
    public static ShootingGameManager Instance { get; private set; }
    [SerializeField] private GameObject[] HpImage;
    [SerializeField] private GameObject[] DeadHpImage;
    private void Awake()
    {
        Instance = this;
    }
    public void UpdateHpIcon(int playerHp)
    {
        for(int index = 0; index < 3; index++)
        {
            HpImage[index].SetActive(false);
            DeadHpImage[index].SetActive(true);
        }
        for(int index = 0;index < playerHp; index++)
        {
            HpImage[index].SetActive(true);
            DeadHpImage[index].SetActive(false);
        }
    }
}
