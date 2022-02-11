using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ItemLoad : MonoBehaviour
{
    public static ItemLoad Instance { get; private set; } = null;
    public float chaeAhlike, seHwalike, gaYoonlike;


    public GameObject ClickBtnItem;

    [SerializeField] private GameObject[] BackGrounds;
    [SerializeField] GameObject[] Items;
    [SerializeField] string[] Names;
    [SerializeField] GameObject[] ImageNums;
    [SerializeField] string[] Explans;

    [SerializeField] GameObject LoadItem;
    [SerializeField] Text ItemNameText;
    [SerializeField] Text ExplainText, TalkText;
    [SerializeField] Text[] ItemLimitTexts;
    [SerializeField] GameObject LoadImage;

    public int check;
    public int background_check;
    private bool chaeAhBool;
    private bool seHwaBool;
    private bool gaYoonBool;
    public int chaeAhItemCheck = 3;
    public int seHwaItemCheck = 3;
    public int gaYoonItemCheck = 3;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        Names[0] = "곰인형";
        Names[1] = "꽃 한 송이";
        Names[2] = "롤리팝";
        Names[3] = "버려진 러브레터";
        Names[4] = "소설책";
        Names[5] = "초콜릿";
        Names[6] = "커피우유";
        Names[7] = "필기도구";
        Names[8] = "홍차";

        Explans[0] = "분홍 색깔에 하늘색 리본이 포인트인 귀여운 곰 인형. 누군가를 닮았다…";
        Explans[1] = "하얀 꽃잎이 아름다운 들 꽃 한 송이. 향기가 좋다";
        Explans[2] = "다 먹기 힘들 정도로 거대한 롤리팝. 중간에 묶인 리본이 귀엽다";
        Explans[3] = "전해 주지도 못하고 버려진 러브레터… 미친게 아니라면 선물하지 말자";
        Explans[4] = "감성 가득한 이야기로 가득 찬 소설책. 보기만 해도 머리가 아프다";
        Explans[5] = "밀크 초콜릿의 맛이 부드럽게 퍼지는 달콤한 고급 초콜릿";
        Explans[6] = "피곤할 때 마시면 좋은 커피우유. 하지만 지나치게 달다";
        Explans[7] = "학생의 필수품 지우개와 연필 세트. 아기자기하고 귀여운 색상들 뿐이다";
        Explans[8] = "얼그레이의 향이 진하게 퍼지는 홍차. 하지만 호불호가 갈릴지도?";
    }

    public void ItemLimit()
    {
        if (chaeAhBool == true && chaeAhItemCheck != 0)
        {
            chaeAhItemCheck--;
            ItemLimitTexts[0].text = "남은 선물 가능 횟수 : " + chaeAhItemCheck;
            ClickBtnGift();
        }
        if (seHwaBool == true && seHwaItemCheck != 0)
        {
            seHwaItemCheck--;
            ItemLimitTexts[1].text = "남은 선물 가능 횟수 : " + seHwaItemCheck;
            ClickBtnGift();
        }
        if (gaYoonBool == true && gaYoonItemCheck != 0)
        {
            gaYoonItemCheck--;
            ItemLimitTexts[2].text = "남은 선물 가능 횟수 : " + gaYoonItemCheck;
            ClickBtnGift();
        }
    }
    public void ClickBtnGift()
    {
        if (ClickBtnItem.GetComponent<ItemLoad>().check == 1)
        {
            if (chaeAhBool == true)
            {
                chaeAhlike += 20;
                TalkText.text = "귀여운 곰돌이다! 나한테 주는거야? 고마워~";
            }
            if (seHwaBool == true)
            {
                seHwalike += 10;
                TalkText.text = "저에게 주시는 건가요..? 감사해요";
            }
            if (gaYoonBool == true)
            {
                gaYoonlike++;
            }
            ClickBtnItem.SetActive(false);
            EventSystem.current.currentSelectedGameObject.SetActive(false);
        }
        else if (ClickBtnItem.GetComponent<ItemLoad>().check == 2)
        {
            if (chaeAhBool == true)
            {
                chaeAhlike += 10;
                TalkText.text = "선물? 고마워-! 잘 받을게!";
            }
            if (seHwaBool == true)
            {
                seHwalike -= 20;
                TalkText.text = "저.. 꽃가루 알르레기가 심해서…";
            }
            if (gaYoonBool == true)
            {
                gaYoonlike++;
            }
            ClickBtnItem.SetActive(false);
            EventSystem.current.currentSelectedGameObject.SetActive(false);
        }
        else if (ClickBtnItem.GetComponent<ItemLoad>().check == 3)
        {
            if (chaeAhBool == true)
            {
                chaeAhlike += 10;
                TalkText.text = "선물? 고마워-! 잘 받을게!";
            }
            if (seHwaBool == true)
            {
                seHwalike += 10;
                TalkText.text = "저에게 주시는 건가요..? 감사해요";
            }
            if (gaYoonBool == true)
            {
                gaYoonlike++;
            }
            ClickBtnItem.SetActive(false);
            EventSystem.current.currentSelectedGameObject.SetActive(false);
        }
        else if (ClickBtnItem.GetComponent<ItemLoad>().check == 4)
        {
            if (chaeAhBool == true)
            {
                //호감도 변동 X
                TalkText.text = "너 이런 내용이 진심으로 가윤이한테 통할 거라고 생각했어…?";
            }
            if (seHwaBool == true)
            {
                //호감도 변동 X
                TalkText.text = "가윤이 한테 보낸…? 이걸 왜 저한테…";
            }
            if (gaYoonBool == true)
            {
                gaYoonlike++;
            }
            ClickBtnItem.SetActive(false);
            EventSystem.current.currentSelectedGameObject.SetActive(false);
        }
        else if (ClickBtnItem.GetComponent<ItemLoad>().check == 5)
        {
            if (chaeAhBool == true)
            {
                chaeAhlike += 10;
                TalkText.text = "선물? 고마워-! 잘 받을게!";
            }
            if (seHwaBool == true)
            {
                seHwalike += 20;
                TalkText.text = "읽어본적 없는 책 이네요.. 절 위해서..? 고마워요 잘 읽을게요";
            }
            if (gaYoonBool == true)
            {
                gaYoonlike++;
            }
            ClickBtnItem.SetActive(false);
            EventSystem.current.currentSelectedGameObject.SetActive(false);
        }
        else if (ClickBtnItem.GetComponent<ItemLoad>().check == 6)
        {
            if (chaeAhBool == true)
            {
                chaeAhlike += 10;
                TalkText.text = "선물? 고마워-! 잘 받을게!";
            }
            if (seHwaBool == true)
            {
                seHwalike += 10;
                TalkText.text = "저에게 주시는 건가요..? 감사해요";
            }
            if (gaYoonBool == true)
            {
                gaYoonlike++;
            }
            ClickBtnItem.SetActive(false);
            EventSystem.current.currentSelectedGameObject.SetActive(false);
        }
        else if (ClickBtnItem.GetComponent<ItemLoad>().check == 7)
        {
            if (chaeAhBool == true)
            {
                chaeAhlike += 10;
                TalkText.text = "선물? 고마워-! 잘 받을게!";
            }
            if (seHwaBool == true)
            {
                seHwalike += 10;
                TalkText.text = "저에게 주시는 건가요..? 감사해요";
            }
            if (gaYoonBool == true)
            {
                gaYoonlike++;
            }
            ClickBtnItem.SetActive(false);
            EventSystem.current.currentSelectedGameObject.SetActive(false);
        }
        else if (ClickBtnItem.GetComponent<ItemLoad>().check == 8)
        {
            if (chaeAhBool == true)
            {
                chaeAhlike += 10;
                TalkText.text = "선물? 고마워-! 잘 받을게!";
            }
            if (seHwaBool == true)
            {
                seHwalike += 10;
                TalkText.text = "저에게 주시는 건가요..? 감사해요";
            }
            if (gaYoonBool == true)
            {
                gaYoonlike++;
            }
            ClickBtnItem.SetActive(false);
            EventSystem.current.currentSelectedGameObject.SetActive(false);
        }
        else if (ClickBtnItem.GetComponent<ItemLoad>().check == 9)
        {
            if (chaeAhBool == true)
            {
                chaeAhlike -= 20;
                TalkText.text = "내가 너한테 홍차 싫어한다고 말 안했던가?";
            }
            if (seHwaBool == true)
            {
                seHwalike += 10;
                TalkText.text = "저에게 주시는 건가요..? 감사해요";
            }
            if (gaYoonBool == true)
            {
                gaYoonlike++;
            }
            ClickBtnItem.SetActive(false);
            EventSystem.current.currentSelectedGameObject.SetActive(false);
        }
    }
    public void Click()
    {
        ClickBtnItem = EventSystem.current.currentSelectedGameObject;
        if (LoadItem != null && LoadImage != null)
        {
            LoadItem.SetActive(false);
            LoadImage.SetActive(false);
            ItemNameText.text = "";
            ExplainText.text = "";
        }
        LoadItem = Items[ClickBtnItem.GetComponent<ItemLoad>().check - 1];
        LoadImage = ImageNums[ClickBtnItem.GetComponent<ItemLoad>().check - 1];

        Items[ClickBtnItem.GetComponent<ItemLoad>().check - 1].SetActive(true);
        ImageNums[ClickBtnItem.GetComponent<ItemLoad>().check - 1].SetActive(true);
        ExplainText.text = Explans[ClickBtnItem.GetComponent<ItemLoad>().check - 1].ToString();
        ItemNameText.text = Names[ClickBtnItem.GetComponent<ItemLoad>().check - 1].ToString();

        //Destroy(EventSystem.current.currentSelectedGameObject);
    }

    public void BackGround_Change()
    {
        if (background_check == 0)
        {
            BackGrounds[0].SetActive(true);
            BackGrounds[1].SetActive(false);
            BackGrounds[2].SetActive(false);
            BackGrounds[3].SetActive(false);
        }
        else if (background_check == 1)
        {
            BackGrounds[0].SetActive(false);
            BackGrounds[1].SetActive(true);
            BackGrounds[2].SetActive(false);
            BackGrounds[3].SetActive(false);
        }
        else if (background_check == 2)
        {
            BackGrounds[0].SetActive(false);
            BackGrounds[1].SetActive(false);
            BackGrounds[2].SetActive(true);
            BackGrounds[3].SetActive(false);
        }
        else if (background_check == 3)
        {
            BackGrounds[0].SetActive(false);
            BackGrounds[1].SetActive(false);
            BackGrounds[2].SetActive(false);
            BackGrounds[3].SetActive(true);
        }
    }
    public void Back1()
    {
        background_check = 1;
        chaeAhBool = true;
    }
    public void Back2()
    {
        background_check = 2;
        seHwaBool = true;
    }
    public void Back3()
    {
        background_check = 3;
        gaYoonBool = true;
    }
    public void Back0()
    {
        TalkText.text = "";
        background_check = 0;
        chaeAhBool = false;
        gaYoonBool = false;
        seHwaBool = false;
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
