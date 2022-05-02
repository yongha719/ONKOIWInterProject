using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShootingGameManager : MonoBehaviour
{
    public static ShootingGameManager Instance { get; private set; }
    [SerializeField] private GameObject[] HpImage;
    [SerializeField] private GameObject[] DeadHpImage;
    [SerializeField] private GameObject Manual;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
    }
    private void Update()
    {
        Color color = Manual.GetComponent<Image>().color;
        color.a -= Time.deltaTime * 0.3f;
        Manual.GetComponent<Image>().color = color;

    }
    public void UpdateHpIcon(int playerHp)
    {
        print("¿¿ «œ∆Æ πŸ≤„~~");
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
