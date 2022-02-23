using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum PlayerDir
{
    up, down, left, right
}
public class M3_Player : MonoBehaviour
{
    public int hp = 3;
    public int HP
    {
        get { return hp; }
        set
        {
            hp = value;
            M3_GameManager.Instance.SetLife(hp);
            if (hp <= 0)
                M3_GameManager.Instance.gameover = true;
        }
    }
    public PlayerDir playerdir;
    Animator anim;
    [SerializeField] float Speed;


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (M3_GameManager.Instance.isplaying)
        {
            Move();          
            anim.SetInteger("dir", (int)playerdir);
        }
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        transform.Translate(new Vector2(x, y) * Speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.W))
            playerdir = PlayerDir.up;
        else if (Input.GetKeyDown(KeyCode.S))
            playerdir = PlayerDir.down;
        else if (Input.GetKeyDown(KeyCode.A))
            playerdir = PlayerDir.left;
        else if (Input.GetKeyDown(KeyCode.D))
            playerdir = PlayerDir.right;
    }

}
