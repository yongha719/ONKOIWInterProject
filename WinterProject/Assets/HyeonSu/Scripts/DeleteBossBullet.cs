using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBossBullet : MonoBehaviour
{
    [SerializeField] private ParticleSystem particle;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "DeleteBullet")
        {
            Destroy(gameObject);
            Instantiate(particle, transform.position += new Vector3(0, 0.5f, -5), transform.rotation);
        }
    }
}
