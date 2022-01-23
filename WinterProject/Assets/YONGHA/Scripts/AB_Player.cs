using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AB_Player : MonoBehaviour
{
    public float Speed;

    void Start()
    {
           
    }

    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.T))
            SceneManager.LoadScene("Test");
    }
    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        transform.Translate(new Vector2(x, y) * Speed * Time.deltaTime);
    }
}
