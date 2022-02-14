using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class Boss : MonoBehaviour
{
    public static Boss Instance { get; private set; }
    public float bossHp;

    private Animator Ani;
    private bool anibool = false;

    [SerializeField] private GameObject HpBar, ShotSnow, Items, SkillSnow;
    [SerializeField] private Transform[] Skill1Pos;
    [SerializeField] private GameObject[] BossSkillobjs;
    [SerializeField] private Sprite[] HitSprite; //상태변화  
    [SerializeField] private float MaxShotDelay, MaxMoveDelay = 20f, MinMoveDelay = 15f;
    [SerializeField] private Transform LeftPos, RightPos;
    public int attackSpeed = 15;
    private float MinShotDelay;
    SpriteRenderer spriteRenderer;
    private void Awake()
    {
        Instance = this;
        spriteRenderer = GetComponent<SpriteRenderer>();
        Ani = GetComponent<Animator>();
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
        HpBar.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0,1.5f, 0));
        if (MaxMoveDelay <= MinMoveDelay)
        {
            anibool = true;
            Ani.SetBool("ccc", anibool);
            LeftMove();
            MinMoveDelay = 0;
            Invoke("ReturnAni", 0.6f);
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
            BossSkillobjs[i] = Instantiate(SkillSnow, /*new Vector3(0,4.5f,0)*/gameObject.transform.position, gameObject.transform.rotation);
            BossSkillobjs[i].gameObject.transform.DOMove(Skill1Pos[i].transform.position, 7f).SetEase(Ease.Linear);
        }
    }
    void BossShot()
    {
        if (MaxShotDelay <= MinShotDelay)
        {
            anibool = true;
            Ani.SetBool("ccc", anibool);
            GameObject Snow = Instantiate(ShotSnow, gameObject.transform.position += new Vector3(0,1,0), gameObject.transform.rotation);
        Rigidbody2D rigid = Snow.GetComponent<Rigidbody2D>();
        rigid.AddForce(Vector2.down * attackSpeed, ForceMode2D.Impulse);
            MinShotDelay = 0;
            Invoke("ReturnAni", 0.6f);

        }
    }
    void Hit()
    {
        spriteRenderer.sprite = HitSprite[1];
        Invoke("ReturnSprite", 0.1f);
        if(bossHp <= 0)
        {
            Destroy(gameObject);
            //SceneManager.LoadScene("Dead"); 이거 클리어 씬으로 바꿔야함
        }
    }
    void ReturnSprite()
    {
        spriteRenderer.sprite = HitSprite[0];
    }
    void ReturnAni()
    {
        anibool = false;
        Ani.SetBool("ccc", anibool);
    }
    private void LeftMove()
    {
        Debug.Log("함수실행함 ㅇㅇ");
        anibool = true;
        Ani.SetBool("ccc", anibool);
        Invoke("ReturnAni", 0.6f);
        BossSkill1();
        gameObject.transform.DOMove(LeftPos.transform.position, 10f).SetEase(Ease.Linear);
        Invoke("RightMove", 10f);
    }
    void RightMove()
    {
        anibool = true;
        Ani.SetBool("ccc", anibool);
        Invoke("ReturnAni", 0.6f);
        BossSkill1();
        gameObject.transform.DOMove(RightPos.transform.position, 10f).SetEase(Ease.Linear);
    }
}
