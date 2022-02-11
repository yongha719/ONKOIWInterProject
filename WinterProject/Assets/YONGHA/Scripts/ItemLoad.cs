using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ItemLoad : MonoBehaviour
{
    public float chaeAhlike, seHwalike, gaYoonlike;


    public GameObject ClickBtnItem;

    [SerializeField] private GameObject[] BackGrounds;
    [SerializeField] GameObject[] Items;
    [SerializeField] string[] Names;
    [SerializeField] GameObject[] ImageNums;
    [SerializeField] string[] Explans;

    [SerializeField] GameObject LoadItem;
    [SerializeField] Text ItemNameText;
    [SerializeField] Text ExplainText;
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
    void Start()
    {
        Names[0] = "������";
        Names[1] = "�� �� ����";
        Names[2] = "�Ѹ���";
        Names[3] = "������ ���극��";
        Names[4] = "�Ҽ�å";
        Names[5] = "���ݸ�";
        Names[6] = "Ŀ�ǿ���";
        Names[7] = "�ʱ⵵��";
        Names[8] = "ȫ��";

        Explans[0] = "��ȫ ���� �ϴû� ������ ����Ʈ�� �Ϳ��� �� ����. �������� ��Ҵ١�";
        Explans[1] = "�Ͼ� ������ �Ƹ��ٿ� �� �� �� ����. ��Ⱑ ����";
        Explans[2] = "�� �Ա� ���� ������ �Ŵ��� �Ѹ���. �߰��� ���� ������ �Ϳ���";
        Explans[3] = "���� ������ ���ϰ� ������ ���극�͡� ��ģ�� �ƴ϶�� �������� ����";
        Explans[4] = "���� ������ �̾߱�� ���� �� �Ҽ�å. ���⸸ �ص� �Ӹ��� ������";
        Explans[5] = "��ũ ���ݸ��� ���� �ε巴�� ������ ������ ��� ���ݸ�";
        Explans[6] = "�ǰ��� �� ���ø� ���� Ŀ�ǿ���. ������ ����ġ�� �޴�";
        Explans[7] = "�л��� �ʼ�ǰ ���찳�� ���� ��Ʈ. �Ʊ��ڱ��ϰ� �Ϳ��� ����� ���̴�";
        Explans[8] = "��׷����� ���� ���ϰ� ������ ȫ��. ������ ȣ��ȣ�� ��������?";
    }
    
    public void ItemLimit()
    {
        if (chaeAhBool == true && chaeAhItemCheck != 0)
        {
            chaeAhItemCheck--;
            ItemLimitTexts[0].text = "���� ���� ���� Ƚ�� : " + chaeAhItemCheck;
            ClickBtnGift();
        }
        if (seHwaBool == true && seHwaItemCheck != 0)
        {
            seHwaItemCheck--;
            ItemLimitTexts[1].text = "���� ���� ���� Ƚ�� : " + seHwaItemCheck;
            ClickBtnGift();
        }
        if (gaYoonBool == true && gaYoonItemCheck != 0)
        {
            gaYoonItemCheck--;
            ItemLimitTexts[2].text = "���� ���� ���� Ƚ�� : " + gaYoonItemCheck;
            ClickBtnGift();
        }
    }
    public void ClickBtnGift()
    {
        if (ClickBtnItem.GetComponent<ItemLoad>().check == 1)
        {
            if(chaeAhBool == true)
            {
                chaeAhlike += 20;
            }
            if (seHwaBool == true)
            {
                seHwalike++;
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
            }
            if (seHwaBool == true)
            {
                seHwalike++;
            }
            if (gaYoonBool == true)
            {
                gaYoonlike++;
            }
            ClickBtnItem.SetActive(false);
            EventSystem.current.currentSelectedGameObject.SetActive(false);
        }
        else if(ClickBtnItem.GetComponent<ItemLoad>().check == 3)
        {
            if (chaeAhBool == true)
            {
                chaeAhlike += 10;
            }
            if (seHwaBool == true)
            {
                seHwalike++;
            }
            if (gaYoonBool == true)
            {
                gaYoonlike++;
            }
            ClickBtnItem.SetActive(false);
            EventSystem.current.currentSelectedGameObject.SetActive(false);
        }
        else if(ClickBtnItem.GetComponent<ItemLoad>().check == 4)
        {
            if (chaeAhBool == true)
            {
                //ȣ���� ���� X
            }
            if (seHwaBool == true)
            {
                seHwalike++;
            }
            if (gaYoonBool == true)
            {
                gaYoonlike++;
            }
            ClickBtnItem.SetActive(false);
            EventSystem.current.currentSelectedGameObject.SetActive(false);
        }
        else if(ClickBtnItem.GetComponent<ItemLoad>().check == 5)
        {
            if (chaeAhBool == true)
            {
                chaeAhlike += 10;
            }
            if (seHwaBool == true)
            {
                seHwalike++;
            }
            if (gaYoonBool == true)
            {
                gaYoonlike++;
            }
            ClickBtnItem.SetActive(false);
            EventSystem.current.currentSelectedGameObject.SetActive(false);
        }
        else if(ClickBtnItem.GetComponent<ItemLoad>().check == 6)
        {
            if (chaeAhBool == true)
            {
                chaeAhlike += 10;
            }
            if (seHwaBool == true)
            {
                seHwalike++;
            }
            if (gaYoonBool == true)
            {
                gaYoonlike++;
            }
            ClickBtnItem.SetActive(false);
            EventSystem.current.currentSelectedGameObject.SetActive(false);
        }
        else if(ClickBtnItem.GetComponent<ItemLoad>().check == 7)
        {
            if (chaeAhBool == true)
            {
                chaeAhlike += 10;
            }
            if (seHwaBool == true)
            {
                seHwalike++;
            }
            if (gaYoonBool == true)
            {
                gaYoonlike++;
            }
            ClickBtnItem.SetActive(false);
            EventSystem.current.currentSelectedGameObject.SetActive(false);
        }
        else if(ClickBtnItem.GetComponent<ItemLoad>().check == 8)
        {
            if (chaeAhBool == true)
            {
                chaeAhlike += 10;
            }
            if (seHwaBool == true)
            {
                seHwalike++;
            }
            if (gaYoonBool == true)
            {
                gaYoonlike++;
            }
            ClickBtnItem.SetActive(false);
            EventSystem.current.currentSelectedGameObject.SetActive(false);
        }
        else if(ClickBtnItem.GetComponent<ItemLoad>().check == 9)
        {
            if (chaeAhBool == true)
            {
                chaeAhlike -= 20;
            }
            if (seHwaBool == true)
            {
                seHwalike++;
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
        if(background_check == 0)
        {
            BackGrounds[0].SetActive(true);
            BackGrounds[1].SetActive(false);
            BackGrounds[2].SetActive(false);
            BackGrounds[3].SetActive(false);
        }
        else if(background_check == 1)
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
        background_check = 0;
        chaeAhBool = false;
        gaYoonBool = false;
        seHwaBool = false;
    }
}
