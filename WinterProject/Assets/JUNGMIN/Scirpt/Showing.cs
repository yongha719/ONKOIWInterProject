using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Showing : MonoBehaviour
{
    Vector3 scale = new Vector3(5, 5, 0);
    Vector3 velo = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale =
          Vector3.SmoothDamp(transform.localScale, scale, ref velo, 0.25f);
     
        Destroy(gameObject, 1.15f);
   
    }
}
