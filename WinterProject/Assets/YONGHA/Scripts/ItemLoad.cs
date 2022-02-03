using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ItemLoad : MonoBehaviour
{
    public float like;


    public GameObject ClickBtnItem;

    [SerializeField] GameObject[] Items;
    [SerializeField] string[] Names;
    [SerializeField] GameObject[] ImageNums;
    [SerializeField] string[] Explans;

    [SerializeField] GameObject LoadItem;
    [SerializeField] Text ItemNameText;
    [SerializeField] Text ExplainText;
    [SerializeField] GameObject LoadImage;

    public int check;
    // Start is called before the first frame update
    void Start()
    {
        Names[0] = "����";
        Names[1] = "��Ȳ";
        Names[2] = "���";
        Names[3] = "����";
        Names[4] = "�ʷ�";
        Names[5] = "��Ʈ";
        Names[6] = "�Ķ�";
        Names[7] = "��ȫ";
        Names[8] = "����";

        Explans[0] = "������ �Դϴ�!";
        Explans[1] = "��Ȳ�� �Դϴ�!";
        Explans[2] = "����� �Դϴ�!";
        Explans[3] = "���λ� �Դϴ�!";
        Explans[4] = "�ʷϻ� �Դϴ�!";
        Explans[5] = "��Ʈ�� �Դϴ�!";
        Explans[6] = "�Ķ��� �Դϴ�!";
        Explans[7] = "��ȫ�� �Դϴ�!";
        Explans[8] = "����� �Դϴ�!";
    }

     public void ClickBtnGift()
    {
        if (ClickBtnItem.GetComponent<ItemLoad>().check == 1)
        {
            like += 5;
            ClickBtnItem.SetActive(false);
        }
        if (ClickBtnItem.GetComponent<ItemLoad>().check == 2)
        {
            like += 4;
            ClickBtnItem.SetActive(false);
        }
        if (ClickBtnItem.GetComponent<ItemLoad>().check == 3)
        {
            like -= 10;
            ClickBtnItem.SetActive(false);
        }
        if (ClickBtnItem.GetComponent<ItemLoad>().check == 4)
        {
            like -= 6;
            ClickBtnItem.SetActive(false);
        }
        if (ClickBtnItem.GetComponent<ItemLoad>().check == 5)
        {
            like += 15;
            ClickBtnItem.SetActive(false);
        }
        if (ClickBtnItem.GetComponent<ItemLoad>().check == 6)
        {
            like += 8;
            ClickBtnItem.SetActive(false);
        }
        if (ClickBtnItem.GetComponent<ItemLoad>().check == 7)
        {
            like -= 3;
            ClickBtnItem.SetActive(false);
        }
        if (ClickBtnItem.GetComponent<ItemLoad>().check == 8)
        {
            like += 20;
            ClickBtnItem.SetActive(false);
        }
        if (ClickBtnItem.GetComponent<ItemLoad>().check == 9)
        {
            like -= 15;
            ClickBtnItem.SetActive(false);
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
}
