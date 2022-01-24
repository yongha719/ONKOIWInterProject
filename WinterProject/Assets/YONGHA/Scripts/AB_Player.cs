using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AB_Player : MonoBehaviour
{
    public float Hp;
    public float DMG;
    public float Speed;

    
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
}
