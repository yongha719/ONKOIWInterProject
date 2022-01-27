using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class M3_Player : MonoBehaviour
{
    public float Hp;
    public float DMG;

    [SerializeField] float Speed;

    void Start()
    {

    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        transform.Translate(new Vector2(x, y) * Speed * Time.deltaTime);
    }

    public void Damaged(int damage)
    {
        if (Hp < damage)
        {
            print("Game Over");
        }
        else
            Hp -= damage;
    }
}
