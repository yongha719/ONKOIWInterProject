using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float AttackDelay;
    float Attackcur;

    public GameObject bullet;
    public Transform gun;

    void Start()
    {

    }

    void Update()
    {
        Attack();
    }
    void Attack()
    {
        Vector2 len = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, z);
        if (Attackcur <= 0)
        {
            if (Input.GetMouseButton(0))
                Instantiate(bullet, gun.position, transform.rotation);
            Attackcur = AttackDelay;
        }
        Attackcur -= Time.deltaTime;
    }
}
