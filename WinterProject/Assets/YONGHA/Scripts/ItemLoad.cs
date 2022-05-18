using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ItemLoad : MonoBehaviour
{
    public static ItemLoad Instance { get; private set; }
    void Awake() => Instance = this;

    public float chaeAhlike = 0, seHwalike = 0, gaYoonlike = 0;
    public float ChaeAhlike
    {
        get => chaeAhlike;
        set
        {
            chaeAhlike = value;
            if (chaeAhlike < 0)
                chaeAhlike = 0;
        }
    }
    public float SeHwalike
    {
        get => seHwalike;
        set
        {
            seHwalike = value;
            if (seHwalike < 0)
                seHwalike = 0;
        }
    }
    public float GaYoonlike
    {
        get => gaYoonlike;
        set
        {
            gaYoonlike = value;
            if (gaYoonlike < 0)
                gaYoonlike = 0;
        }
    }
    public List<float> Likes;
    TalkChoice TalkChoice;

    public GameObject ClickBtnItem;

    [SerializeField] GameObject ExplanItem;
    //[SerializeField] GameObject ExplanImage;
    [SerializeField] Image EItemimg;
    [SerializeField] Sprite[] Itemimgs;
    [SerializeField] Button[] ItemBtn;
    string[] Names;
    string[] Explans;

    [SerializeField] Text ItemNameText;
    [SerializeField] Text ExplainText;
    [SerializeField] TextMeshProUGUI GiftLimit;
    [SerializeField] Button Gift;

    public int check;
    public int chaeAhItemCheck = 3;
    public int seHwaItemCheck = 3;
    public int gaYoonItemCheck = 3;

    ITalkLoad loader;
    public SaveData giftlist;
    List<bool> gift;
    void Start()
    {
        gift = default;
        loader = new JsonLoader();
        giftlist = loader.LoadSaveData();

        Names = new string[9]
        {
              "곰인형",
              "꽃 한 송이",
              "롤리팝",
              "버려진 러브레터",
              "소설책",
              "초콜릿",
              "커피우유",
              "필기도구",
              "홍차"
        };

        Explans = new string[9]
        {
            "분홍 색깔에 하늘색 리본이 포인트인 귀여운 곰 인형. 누군가를 닮았다…",
            "하얀 꽃잎이 아름다운 들 꽃 한 송이. 향기가 좋다",
            "다 먹기 힘들 정도로 거대한 롤리팝. 중간에 묶인 리본이 귀엽다",
            "전해 주지도 못하고 버려진 러브레터… 미친게 아니라면 선물하지 말자",
            "감성 가득한 이야기로 가득 찬 소설책. 보기만 해도 머리가 아프다",
            "밀크 초콜릿의 맛이 부드럽게 퍼지는 달콤한 고급 초콜릿",
            "피곤할 때 마시면 좋은 커피우유. 하지만 지나치게 달다",
            "학생의 필수품 지우개와 연필 세트. 아기자기하고 귀여운 색상들 뿐이  다",
            "얼그레이의 향이 진하게 퍼지는 홍차. 하지만 호불호가 갈릴지도?"
        };

        foreach (var item in ItemBtn)
        {
            item.onClick.AddListener(() =>
            {
                ClickBtnItem = EventSystem.current.currentSelectedGameObject;
                int check = ClickBtnItem.GetComponent<Itembtn>().check;

                ExplanItem.SetActive(true);
                EItemimg.sprite = Itemimgs[check];
                ExplainText.text = Explans[check];
                ItemNameText.text = Names[check];
            });
        }

        Gift.onClick.AddListener(() =>
        {
            int temp = 0;
            foreach (var item in ItemBtn)
            {

                switch ((int)TalkManager.Instance.Etalk)
                {
                    case 1:
                        gift = giftlist.kangGift;
                        break;
                    case 2:
                        gift = giftlist.yangGift;
                        break;
                    case 3:
                        gift = giftlist.baekGift;
                        break;
                }
                item.gameObject.SetActive(gift[temp++]);
            }
        });
    }
    private void Update()
    {
        TalkChoice = TalkManager.Instance.Etalk;
        Likes = new List<float>() { ChaeAhlike, SeHwalike, GaYoonlike };
        GiftLimit.text = $"남은 선물 가능 횟수 : {((TalkChoice == TalkChoice.Kang) ? chaeAhItemCheck : (TalkChoice == TalkChoice.Yang) ? seHwaItemCheck : gaYoonItemCheck)}";
    }

    public void ItemLimit()
    {
        if (TalkChoice == TalkChoice.Kang && chaeAhItemCheck != 0)
        {
            chaeAhItemCheck--;
            ClickBtnGift();
        }
        else if (TalkChoice == TalkChoice.Yang && seHwaItemCheck != 0)
        {
            seHwaItemCheck--;
            ClickBtnGift();
        }
        else if (TalkChoice == TalkChoice.Baek && gaYoonItemCheck != 0)
        {
            gaYoonItemCheck--;
            ClickBtnGift();
        }
    }

    public void ClickBtnGift()
    {
        TalkManager.Instance.SetGiftEvent(ClickBtnItem.GetComponent<Itembtn>().check);
        ClickBtnItem.SetActive(false);
        int temp = 0;
        foreach (var item in ItemBtn)
        {
            switch (TalkManager.Instance.Etalk)
            {
                case TalkChoice.Kang:
                    giftlist.kangGift[temp++] = item.gameObject.activeSelf;
                    break;
                case TalkChoice.Yang:
                    giftlist.yangGift[temp++] = item.gameObject.activeSelf;
                    break;
                case TalkChoice.Baek:
                    giftlist.baekGift[temp++] = item.gameObject.activeSelf;
                    break;
                default:
                    break;
            }
        }
    }

    public void SetLikeValue(float temp, TalkChoice Char)
    {
        switch (Char)
        {
            case TalkChoice.Kang:
                ChaeAhlike += temp;
                break;
            case TalkChoice.Yang:
                SeHwalike += temp;
                break;
            case TalkChoice.Baek:
                GaYoonlike += temp;
                break;
        }
    }
    public void SetLikeValue(float kang, float yang, float baek)
    {
        ChaeAhlike = kang;
        SeHwalike = yang;
        GaYoonlike = baek;
    }
    private void OnDestroy()
    {
        GameManager.Instance.kanglike = ChaeAhlike;
        GameManager.Instance.yanglike = SeHwalike;
        GameManager.Instance.beaklike = GaYoonlike;
    }
}
