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

    void Spawn()
    {
        if (M3_GameManager.Instance.isplaying)
        {
            switch (Enemydir)
            {
                case 0:
                    Instantiate(Enemy, new Vector2(-3, Random.Range(-3.7f, 0.4f)), Quaternion.identity);
                    break;
                case 1:
                    Instantiate(Enemy, new Vector2(3, Random.Range(-3.7f, 0.4f)), Quaternion.identity);
                    break;
                case 2:
                    Instantiate(Enemy, new Vector2(Random.Range(-3f, 3f), 0.4f), Quaternion.identity);
                    break;
                case 3:
                    Instantiate(Enemy, new Vector2(Random.Range(-3f, 3f), -3.7f), Quaternion.identity);
                    break;
            }
        }
    }
}
