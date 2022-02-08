using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    private int randomTag = 0;
    [SerializeField] private Sprite[] ItemsSprites;
    SpriteRenderer spriteRenderer;
    private void Start()
    {
        randomTag = Random.Range(1, 3);
        spriteRenderer = GetComponent<SpriteRenderer>();
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
            spriteRenderer.sprite = ItemsSprites[0];
        }
        //if (randomTag == 2)
        //{
        //    gameObject.tag = "ItemStrong";
        //}
        if (randomTag == 2)
        {
            gameObject.tag = "ItemDelete";
            spriteRenderer.sprite = ItemsSprites[1];
        }
        //if (randomTag == 4)
        //{
        //    gameObject.tag = "ItemSlow";
        //}
    }
}
