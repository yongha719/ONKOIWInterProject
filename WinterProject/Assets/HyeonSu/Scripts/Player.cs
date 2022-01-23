using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    [SerializeField]private float playerMoveSpeed;
    [SerializeField] private Sprite[] Snowsprites; //눈덩이 강화 상태변화  
    public int playerHp;
    public float attack;
    public float plusAttack = 1;
    private float playerAttackSpeed = 40;
    [SerializeField] private GameObject Bullet;
    SpriteRenderer spriteRenderer;
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        shot();
    }
    private void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * playerMoveSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.position += new Vector3(1, 0, 0) * Time.deltaTime * playerMoveSpeed;
        }
    }
    void shot()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            attack += Time.deltaTime * plusAttack;
            Debug.Log("누르고있어~");
            playerMoveSpeed = 2;
        }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                Debug.Log("뗐어~");
            if (plusAttack == 1) Debug.Log("1배속 공격이다 !");
            if (plusAttack == 2) Debug.Log("2배속 공격이다 !");
            Bullet.GetComponent<Bullet>().damage = attack;
            GameObject ShotSnow = Instantiate(Bullet, transform.position, transform.rotation);
                Rigidbody2D rigid = ShotSnow.GetComponent<Rigidbody2D>();
                rigid.AddForce(Vector2.up * playerAttackSpeed, ForceMode2D.Impulse);
            attack = 0;
            playerMoveSpeed = 10;
            }
    }
    void ReturnPlusAttack()
    {
        plusAttack = 1;
    }
    void ReturnSlowAttack()
    {
        Boss.Instance.attackSpeed = 15;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Snow")
        {
            playerHp--;
            ShootingGameManager.Instance.UpdateHpIcon(playerHp);
            Destroy(collision.gameObject);
            if(playerHp <= 0)
            {
                SceneManager.LoadScene("Dead");
            }
        }
        if(collision.gameObject.tag == "ItemHp")
        {
            if(playerHp < 3)
            {
                playerHp++;
                ShootingGameManager.Instance.UpdateHpIcon(playerHp);
            }
            Destroy(collision.gameObject);
        }
        //if(collision.gameObject.tag == "ItemStrong")
        //{
        //    plusAttack = 2;
        //    Invoke("ReturnPlusAttack", 10f);
        //    Destroy(collision.gameObject);
        //}
        if(collision.gameObject.tag == "ItemDelete")
        {
            GameObject[] objects = GameObject.FindGameObjectsWithTag("Snow");
            for (int i = 0; i < objects.Length; i++)
            {
                Destroy(objects[i]);
            }
            Destroy(collision.gameObject);
        }
        //if(collision.gameObject.tag == "ItemSlow")
        //{
        //    Boss.Instance.attackSpeed = 2;
        //    Invoke("ReturnSlowAttack", 5f);
        //    Destroy(collision.gameObject);
        //}
    }
}
