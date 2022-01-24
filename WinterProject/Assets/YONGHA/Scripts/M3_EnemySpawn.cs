using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M3_EnemySpawn : MonoBehaviour
{
    public float SpawnDelay;
    int Enemydir;

    public GameObject Enemy;

    void Start()
    {
        Enemydir = Random.Range(0, 4);
        InvokeRepeating("Spawn", SpawnDelay, SpawnDelay);
    }

    void Update()
    {

    }

    void Spawn()
    {
        switch (Enemydir)
        {
            case 0:
                Instantiate(Enemy, new Vector2(-10, Random.Range(-4f, 4f)), Quaternion.identity);
                break;
            case 1:
                Instantiate(Enemy, new Vector2(10, Random.Range(-4f, 4f)), Quaternion.identity);
                break;
            case 2:
                Instantiate(Enemy, new Vector2(Random.Range(-8f, 8f), -6f), Quaternion.identity);
                break;
            case 3:
                Instantiate(Enemy, new Vector2(Random.Range(-8f, 8f), 6f), Quaternion.identity);
                break;
        }
    }
}
