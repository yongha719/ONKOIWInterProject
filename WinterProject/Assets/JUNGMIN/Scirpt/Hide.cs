using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    public Transform hidetransform;
    List<GameObject> hide = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform ht in hidetransform)
        {
            hide.Add(ht.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
