using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShootingGameManager : MonoBehaviour
{
    public static ShootingGameManager Instance { get; private set; }
    [SerializeField] private Image[] HpImage;
    private void Awake()
    {
        Instance = this;
    }
    public void UpdateHpIcon(int playerHp)
    {
        for(int index = 0; index < 3; index++)
        {
            HpImage[index].color = new Color(1, 1, 1, 0);
        }
        for(int index = 0;index < playerHp; index++)
        {
            HpImage[index].color = new Color(1, 1, 1, 1);
        }
    }
}
