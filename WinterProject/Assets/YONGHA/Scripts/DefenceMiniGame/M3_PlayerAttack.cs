using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M3_PlayerAttack : MonoBehaviour
{
    public float AttackDelay = 0.5f;
    float Attackcur = 0;

    public GameObject bullet;
    public GameObject Player;
    M3_Player player;
    public Transform gun;
    public SpriteRenderer sprite;
    void Start()
    {
        player = Player.GetComponent<M3_Player>();
    }

    void Update()
    {
        Attack();
        if (player.playerdir == PlayerDir.down)
            sprite.sortingOrder = 3;
        else
            sprite.sortingOrder = 2;
    }
    void Attack()
    {
        if (M3_GameManager.Instance.isplaying)
        {
            Vector2 len = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, z);
            if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < Player.transform.localPosition.x)
                sprite.flipY = true;
            else
                sprite.flipY = false;
            if (Attackcur <= 0)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Instantiate(bullet, gun.position, transform.rotation);
                    Attackcur = AttackDelay;
                }
            }
            else
                Attackcur -= Time.deltaTime;
        }
    }
}
