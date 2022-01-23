using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    public float SpawnDelay;
    public int Speed;
    int bulletdir;

    GameObject bullet;

    void Start()
    {
        bulletdir = Random.Range(0, 4);
        InvokeRepeating("Spawn", SpawnDelay, SpawnDelay);
    }

    void Update()
    {

    }

    void Spawn()
    {
        switch (bulletdir)
        {
            case 0:
                Instantiate(bullet, new Vector2(-10, Random.Range(-4f, 4f)), Quaternion.identity);
                break;
            case 1:
                Instantiate(bullet, new Vector2(10, Random.Range(-4f, 4f)), Quaternion.identity);
                break;
            case 2:
                Instantiate(bullet, new Vector2(Random.Range(-8f, 8f), -6f), Quaternion.identity);
                break;
            case 3:
                Instantiate(bullet, new Vector2(Random.Range(-8f, 8f), 6f), Quaternion.identity);
                break;
        }
    }
}
