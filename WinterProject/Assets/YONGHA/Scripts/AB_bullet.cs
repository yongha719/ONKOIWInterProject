using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AB_bullet : MonoBehaviour
{
    public float speed;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
