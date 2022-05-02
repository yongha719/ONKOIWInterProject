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
        Names[0] = "������";
        Names[1] = "�� �� ����";
        Names[2] = "�Ѹ���";
        Names[3] = "������ ���극��";
        Names[4] = "�Ҽ�å";
        Names[5] = "���ݸ�";
        Names[6] = "Ŀ�ǿ���";
        Names[7] = "�ʱ⵵��";
        Names[8] = "ȫ��";

        Explans = new string[9];
        Explans[0] = "��ȫ ���� �ϴû� ������ ����Ʈ�� �Ϳ��� �� ����. �������� ��Ҵ١�";
        Explans[1] = "�Ͼ� ������ �Ƹ��ٿ� �� �� �� ����. ��Ⱑ ����";
        Explans[2] = "�� �Ա� ���� ������ �Ŵ��� �Ѹ���. �߰��� ���� ������ �Ϳ���";
        Explans[3] = "���� ������ ���ϰ� ������ ���극�͡� ��ģ�� �ƴ϶�� �������� ����";
        Explans[4] = "���� ������ �̾߱�� ���� �� �Ҽ�å. ���⸸ �ص� �Ӹ��� ������";
        Explans[5] = "��ũ ���ݸ��� ���� �ε巴�� ������ ������ ���� ���ݸ�";
        Explans[6] = "�ǰ��� �� ���ø� ���� Ŀ�ǿ���. ������ ����ġ�� �޴�";
        Explans[7] = "�л��� �ʼ�ǰ ���찳�� ���� ��Ʈ. �Ʊ��ڱ��ϰ� �Ϳ��� ����� ���̴�";
        Explans[8] = "��׷����� ���� ���ϰ� ������ ȫ��. ������ ȣ��ȣ�� ��������?";
        
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
        GiftLimit.text = $"���� ���� ���� Ƚ�� : {((TalkChoice == TalkChoice.Kang) ? chaeAhItemCheck : (TalkChoice == TalkChoice.Yang) ? seHwaItemCheck : gaYoonItemCheck)}";
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
