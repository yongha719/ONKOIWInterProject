using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour
{
    public static BackgroundManager Instance { get; private set; } = null;
    [SerializeField] SpriteRenderer backgroundImage;
    [SerializeField] List<Sprite> Backgrounds = new List<Sprite>();
    [SerializeField] List<Sprite> Illustration = new List<Sprite>();
    [SerializeField] GameObject Kangs;
    [SerializeField] GameObject Yangs;
    [SerializeField] GameObject Baeks;
    [SerializeField] Button Back;
    Animator KangAni;
    Animator YangAni;
    Animator BaekAni;
    public int Kangnum;
    public int Yangnum;
    public int Baeknum;

    void Awake()
    {
        System.W
    }
    void Start()
    {
        KangAni = Kangs.GetComponent<Animator>();
        YangAni = Yangs.GetComponent<Animator>();
        BaekAni = Baeks.GetComponent<Animator>();
        Back.onClick.AddListener(() =>
        {
            AnimationChange(1,TalkManager.Instance.Etalk);
        });

    }
    void Update()
    {
        KangAni.SetInteger("num", Kangnum);
        YangAni.SetInteger("num", Yangnum);
        BaekAni.SetInteger("num", Baeknum);
    }
    public void AnimationChange(int num, TalkChoice talkChoice)
    {
        switch (talkChoice)
        {
            case TalkChoice.Kang:
                Kangnum = num;
                break;
            case TalkChoice.Yang:
                Yangnum = num;
                break;
            case TalkChoice.Baek:
                Baeknum = num;
                break;
        }
    }
    public void CharChange(int Kang, int Yang, int Baek)
    {
        switch (Kang)
        {
            case 0:
                Kangnum = 1;
                Kangs.SetActive(false);
                break;
            default:
                Kangnum = Kang;
                Kangs.SetActive(true);
                break;
        }
        switch (Yang)
        {
            case 0:
                Yangs.SetActive(false);
                break;
            default:
                Yangnum = Yang;
                Yangs.SetActive(true);
                break;
        }
        switch (Baek)
        {
            case 0:
                Baeks.SetActive(false);
                break;
            default:
                Baeknum = Baek;
                Baeks.SetActive(true);
                break;
        }
    }
    public void BackGroundChange(string Bgimage)
    {
        int Img = ((int)TalkManager.Instance.Etalk - 1) * 4;
        switch (Bgimage)
        {
            case "road":
                backgroundImage.sprite = Backgrounds[0];
                break;
            case "school":
                backgroundImage.sprite = Backgrounds[1];
                break;
            case "library":
                backgroundImage.sprite = Backgrounds[2];
                break;
            case "backyard":
                backgroundImage.sprite = Backgrounds[3];
                break;
            case "classroom":
                backgroundImage.sprite = Backgrounds[4];
                break;
            case "":
                backgroundImage.sprite = Backgrounds[5];
                break;
            case "normal":
                backgroundImage.sprite = Illustration[Img];
                break;
            case "happy1":
                backgroundImage.sprite = Illustration[Img + 1];
                break;
            case "happy2":
                backgroundImage.sprite = Illustration[Img + 2];
                break;
            case "happy3":
                backgroundImage.sprite = Illustration[Img + 3];
                break;
            default:
                break;
        }
    }

}
