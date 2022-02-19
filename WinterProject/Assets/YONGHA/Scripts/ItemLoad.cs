using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
public class ItemLoad : MonoBehaviour
{
    public static ItemLoad Instance { get; private set; }
    void Awake() => Instance = this;

    public float chaeAhlike = 0, seHwalike = 0, gaYoonlike = 0;
    public float ChaeAhlike
    {
        get
        {
            return chaeAhlike;
        }
        set
        {
            chaeAhlike = value;
            if (chaeAhlike < 0)
                chaeAhlike = 0;
        }
    }
    public float SeHwalike
    {
        get
        {
            return seHwalike;
        }
        set
        {
            seHwalike = value;
            if (seHwalike < 0)
                seHwalike = 0;
        }
    }
    public float GaYoonlike
    {
        get
        {
            return gaYoonlike;
        }
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
        Names = new string[9];
        Names[0] = "곰인형";
        Names[1] = "꽃 한 송이";
        Names[2] = "롤리팝";
        Names[3] = "버려진 러브레터";
        Names[4] = "소설책";
        Names[5] = "초콜릿";
        Names[6] = "커피우유";
        Names[7] = "필기도구";
        Names[8] = "홍차";

        Explans = new string[9];
        Explans[0] = "분홍 색깔에 하늘색 리본이 포인트인 귀여운 곰 인형. 누군가를 닮았다…";
        Explans[1] = "하얀 꽃잎이 아름다운 들 꽃 한 송이. 향기가 좋다";
        Explans[2] = "다 먹기 힘들 정도로 거대한 롤리팝. 중간에 묶인 리본이 귀엽다";
        Explans[3] = "전해 주지도 못하고 버려진 러브레터… 미친게 아니라면 선물하지 말자";
        Explans[4] = "감성 가득한 이야기로 가득 찬 소설책. 보기만 해도 머리가 아프다";
        Explans[5] = "밀크 초콜릿의 맛이 부드럽게 퍼지는 달콤한 고급 초콜릿";
        Explans[6] = "피곤할 때 마시면 좋은 커피우유. 하지만 지나치게 달다";
        Explans[7] = "학생의 필수품 지우개와 연필 세트. 아기자기하고 귀여운 색상들 뿐이다";
        Explans[8] = "얼그레이의 향이 진하게 퍼지는 홍차. 하지만 호불호가 갈릴지도?";

        foreach (var item in ItemBtn)
        {
            item.onClick.AddListener(() =>
            {
                ClickBtnItem = EventSystem.current.currentSelectedGameObject;
                int check = ClickBtnItem.GetComponent<Itembtn>().check;

                ExplanItem.SetActive(true);
                print(ClickBtnItem.name);
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
        GiftLimit.text = "남은 선물 가능 횟수 : " + ((TalkChoice == TalkChoice.Kang) ? chaeAhItemCheck : (TalkChoice == TalkChoice.Yang) ? seHwaItemCheck : gaYoonItemCheck);
    }

    public void ItemLimit()
    {
        if (TalkChoice == TalkChoice.Kang && chaeAhItemCheck != 0)
        {
            print("Tlqkf");
            chaeAhItemCheck--;
            ClickBtnGift();
        }
        else if (TalkChoice == TalkChoice.Yang && seHwaItemCheck != 0)
        {
            print("Tlqkf");
            seHwaItemCheck--;
            ClickBtnGift();
        }
        else if (TalkChoice == TalkChoice.Baek && gaYoonItemCheck != 0)
        {
            print("Tlqkf");
            gaYoonItemCheck--;
            ClickBtnGift();
        }
    }
    public void ClickBtnGift()
    {
        TalkManager.Instance.EGiftEvent(ClickBtnItem.GetComponent<Itembtn>().check);
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
        //EventSystem.current.currentSelectedGameObject.SetActive(false);
    }

    public void SetLikeValue(float temp, int Char)
    {
        switch (Char)
        {
            case 1:
                ChaeAhlike += temp;
                print(ChaeAhlike);
                break;
            case 2:
                SeHwalike += temp;
                break;
            case 3:
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
