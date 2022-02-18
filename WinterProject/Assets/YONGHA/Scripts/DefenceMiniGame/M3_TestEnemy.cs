using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyDir
{
    up, down, left, right
}
public class M3_TestEnemy : MonoBehaviour
{
    public float hp = 3;
    public float HP
    {
        get { return hp; }
        set
        {
            hp = value;
            if (hp <= 0)
            {
                Destroy(gameObject);
                M3_GameManager.Instance.SetScore(Random.Range(3, 6));
            }
        }
    }

    public SpriteRenderer sprite;

    public float speed;
    public float PosDelay;
    float Poscur;

    public GameObject bullet;
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
        if (M3_GameManager.Instance.isplaying)
        {
            AIMoving();
            TestAttack();
        }
    }


    void AIMoving()
    {
        if (Poscur >= PosDelay)
        {
            targetpos = new Vector2(Random.Range(-3f, 3f), Random.Range(-3.7f, 0.4f));
            Poscur = 0;
        }
        else
            Poscur += Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, targetpos, speed * Time.deltaTime);
        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < transform.localPosition.x)
            sprite.flipY = true;
        else
            sprite.flipY = false;
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
