using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M3_bullet : MonoBehaviour
{
    public float speed;
    void Start()
    {
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Ãæµ¹");
        if (other.CompareTag("Player"))
        {
            other.GetComponent<M3_Player>().HP--;
            print(other.name);
        }
        if (other.CompareTag("Enemy"))
        {
            print(other.name);
            
            other.GetComponent<M3_TestEnemy>().HP--;
        }
        Destroy(gameObject);
    }
}
