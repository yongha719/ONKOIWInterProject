using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    private int randomTag;

    private void Start()
    {
        randomTag = Random.Range(1, 2);
        GiveTag();
    }
    private void Update()
    {
        int x = Random.Range(0, 360);
        int y = Random.Range(0, 360);
        gameObject.transform.Rotate(new Vector3(x, y, 0) * Time.deltaTime);
    }
    void GiveTag()
    {
        if (randomTag == 1)
        {
            gameObject.tag = "ItemHp";
        }
        //if (randomTag == 2)
        //{
        //    gameObject.tag = "ItemStrong";
        //}
        if (randomTag == 2)
        {
            gameObject.tag = "ItemDelete";
        }
        //if (randomTag == 4)
        //{
        //    gameObject.tag = "ItemSlow";
        //}
    }
}
