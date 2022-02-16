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
        Explans[5] = "��ũ ���ݸ��� ���� �ε巴�� ������ ������ ��� ���ݸ�";
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
            ItemLimitTexts[0].text = "���� ���� ���� Ƚ�� : " + chaeAhItemCheck;
        }
        else if (TalkChoice == TalkChoice.Yang && seHwaItemCheck != 0)
        {
            seHwaItemCheck--;
            ItemLimitTexts[1].text = "���� ���� ���� Ƚ�� : " + seHwaItemCheck;
        }
        else if (TalkChoice == TalkChoice.Baek && gaYoonItemCheck != 0)
        {
            gaYoonItemCheck--;
            ItemLimitTexts[2].text = "���� ���� ���� Ƚ�� : " + gaYoonItemCheck;
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
                    TalkText.text = "�Ϳ��� �����̴�! ������ �ִ°ž�? ����~";
                }
                if (TalkChoice == TalkChoice.Yang)
                {
                    seHwalike += 10;
                    TalkText.text = "������ �ֽô� �ǰ���..? �����ؿ�";
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
                    TalkText.text = "����? ����-! �� ������!";
                }
                if (TalkChoice == TalkChoice.Yang)
                {
                    seHwalike -= 20;
                    TalkText.text = "��.. �ɰ��� �˸����Ⱑ ���ؼ���";
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
                    TalkText.text = "����? ����-! �� ������!";
                }
                if (TalkChoice == TalkChoice.Yang)
                {
                    seHwalike += 10;
                    TalkText.text = "������ �ֽô� �ǰ���..? �����ؿ�";
                }
                if (TalkChoice == TalkChoice.Baek)
                {
                    gaYoonlike++;
                }
                break;
            case 4:
                if (TalkChoice == TalkChoice.Kang)
                {
                    //ȣ���� ���� X
                    TalkText.text = "�� �̷� ������ �������� ���������� ���� �Ŷ�� �����߾?";
                }
                if (TalkChoice == TalkChoice.Yang)
                {
                    //ȣ���� ���� X
                    TalkText.text = "������ ���� ������? �̰� �� �����ס�";
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
                    TalkText.text = "����? ����-! �� ������!";
                }
                if (TalkChoice == TalkChoice.Yang)
                {
                    seHwalike += 20;
                    TalkText.text = "�о�� ���� å �̳׿�.. �� ���ؼ�..? ������ �� �����Կ�";
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
                    TalkText.text = "����? ����-! �� ������!";
                }
                if (TalkChoice == TalkChoice.Yang)
                {
                    seHwalike += 10;
                    TalkText.text = "������ �ֽô� �ǰ���..? �����ؿ�";
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
                    TalkText.text = "����? ����-! �� ������!";
                }
                if (TalkChoice == TalkChoice.Yang)
                {
                    seHwalike += 10;
                    TalkText.text = "������ �ֽô� �ǰ���..? �����ؿ�";
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
                    TalkText.text = "����? ����-! �� ������!";
                }
                if (TalkChoice == TalkChoice.Yang)
                {
                    seHwalike += 10;
                    TalkText.text = "������ �ֽô� �ǰ���..? �����ؿ�";
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
                    TalkText.text = "���� ������ ȫ�� �Ⱦ��Ѵٰ� �� ���ߴ���?";
                }
                if (TalkChoice == TalkChoice.Yang)
                {
                    seHwalike += 10;
                    TalkText.text = "������ �ֽô� �ǰ���..? �����ؿ�";
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
        //    print("�����̻�����");
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
