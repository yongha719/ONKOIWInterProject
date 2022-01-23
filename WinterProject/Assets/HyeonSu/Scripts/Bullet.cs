using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    [SerializeField] private ParticleSystem particle;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "DeleteBullet")
        {
            Instantiate(particle, transform.position += new Vector3(0,-0.5f,-5), transform.rotation);
            Destroy(this.gameObject);
        }
        if(collision.gameObject.tag == "BossObj")
        {
            Boss.Instance.bossHp -= damage * 100;
            Instantiate(particle, transform.position += new Vector3(0, 0, -5), transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
