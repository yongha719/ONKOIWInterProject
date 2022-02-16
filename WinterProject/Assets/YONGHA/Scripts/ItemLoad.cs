using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ItemLoad : MonoBehaviour
{
    public static ItemLoad Instance { get; private set; }
    void Awake() => Instance = this;

    public float chaeAhlike, seHwalike, gaYoonlike;
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
    [SerializeField] Text ExplainText, TalkText;
    [SerializeField] Text[] ItemLimitTexts;

    public int check;
    public int chaeAhItemCheck = 3;
    public int seHwaItemCheck = 3;
    public int gaYoonItemCheck = 3;

    void Start()
    {
        Likes = new List<float>() { chaeAhlike, seHwalike, gaYoonlike };
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
                print("CLick");
                EItemimg.sprite = Itemimgs[check];

                ExplainText.text = Explans[check];
                ItemNameText.text = Names[check];
            });
        }
        TalkChoice = TalkManager.Instance.Etalk;
    }

    public void ItemLimit()
    {
        if (TalkChoice == TalkChoice.Kang && chaeAhItemCheck != 0)
        {
            chaeAhItemCheck--;
            ItemLimitTexts[0].text = "남은 선물 가능 횟수 : " + chaeAhItemCheck;
        }
        else if (TalkChoice == TalkChoice.Yang && seHwaItemCheck != 0)
        {
            seHwaItemCheck--;
            ItemLimitTexts[1].text = "남은 선물 가능 횟수 : " + seHwaItemCheck;
        }
        else if (TalkChoice == TalkChoice.Baek && gaYoonItemCheck != 0)
        {
            gaYoonItemCheck--;
            ItemLimitTexts[2].text = "남은 선물 가능 횟수 : " + gaYoonItemCheck;
        }
        ClickBtnGift();
    }
    public void ClickBtnGift()
    {
        switch (ClickBtnItem.GetComponent<Itembtn>().check)
        {
            case 1:
                if (TalkChoice == TalkChoice.Kang)
                {
                    chaeAhlike += 20;
                    TalkText.text = "귀여운 곰돌이다! 나한테 주는거야? 고마워~";
                }
                if (TalkChoice == TalkChoice.Yang)
                {
                    seHwalike += 10;
                    TalkText.text = "저에게 주시는 건가요..? 감사해요";
                }
                if (TalkChoice == TalkChoice.Baek)
                {
                    gaYoonlike++;
                }
                break;
            case 2:
                if (TalkChoice == TalkChoice.Kang)
                {
                    chaeAhlike += 10;
                    TalkText.text = "선물? 고마워-! 잘 받을게!";
                }
                if (TalkChoice == TalkChoice.Yang)
                {
                    seHwalike -= 20;
                    TalkText.text = "저.. 꽃가루 알르레기가 심해서…";
                }
                if (TalkChoice == TalkChoice.Baek)
                {
                    gaYoonlike++;
                }
                break;
            case 3:
                if (TalkChoice == TalkChoice.Kang)
                {
                    chaeAhlike += 10;
                    TalkText.text = "선물? 고마워-! 잘 받을게!";
                }
                if (TalkChoice == TalkChoice.Yang)
                {
                    seHwalike += 10;
                    TalkText.text = "저에게 주시는 건가요..? 감사해요";
                }
                if (TalkChoice == TalkChoice.Baek)
                {
                    gaYoonlike++;
                }
                break;
            case 4:
                if (TalkChoice == TalkChoice.Kang)
                {
                    //호감도 변동 X
                    TalkText.text = "너 이런 내용이 진심으로 가윤이한테 통할 거라고 생각했어…?";
                }
                if (TalkChoice == TalkChoice.Yang)
                {
                    //호감도 변동 X
                    TalkText.text = "가윤이 한테 보낸…? 이걸 왜 저한테…";
                }
                if (TalkChoice == TalkChoice.Baek)
                {
                    gaYoonlike++;
                }
                break;
            case 5:
                if (TalkChoice == TalkChoice.Kang)
                {
                    chaeAhlike += 10;
                    TalkText.text = "선물? 고마워-! 잘 받을게!";
                }
                if (TalkChoice == TalkChoice.Yang)
                {
                    seHwalike += 20;
                    TalkText.text = "읽어본적 없는 책 이네요.. 절 위해서..? 고마워요 잘 읽을게요";
                }
                if (TalkChoice == TalkChoice.Baek)
                {
                    gaYoonlike++;
                }
                break;
            case 6:
                if (TalkChoice == TalkChoice.Kang)
                {
                    chaeAhlike += 10;
                    TalkText.text = "선물? 고마워-! 잘 받을게!";
                }
                if (TalkChoice == TalkChoice.Yang)
                {
                    seHwalike += 10;
                    TalkText.text = "저에게 주시는 건가요..? 감사해요";
                }
                if (TalkChoice == TalkChoice.Baek)
                {
                    gaYoonlike++;
                }
                break;
            case 7:
                if (TalkChoice == TalkChoice.Kang)
                {
                    chaeAhlike += 10;
                    TalkText.text = "선물? 고마워-! 잘 받을게!";
                }
                if (TalkChoice == TalkChoice.Yang)
                {
                    seHwalike += 10;
                    TalkText.text = "저에게 주시는 건가요..? 감사해요";
                }
                if (TalkChoice == TalkChoice.Baek)
                {
                    gaYoonlike++;
                }
                break;
            case 8:
                if (TalkChoice == TalkChoice.Kang)
                {
                    chaeAhlike += 10;
                    TalkText.text = "선물? 고마워-! 잘 받을게!";
                }
                if (TalkChoice == TalkChoice.Yang)
                {
                    seHwalike += 10;
                    TalkText.text = "저에게 주시는 건가요..? 감사해요";
                }
                if (TalkChoice == TalkChoice.Baek)
                {
                    gaYoonlike++;
                }
                break;
            case 9:
                if (TalkChoice == TalkChoice.Kang)
                {
                    chaeAhlike -= 20;
                    TalkText.text = "내가 너한테 홍차 싫어한다고 말 안했던가?";
                }
                if (TalkChoice == TalkChoice.Yang)
                {
                    seHwalike += 10;
                    TalkText.text = "저에게 주시는 건가요..? 감사해요";
                }
                if (TalkChoice == TalkChoice.Baek)
                {
                    gaYoonlike++;
                }
                break;
            default:
                break;
        }
        ClickBtnItem.SetActive(false);
        //EventSystem.current.currentSelectedGameObject.SetActive(false);
    }
    public void Click()
    {

        //if (LoadItem != null && LoadImage != null)
        //{
        //    //LoadItem.SetActive(false);
        //    LoadImage.SetActive(false);
        //    ItemNameText.text = "";
        //    ExplainText.text = "";
        //    print("뭐야이새끼는");
        //}
        //LoadItem = Items[check];
        //LoadImage = ImageNums[check];
        //print(LoadItem.activeSelf);
        //Items[check].SetActive(true);

        //Destroy(EventSystem.current.currentSelectedGameObject);
    }
    public void Gift()
    {
        ItemNameText.text = "";
        ExplainText.text = "";
    }
    public void Back0()
    {
        TalkText.text = "";
    }
    public void SetLikeValue(int temp, int Char)
    {
        switch (Char)
        {
            case 1:
                chaeAhlike += temp;
                break;
            case 2:
                seHwalike += temp;
                break;
            case 3:
                gaYoonlike += temp;
                break;
        }
    }
}
