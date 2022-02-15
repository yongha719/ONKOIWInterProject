using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField] Transform ClockHandle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ClockHandle.eulerAngles = new Vector3(0, 0, -Time.realtimeSinceStartup * 5);
    }
}
