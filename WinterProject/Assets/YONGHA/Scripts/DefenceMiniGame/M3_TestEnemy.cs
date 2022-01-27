using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M3_TestEnemy : MonoBehaviour
{
    public float Hp;
    public float DMG;

    public float speed;
    public float PosDelay;
    float Poscur;

    public GameObject bullet;//±×·¡¶ó
    public float AttackDelay;
    float Attackcur;

    public Transform gun;
    Vector2 playerpos;
    Vector2 targetpos;

    void Start()
    {
        Poscur = PosDelay / 2;
    }

    void Update()
    {
        playerpos = GameObject.Find("Player").transform.position;
        AIMoving();
        TestAttack();
    }


    void AIMoving()
    {
        if (Poscur >= PosDelay)
        {
            targetpos = new Vector2(Random.Range(-8f, 9), Random.Range(-4f, 4));
            Poscur = 0;
        }
        else
            Poscur += Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, targetpos, speed * Time.deltaTime);
    }
    void TestAttack()
    {
        float z = Mathf.Atan2(playerpos.y, playerpos.x) * Mathf.Rad2Deg;
        gun.rotation = Quaternion.Euler(0, 0, z);
        if (Attackcur <= 0)
        {
            Instantiate(bullet, gun.position, gun.rotation);
            Attackcur = AttackDelay;
        }
        Attackcur -= Time.deltaTime;
    }
}
