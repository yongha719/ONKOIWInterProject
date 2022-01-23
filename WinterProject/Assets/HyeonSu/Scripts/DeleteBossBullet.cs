using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBossBullet : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Snow")
        {
            Destroy(collision.gameObject);
        }
    }
}
