using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{
    public float Hp;
    public float DMG;

    public float speed;
    public float PosDelay;
    float Poscur;

    public GameObject bullet;

    Vector2 targetpos;

    void Start()
    {
        Poscur = PosDelay / 2;
    }

    void Update()
    {
        AIMoving();
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
}
