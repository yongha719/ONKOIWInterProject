using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class Boss : MonoBehaviour
{
    public static Boss Instance { get; private set; }
    public float bossHp;

    [SerializeField] private GameObject HpBar;
    [SerializeField] private GameObject ShotSnow;
    [SerializeField] private GameObject Items;
    [SerializeField] private GameObject SkillSnow;
    [SerializeField] private Transform[] Skill1Pos;
    [SerializeField] private GameObject[] asd;
    [SerializeField] private Sprite[] HitSprite; //상태변화  
    [SerializeField] private float MaxShotDelay;
    [SerializeField] private float MaxMoveDelay = 20f;
    [SerializeField] private Transform LeftPos;
    [SerializeField] private Transform RightPos;
    public int attackSpeed = 15;
    private float MinShotDelay;
    [SerializeField] private float MinMoveDelay = 15f;
    SpriteRenderer spriteRenderer;
    private void Awake()
    {
        Instance = this;
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameObject.transform.DOMove(RightPos.transform.position, 5f).SetEase(Ease.Linear);
    }
    private void Start()
    {
    }
    private void Update()
    {
        MinShotDelay += Time.deltaTime;
        MinMoveDelay += Time.deltaTime;
        BossShot();
        HpBar.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0,0.5f, 0));
        if (MaxMoveDelay <= MinMoveDelay)
        {
            LeftMove();
            MinMoveDelay = 0;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Attack")
        {
            Hit();
            int a = Random.Range(1, 11);
            if(a == 1)
            {
                float X = Random.Range(-8.5f, 8.5f);
                Vector3 spawnPosition = new Vector3 (X, 5, 0);
                GameObject item = Instantiate(Items, spawnPosition, gameObject.transform.rotation);
            }
        }
    }
    public void BossSkill1()
    {
        for (int i = 0; i < 3; i++)
        {
            asd[i] = Instantiate(SkillSnow, /*new Vector3(0,4.5f,0)*/gameObject.transform.position, gameObject.transform.rotation);
            asd[i].gameObject.transform.DOMove(Skill1Pos[i].transform.position, 7f).SetEase(Ease.Linear);
        }
    }
    void BossShot()
    {
        if (MaxShotDelay <= MinShotDelay)
        {
        GameObject Snow = Instantiate(ShotSnow, gameObject.transform.position, gameObject.transform.rotation);
        Rigidbody2D rigid = Snow.GetComponent<Rigidbody2D>();
        rigid.AddForce(Vector2.down * attackSpeed, ForceMode2D.Impulse);
            MinShotDelay = 0;

        }
    }
    void Hit()
    {
        spriteRenderer.sprite = HitSprite[1];
        Invoke("ReturnSprite", 0.1f);
        if(bossHp <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Dead");
        }
    }
    void ReturnSprite()
    {
        spriteRenderer.sprite = HitSprite[0];
    }
    private void LeftMove()
    {
        Debug.Log("함수실행함 ㅇㅇ");
        BossSkill1();
        gameObject.transform.DOMove(LeftPos.transform.position, 10f).SetEase(Ease.Linear);
        Invoke("RightMove", 10f);
    }
    void RightMove()
    {
        BossSkill1();
        gameObject.transform.DOMove(RightPos.transform.position, 10f).SetEase(Ease.Linear);
    }
}
