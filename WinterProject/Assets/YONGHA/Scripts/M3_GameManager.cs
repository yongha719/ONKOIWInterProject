using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M3_GameManager : Singleton<M3_GameManager>
{
    public float PlayerHp;
    public float PlayerDMG;
    public float PlayerAttackDelay;

    public float EnemyHp;
    public float EnemyDMG;

    void Start()
    {

    }

    void Update()
    {

    }
    void PlayerDamaged()
    {

    }

    public void SetValue(float hp, string name)
    {
        if (name == "P")
            PlayerHp = hp;
        else if (name == "E")
            EnemyHp = hp;
    }
}
