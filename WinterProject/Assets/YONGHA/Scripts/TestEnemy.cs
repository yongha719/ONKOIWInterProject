using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{
    bool AImove = false;

    public float speed;
    public float Delay;
    float curdelay;

    Vector2 targetpos;

    void AIMoving()
    {
        if (curdelay >= Delay)
        {
            targetpos = new Vector2(Random.Range(-8f, 9), Random.Range(-4f, 4));
            curdelay = 0;
        }
        else
            curdelay += Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, targetpos, speed * Time.deltaTime);
    }

    void Start()
    {
        curdelay = Delay;
    }

    void Update()
    {
        AIMoving();
    }
}
