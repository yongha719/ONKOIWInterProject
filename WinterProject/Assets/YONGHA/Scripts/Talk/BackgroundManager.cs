using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour
{
    public static BackgroundManager Instance { get; private set; } = null;
    [SerializeField] SpriteRenderer backgroundImage;
    [SerializeField] List<Sprite> Backgrounds = new List<Sprite>();
    [SerializeField] GameObject Kangs;
    [SerializeField] GameObject Yangs;
    [SerializeField] GameObject Baeks;
    Animator KangAni;
    Animator YangAni;
    Animator BaekAni;
    int Kangnum;
    int Yangnum;
    int Baeknum;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        KangAni = Kangs.GetComponent<Animator>();
        YangAni = Yangs.GetComponent<Animator>();
        BaekAni = Baeks.GetComponent<Animator>();

    }
    void Update()
    {
        KangAni.SetInteger("num", Kangnum);
        YangAni.SetInteger("num", Yangnum);
        BaekAni.SetInteger("num", Baeknum);


    }
    public void CharChange(int Kang, int Yang, int Baek)
    {
        switch (Kang)
        {
            case 0:
                Kangs.SetActive(false);
                break;
            default:
                Kangs.SetActive(true);
                break;
        }
        switch (Yang)
        {
            case 0:
                Yangs.SetActive(false);
                break;
            default:
                Yangs.SetActive(true);
                break;
        }
        switch (Baek)
        {
            case 0:
                Baeks.SetActive(false);
                break;
            default:
                Baeks.SetActive(true);
                break;
        }
        Kangnum = Kang;
        Yangnum = Yang;
        Baeknum = Baek;

    }
    public void BackGroundChange(string Bgimage)
    {
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
            default:
                break;
        }
    }
}
