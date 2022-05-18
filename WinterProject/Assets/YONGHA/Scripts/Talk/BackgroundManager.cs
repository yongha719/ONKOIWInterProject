using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour
{
    public static BackgroundManager Instance = null;

    [SerializeField] SpriteRenderer backgroundImage;
    [SerializeField] List<Sprite> Backgrounds = new List<Sprite>();
    [SerializeField] List<Sprite> Illusts = new List<Sprite>();

    public GameObject KangObj;
    public GameObject YangObj;
    public GameObject BaekObj;
    [SerializeField] Button BackBtn;

    Animator kangAni;
    Animator yangAni;
    Animator baekAni;

    const int DEFAULT_EXPRESSION = 1;
    const string ANIMATOR_PRAMETER_NAME = "num";
    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        kangAni = KangObj.GetComponent<Animator>();
        yangAni = YangObj.GetComponent<Animator>();
        baekAni = BaekObj.GetComponent<Animator>();

        BackBtn.onClick.AddListener(() =>
        {
            SetCharAni(DEFAULT_EXPRESSION);
        });

    }
    public void SetCharAni(int num)
    {
        switch (TalkManager.Instance.Etalk)
        {
            case TalkChoice.Kang:
                kangAni.SetInteger(ANIMATOR_PRAMETER_NAME, num);
                break;
            case TalkChoice.Yang:
                yangAni.SetInteger(ANIMATOR_PRAMETER_NAME, num);
                break;
            case TalkChoice.Baek:
                baekAni.SetInteger(ANIMATOR_PRAMETER_NAME, num);
                break;
        }
    }
    public void ChangeChar(int Kang, int Yang, int Baek)
    {
        switch (Kang)
        {
            case 0:
                kangAni.SetInteger(ANIMATOR_PRAMETER_NAME, DEFAULT_EXPRESSION);
                KangObj.SetActive(false);
                break;
            default:
                kangAni.SetInteger(ANIMATOR_PRAMETER_NAME, Kang);
                KangObj.SetActive(true);
                break;
        }

        switch (Yang)
        {
            case 0:
                YangObj.SetActive(false);
                break;
            default:
                yangAni.SetInteger(ANIMATOR_PRAMETER_NAME, Yang);
                YangObj.SetActive(true);
                break;
        }

        switch (Baek)
        {
            case 0:
                BaekObj.SetActive(false);
                break;
            default:
                baekAni.SetInteger(ANIMATOR_PRAMETER_NAME, Baek);
                BaekObj.SetActive(true);
                break;
        }
    }
    public void ChangeBackGround(string bgimgname)
    {
        //캐릭터마다 일러스트가 4개씩있는데 일러스트 리스트의 인덱스를 구하기 위한 식임
        int Img = ((int)TalkManager.Instance.Etalk - 1) * 4;

        Sprite sprite = default;

        //background image setting
        switch (bgimgname)
        {
            case "road":
                sprite = Backgrounds[0];
                break;
            case "school":
                sprite = Backgrounds[1];
                break;
            case "library":
                sprite = Backgrounds[2];
                break;
            case "backyard":
                sprite = Backgrounds[3];
                break;
            case "classroom":
                sprite = Backgrounds[4];
                break;
            case "":
                sprite = Backgrounds[5];
                break;
            case "normal":
                sprite = Illusts[Img];
                break;
            case "happy1":
                sprite = Illusts[Img + 1];
                break;
            case "happy2":
                sprite = Illusts[Img + 2];
                break;
            case "happy3":
                sprite = Illusts[Img + 3];
                break;
            default:
                break;
        }

        backgroundImage.sprite = sprite;
    }

}
