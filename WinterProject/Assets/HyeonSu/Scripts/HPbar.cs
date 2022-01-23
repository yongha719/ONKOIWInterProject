using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HPbar : MonoBehaviour
{
    [SerializeField] private Slider hpbar;
    private void Update()
    {
        hpbar.value = Boss.Instance.bossHp / 100000;
        
    }
}
