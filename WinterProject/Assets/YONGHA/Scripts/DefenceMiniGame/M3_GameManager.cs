using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class M3_GameManager : MonoBehaviour
{
    public static M3_GameManager Instance { get; private set; } = null;
    void Awake() => Instance = this;
    [SerializeField] Sprite Life;
    [SerializeField] Image[] LifeImg;
    [SerializeField] int Score;
    [SerializeField] Text scoretext;
    public bool isplaying;
    public bool gameover;
    public GameObject GameOver;
    Button GameOverbtn;
    public GameObject GameClear;
    Button GameClearbtn;
    void Start()
    {
        GameOverbtn = GameOver.GetComponent<Button>();
        GameClearbtn = GameClear.GetComponent<Button>();
        GameOverbtn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Love");
        });
        GameClearbtn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("MiniStory");
        });
    }

    void Update()
    {
        scoretext.text = Score.ToString();
        if (Score >= 100)
        {
            GameClear.SetActive(true);
            isplaying = false;
        }
        if (gameover)
        {
            GameOver.SetActive(true);
            isplaying = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
            Score += 100;
    }
    public void SetLife(int hp)
    {
        if (hp != 3)
            LifeImg[hp].sprite = Life;
    }
    public void SetScore(int score)
    {
        Score += score;
    }
    public void SetGame()
    {
        isplaying = true;
    }

}
